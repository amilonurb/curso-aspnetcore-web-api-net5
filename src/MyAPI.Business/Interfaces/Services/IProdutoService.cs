using MyAPI.Business.Models;
using System;
using System.Threading.Tasks;

namespace MyAPI.Business.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
    }
}
