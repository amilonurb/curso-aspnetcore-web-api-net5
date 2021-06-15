using MyAPI.Business.Interfaces.Repositories;
using MyAPI.Business.Models;
using MyAPI.Data.Contexts;

namespace MyAPI.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MyDbContext context) : base(context) { }
    }
}