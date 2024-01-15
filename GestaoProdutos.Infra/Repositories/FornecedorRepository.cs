using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Repositories;
using GestaoProdutos.Infra.DB.Persistence;
using GestaoProdutos.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoProdutos.Infra.Repositories
{
    public class FornecedorRepository : RepositoryBase<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(GestaoProdutosContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<Fornecedor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
