using GestaoProdutos.Core.Entities.Base;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GestaoProdutos.Core.Entities
{
    public class Fornecedor : EntityBase
    {
        public Fornecedor()
        {
        }

        public Fornecedor(string descricao, string cnpj)
        {
            Descricao = descricao;
            Cnpj = cnpj;
        }

        public string Descricao { get; set; }

        public string Cnpj { get; set; }
#nullable enable
        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }
    }
}
