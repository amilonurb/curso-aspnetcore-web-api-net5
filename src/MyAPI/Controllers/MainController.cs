using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyAPI.Business.Interfaces;
using MyAPI.Business.Notificacoes;
using System.Linq;

namespace MyAPI.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        public MainController(INotificador notificador) => _notificador = notificador;

        protected IActionResult CustomResponse(object result = null) =>
            OperacaoValida() ? Ok((success: true, data: result))
                             : BadRequest((success: false, errors: _notificador.ObterNotificacoes().Select(n => n.Mensagem)));

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotificarErroModelInvalida(modelState);

            return CustomResponse();
        }

        private bool OperacaoValida() => !_notificador.TemNotificacao();

        private void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var mensagemErro = erro.Exception is null ? erro.ErrorMessage : erro.Exception.Message;

                NotificarErro(mensagemErro);
            }
        }

        private void NotificarErro(string mensagemErro) => _notificador.Handle(new Notificacao(mensagemErro));
    }
}