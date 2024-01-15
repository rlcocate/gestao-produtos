using MediatR;
using System;

namespace GestaoProdutos.Application.Commands.EditarProduto
{
    public class EditarProdutoCommand : IRequest
    {
        public EditarProdutoCommand(
            int id,
            string descricao,
            char? situacao,
            DateTime? dataFabricacao,
            DateTime? dataValidade,
            int? fornecedorId
        )
        {
            Id = id;
            Descricao = descricao;
            Situacao = situacao ?? null;
            DataFabricacao = dataFabricacao ?? null;
            DataValidade = dataValidade ?? null;
            FornecedorId = fornecedorId ?? null;
        }

        public int Id { get; set; }

        public string Descricao { get; set; }

        public char? Situacao { get; set; }

        public DateTime? DataFabricacao { get; set; }

        public DateTime? DataValidade { get; set; }

        public int? FornecedorId { get; set; }
    }
}
