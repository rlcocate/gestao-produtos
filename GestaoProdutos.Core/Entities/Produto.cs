using GestaoProdutos.Core.Entities.Base;
using GestaoProdutos.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestaoProdutos.Core.Entities
{
    public class Produto : EntityBase
    {

        public Produto()
        {
        }

        public Produto(
            string descricao, 
            char situacao, 
            DateTime dataFabricacao, 
            DateTime dataValidade,
            int fornecedorId,
            Fornecedor fornecedor)
        {
            Descricao = descricao;
            Situacao = (char)situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            FornecedorId = fornecedorId;
            Fornecedor = fornecedor;
        }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("situacao")]
        public char Situacao { get; set; }

        [JsonPropertyName("dataFabricacao")]
        public DateTime DataFabricacao { get; set; }
        
        [JsonPropertyName("dataValidade")]
        public DateTime DataValidade { get; set; }

        //[ForeignKey("Fornecedor")]
#nullable enable
        [JsonPropertyName("fornecedorId")]
        public int FornecedorId { get; set; }

        [JsonPropertyName("fornecedor")]
        public Fornecedor? Fornecedor { get; set; }
    }
}
