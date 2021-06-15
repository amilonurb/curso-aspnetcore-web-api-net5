using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Business.Interfaces.Services;
using MyAPI.Business.Models;
using MyAPI.ViewModels;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            var produto = _mapper.Map<Produto>(produtoViewModel);

            await _service.Adicionar(produto);

            return CustomResponse(produtoViewModel);
        }
    }
}