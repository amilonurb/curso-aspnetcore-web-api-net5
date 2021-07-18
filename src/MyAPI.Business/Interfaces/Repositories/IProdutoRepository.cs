using MyAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAPI.Business.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}