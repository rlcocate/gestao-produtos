using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Repositories.Base;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace GestaoProdutos.Core.Repositories
{
    public interface IProdutoRepository : IRepositoryBaseAsync<Produto>
    {
        Task<Produto> GetByCondition(Expression<Func<Produto, bool>> predicate);
    }
}
