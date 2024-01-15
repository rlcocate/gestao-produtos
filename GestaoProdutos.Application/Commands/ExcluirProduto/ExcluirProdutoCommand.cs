using GestaoProdutos.Core.Enums;
using MediatR;

namespace GestaoProdutos.Application.Commands.ExcluirProduto
{
    public class ExcluirProdutoCommand : IRequest
    {
        public ExcluirProdutoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public char Situacao { get; } = (char)SituacaoProdutoEnum.Inativo;
    }
}
