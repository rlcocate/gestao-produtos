using AutoMapper;
using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Exceptions;
using GestaoProdutos.Core.Repositories.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Application.Commands.InserirProduto
{
    public class InserirProdutoCommandHandler : IRequestHandler<InserirProdutoCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InserirProdutoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(InserirProdutoCommand request, CancellationToken cancellationToken)
        {
            if (request.DataValidade <= request.DataFabricacao)
            {
                throw new BusinessRuleException($"Produto {request.Descricao} está com data de validade menor ou igual a data de fabricação. Favor corrigir para gravar");
            }

            var produtoCadastrado = await _unitOfWork.Produtos.GetByCondition(p => p.Descricao.Equals(request.Descricao));
            if (produtoCadastrado != null)
            {
                throw new AlreadyExistsException("Produto já cadastrado com esta descrição. Favor corrigir e gravar novamente.");
            }

            var produto = _mapper.Map<Produto>(request);
            var result = await _unitOfWork.Produtos.AddAsync(produto);
            await _unitOfWork.CompleteAsync();
            return result.Id;
        }
    }
}
