using Microsoft.EntityFrameworkCore;
using MyAPI.Business.Interfaces.Repositories;
using MyAPI.Business.Models;
using MyAPI.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MyDbContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores() =>
            await _context.Produtos.AsNoTracking()
                                   .Include(f => f.Fornecedor)
                                   .OrderBy(p => p.Nome)
                                   .ToListAsync();

        public async Task<Produto> ObterProdutoFornecedor(Guid id) =>
            await _context.Produtos.AsNoTracking()
                                   .Include(f => f.Fornecedor)
                                   .FirstOrDefaultAsync(p => p.Id == id);
    }
}