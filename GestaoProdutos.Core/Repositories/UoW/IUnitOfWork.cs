using System.Threading.Tasks;

namespace GestaoProdutos.Core.Repositories.UoW
{
    public interface IUnitOfWork
    {
        IFornecedorRepository Fornecedores { get; }

        IProdutoRepository Produtos { get; }

        Task<int> CompleteAsync();
    }
}
