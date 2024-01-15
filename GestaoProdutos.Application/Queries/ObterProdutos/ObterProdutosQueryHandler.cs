using AutoMapper;
using GestaoProdutos.Core.DTO;
using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Repositories.UoW;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Application.Queries.ObterProdutos
{
    public class ObterProdutosQueryHandler : IRequestHandler<ObterProdutosQuery, List<ProdutoDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObterProdutosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProdutoDTO>> Handle(ObterProdutosQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Produto> produtos = await _unitOfWork.Produtos.GetAllAsync(query.LimitePorPagina, query.NumeroDaPagina);
            List<ProdutoDTO> result = _mapper.Map<List<ProdutoDTO>>(produtos);
            return result;
        }
    }
}
