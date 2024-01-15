using AutoMapper;
using GestaoProdutos.Application.Commands.EditarProduto;
using GestaoProdutos.Application.Commands.ExcluirProduto;
using GestaoProdutos.Application.Commands.InserirProduto;
using GestaoProdutos.Application.Queries.ObterProdutos;
using GestaoProdutos.Core.DTO;
using GestaoProdutos.Core.Entities;

namespace GestaoProdutos.Application.Mappers
{
    public class ProdutoMapper : Profile
    {
        public ProdutoMapper()
        {
            CreateMap<ObterProdutosQuery, Produto>()
                .ReverseMap();

            CreateMap<InserirProdutoCommand, Produto>()
                .ReverseMap();

            CreateMap<EditarProdutoCommand, Produto>()
                .ReverseMap();

            CreateMap<ExcluirProdutoCommand, Produto>()
                .ReverseMap();

            CreateMap<Produto, ProdutoDTO>()
                .ForMember(d => d.Fornecedor, s => s.MapFrom(p => p.Fornecedor))
                .ForMember(d => d.FornecedorId, s => s.MapFrom(p => p.FornecedorId))
                .ForMember(d => d.FornecedorDescricao, s => s.MapFrom(p => p.Fornecedor.Descricao))
                .ForMember(d => d.FornecedorCnpj, s => s.MapFrom(p => p.Fornecedor.Cnpj))
                .ReverseMap();
        }
    }
}
