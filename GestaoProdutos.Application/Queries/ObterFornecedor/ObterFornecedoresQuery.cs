using GestaoProdutos.Core.DTO;
using MediatR;
using System.Collections.Generic;

namespace GestaoProdutos.Application.Queries.ObterFornecedor
{
    public class ObterFornecedoresQuery : IRequest<List<FornecedorDTO>>
    {
        public ObterFornecedoresQuery(int limitePorPagina, int numeroDaPagina)
        {
            LimitePorPagina = limitePorPagina == 0 ? 5 : limitePorPagina;
            NumeroDaPagina = numeroDaPagina == 0 ? 1 : numeroDaPagina;
        }

        public int LimitePorPagina { get; set; }

        public int NumeroDaPagina { get; set; }
    }
}
