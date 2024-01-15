using AutoMapper;
using GestaoProdutos.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoProdutos.API.Extensions
{
    public static class AutoMapperExtensions
    {

        public static IServiceCollection AutoMapperConfiguration(this IServiceCollection services)
        {
            MapperConfiguration config = new(config =>
            {
                config.AddProfile<ProdutoMapper>();
                config.AddProfile<FornecedorMapper>();
            });

            IMapper mapper = config.CreateMapper();

            return services.AddSingleton(mapper);
        }
    }
}
