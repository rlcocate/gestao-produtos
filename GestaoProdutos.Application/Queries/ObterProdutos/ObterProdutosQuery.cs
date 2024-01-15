using GestaoProdutos.Core.DTO;
using MediatR;
using System.Collections.Generic;

namespace GestaoProdutos.Application.Queries.ObterProdutos
{
    public class ObterProdutosQuery : IRequest<List<ProdutoDTO>>
    {
        public ObterProdutosQuery(int limitePorPagina = 5, int numeroDaPagina = 1)
        {
            LimitePorPagina = limitePorPagina == 0 ? 5 : limitePorPagina;
            NumeroDaPagina = numeroDaPagina == 0 ? 1 : numeroDaPagina;
        }

        public int LimitePorPagina { get; set; }

        public int NumeroDaPagina { get; set; }
    }
}
