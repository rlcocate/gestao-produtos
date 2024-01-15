using GestaoProdutos.Core.Entities;
using GestaoProdutos.Core.Enums;
using MediatR;
using System;

namespace GestaoProdutos.Application.Commands.InserirProduto
{
    public class InserirProdutoCommand : IRequest<int>
    {
        public InserirProdutoCommand(
            string descricao,
            char situacao,
            DateTime? dataFabricacao,
            DateTime? dataValidade,
            int fornecedorId
        )
        {
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            FornecedorId = fornecedorId;
        }

        public string Descricao { get; set; }

        public char Situacao { get; set; }

        public DateTime? DataFabricacao { get; set; }

        public DateTime? DataValidade { get; set; }

        public int FornecedorId { get; set; }
    }
}
