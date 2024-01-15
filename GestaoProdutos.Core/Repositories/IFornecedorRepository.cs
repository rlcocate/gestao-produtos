using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoProdutos.Core.Repositories
{
    public interface IFornecedorRepository : IRepositoryBaseAsync<Fornecedor>
    {
        Task<IReadOnlyList<Fornecedor>> GetAll();
        Task<Fornecedor> GetById(int id);
    }
}
