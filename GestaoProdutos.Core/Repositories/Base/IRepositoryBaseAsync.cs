using GestaoProdutos.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoProdutos.Core.Repositories.Base
{
    public interface IRepositoryBaseAsync<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync(int limitePorPagina = 5, int numeroDaPagina = 1);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T> AddAsync(T entity);

        void UpdateAsync(T entity);

        void LogicalDeleteAsync(T entity);
    }
}
