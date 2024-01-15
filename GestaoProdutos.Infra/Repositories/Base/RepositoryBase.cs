using GestaoProdutos.Core.Entities.Base;
using GestaoProdutos.Core.Repositories.Base;
using GestaoProdutos.Infra.DB.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoProdutos.Infra.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBaseAsync<T> where T : EntityBase
    {
        protected readonly GestaoProdutosContext _context;

        public RepositoryBase(GestaoProdutosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async virtual Task<IReadOnlyList<T>> GetAllAsync(int limitePorPagina, int numeroDaPagina)
        {
            return await _context.Set<T>().AsNoTracking()
                .Skip((numeroDaPagina - 1) * limitePorPagina)
                .Take(limitePorPagina)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void LogicalDeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}