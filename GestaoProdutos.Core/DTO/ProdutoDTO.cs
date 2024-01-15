using GestaoProdutos.Core.Entities;

namespace GestaoProdutos.Core.DTO
{
    public class ProdutoDTO : Produto
    {
        public string FornecedorDescricao { get; set; }

        public string FornecedorCnpj { get; set; }
    }
}
