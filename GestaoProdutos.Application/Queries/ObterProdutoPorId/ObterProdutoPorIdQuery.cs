using GestaoProdutos.Core.DTO;
using MediatR;

namespace GestaoProdutos.Application.Queries.ObterProdutoPorId
{
    public class ObterProdutoPorIdQuery : IRequest<ProdutoDTO>
    {
        public ObterProdutoPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
