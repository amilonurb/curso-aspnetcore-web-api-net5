using Microsoft.EntityFrameworkCore;
using MyAPI.Business.Interfaces.Repositories;
using MyAPI.Business.Models;
using MyAPI.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyAPI.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MyDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) =>
            await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        public async Task<TEntity> ObterPorId(Guid id) => await _dbSet.FindAsync(id);

        public async Task<IList<TEntity>> ObterTodos() => await _dbSet.ToListAsync();

        public async Task Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);

            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);

            await SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });

            await SaveChanges();
        }

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();

        public void Dispose() => _context?.Dispose();
    }
}