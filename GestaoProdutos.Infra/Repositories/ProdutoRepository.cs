using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Enums;
using GestaoProdutos.Core.Repositories;
using GestaoProdutos.Infra.DB.Persistence;
using GestaoProdutos.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoProdutos.Infra.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(GestaoProdutosContext context) : base(context)
        {
        }
        public async override Task<IReadOnlyList<Produto>> GetAllAsync(int limitePorPagina, int numeroDaPagina)
        {
            return await _context.Set<Produto>().Include(p => p.Fornecedor)
                .AsNoTracking()
                .Where(p => p.Situacao == (char)SituacaoProdutoEnum.Ativo)
                .Skip((numeroDaPagina - 1) * limitePorPagina).Take(limitePorPagina)
                .ToListAsync();
        }

        public async Task<Produto> GetByCondition(Expression<Func<Produto, bool>> predicate)
        {
            return await _context.Produtos.Include(p => p.Fornecedor)
                .AsNoTracking()
                .Where(predicate)
                .FirstOrDefaultAsync();
        }
    }
}
