using AutoMapper;
using GestaoProdutos.Application.Queries.ObterFornecedor;
using GestaoProdutos.Core.DTO;
using GestaoProdutos.Core.Entities;

namespace GestaoProdutos.Application.Mappers
{
    public class FornecedorMapper : Profile
    {
        public FornecedorMapper()
        {
            CreateMap<ObterFornecedoresQuery, Fornecedor>();
            CreateMap<Fornecedor, FornecedorDTO>();
        }

    }
}
