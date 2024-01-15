using AutoMapper;
using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Exceptions;
using GestaoProdutos.Core.Repositories.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Application.Commands.EditarProduto
{
    public class EditarProdutoCommandHandler : IRequestHandler<EditarProdutoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditarProdutoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(EditarProdutoCommand request, CancellationToken cancellationToken)
        {
            if (request.DataValidade <= request.DataFabricacao)
            {
                throw new BusinessRuleException($"Produto {request.Descricao} está com data de validade menor ou igual a data de fabricação. Favor corrigir para gravar");
            }

            Produto produtoEncontrado = await _unitOfWork.Produtos.GetByCondition(p => p.Id.Equals(request.Id));
            if (produtoEncontrado is null)
            {
                throw new NotFoundException($"Produto com id {request.Id} não encontrado para editar");
            }

            Produto produtoCadastrado = await _unitOfWork.Produtos.GetByCondition(p => p.Descricao.Equals(request.Descricao));
            if (produtoCadastrado is not null && produtoCadastrado.Id != produtoEncontrado.Id)
            {
                throw new AlreadyExistsException("Já existe um produto cadastrado com esta descrição");
            }

            _mapper.Map(request, produtoEncontrado);
            _unitOfWork.Produtos.UpdateAsync(produtoEncontrado);
            await _unitOfWork.CompleteAsync();
        }
    }
}
