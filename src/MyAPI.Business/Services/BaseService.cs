using FluentValidation;
using MyAPI.Business.Interfaces;
using MyAPI.Business.Models;
using MyAPI.Business.Notificacoes;

namespace MyAPI.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador) => _notificador = notificador;

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var resultadoValidacao = validacao.Validate(entidade);

            if (resultadoValidacao.IsValid)
                return true;

            Notificar(resultadoValidacao);

            return false;
        }

        private void Notificar(FluentValidation.Results.ValidationResult resultadoValidacao) =>
            resultadoValidacao.Errors.ForEach(error => Notificar(error.ErrorMessage));

        private void Notificar(string mensagem) => _notificador.Handle(new Notificacao(mensagem));
    }
}