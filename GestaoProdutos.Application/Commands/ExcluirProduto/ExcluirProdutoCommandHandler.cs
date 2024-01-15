using AutoMapper;
using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Exceptions;
using GestaoProdutos.Core.Repositories.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Application.Commands.ExcluirProduto
{
    public class ExcluirProdutoCommandHandler : IRequestHandler<ExcluirProdutoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExcluirProdutoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            Produto produtoEncontrado = await _unitOfWork.Produtos.GetByCondition(p => p.Id.Equals(request.Id));
            if (produtoEncontrado is null)
            {
                throw new NotFoundException($"Produto com id {request.Id} não encontrado para excluir");
            }

            _mapper.Map(request, produtoEncontrado);
            _unitOfWork.Produtos.LogicalDeleteAsync(produtoEncontrado);
            await _unitOfWork.CompleteAsync();
        }
    }
}
