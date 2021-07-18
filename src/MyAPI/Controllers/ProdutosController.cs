using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Business.Interfaces;
using MyAPI.Business.Interfaces.Repositories;
using MyAPI.Business.Interfaces.Services;
using MyAPI.Business.Models;
using MyAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoService _service;
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutosController(INotificador notificador,
                                  IProdutoService service,
                                  IProdutoRepository repository,
                                  IMapper mapper) : base(notificador)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var produto = _mapper.Map<Produto>(produtoViewModel);

            await _service.Adicionar(produto);

            return CustomResponse(produtoViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos() =>
            Ok(_mapper.Map<IEnumerable<ProdutoViewModel>>(await _repository.ObterProdutosFornecedores()));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id) =>
            _mapper.Map<ProdutoViewModel>(await _repository.ObterProdutoFornecedor(id));
    }
}