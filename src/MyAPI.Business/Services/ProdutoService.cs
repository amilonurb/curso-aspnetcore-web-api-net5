using MyAPI.Business.Interfaces;
using MyAPI.Business.Interfaces.Repositories;
using MyAPI.Business.Interfaces.Services;
using MyAPI.Business.Models;
using MyAPI.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace MyAPI.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository,
                              INotificador notificador) : base(notificador) => _repository = repository;

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _repository.Adicionar(produto);
        }

        public void Dispose()
        {
            _repository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}