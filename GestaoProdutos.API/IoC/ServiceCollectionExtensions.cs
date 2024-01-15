using GestaoProdutos.Core.Repositories;
using GestaoProdutos.Core.Repositories.Base;
using GestaoProdutos.Core.Repositories.UoW;
using GestaoProdutos.Infra.Repositories;
using GestaoProdutos.Infra.Repositories.Base;
using GestaoProdutos.Infra.Repositories.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoProdutos.API.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBaseAsync<>), typeof(RepositoryBase<>));

            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
