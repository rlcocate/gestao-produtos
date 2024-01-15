using AutoMapper;
using GestaoProdutos.Core.DTO;
using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Repositories.UoW;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Application.Queries.ObterFornecedor
{
    public class ObterFornecedoresQueryHandler : IRequestHandler<ObterFornecedoresQuery, List<FornecedorDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObterFornecedoresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FornecedorDTO>> Handle(ObterFornecedoresQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Fornecedor> fornecedores = await _unitOfWork.Fornecedores.GetAllAsync(request.LimitePorPagina, request.NumeroDaPagina);
            List<FornecedorDTO> result = _mapper.Map<List<FornecedorDTO>>(fornecedores);
            return result;
        }
    }
}
