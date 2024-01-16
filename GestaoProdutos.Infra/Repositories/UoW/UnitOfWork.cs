using GestaoProdutos.Core.Repositories;
using GestaoProdutos.Core.Repositories.UoW;
using GestaoProdutos.Infra.DB.Persistence;
using System;
using System.Threading.Tasks;

namespace GestaoProdutos.Infra.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GestaoProdutosContext _context;

        public IFornecedorRepository Fornecedores { get; }

        public IProdutoRepository Produtos { get; }

        public UnitOfWork(
            GestaoProdutosContext context,
            IFornecedorRepository fornecedores,
            IProdutoRepository produtos
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Fornecedores = fornecedores;
            Produtos = produtos;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            IsDisposing(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void IsDisposing(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
