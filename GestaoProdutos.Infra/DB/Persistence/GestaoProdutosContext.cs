using GestaoProdutos.Core.Entities;
using GestaoProdutos.Infra.DB.Extensions;
using GestaoProdutos.Infra.DB.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoProdutos.Infra.DB.Persistence
{
    public class GestaoProdutosContext : DbContext
    {
        public GestaoProdutosContext(DbContextOptions options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

            modelBuilder.SeedSuppliers();
            modelBuilder.SeedProducts();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
