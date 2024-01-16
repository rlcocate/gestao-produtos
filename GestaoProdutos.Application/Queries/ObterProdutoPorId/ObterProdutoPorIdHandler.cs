using AutoMapper;
using GestaoProdutos.Core.DTO;
using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Enums;
using GestaoProdutos.Core.Repositories.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Application.Queries.ObterProdutoPorId
{
    public class ObterProdutoPorIdHandler : IRequestHandler<ObterProdutoPorIdQuery, ProdutoDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObterProdutoPorIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> Handle(ObterProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            Produto produto = await _unitOfWork.Produtos.GetByCondition(p => p.Id.Equals(request.Id) && p.Situacao.Equals((char)SituacaoProdutoEnum.Ativo));
            ProdutoDTO result = _mapper.Map<ProdutoDTO>(produto);
            return result;
        }
    }
}
