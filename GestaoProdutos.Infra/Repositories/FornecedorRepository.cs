using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Repositories;
using GestaoProdutos.Infra.DB.Persistence;
using GestaoProdutos.Infra.Repositories.Base;

namespace GestaoProdutos.Infra.Repositories
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(GestaoProdutosContext context) : base(context)
        {
        }
    }
}
