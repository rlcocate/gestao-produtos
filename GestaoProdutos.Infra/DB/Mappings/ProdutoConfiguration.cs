using GestaoProdutos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoProdutos.Infra.DB.Mappings
{
    public class ProdutoConfiguration: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);            
            builder.Property(p => p.Id)
                .UseIdentityColumn();

            builder.Property(p => p.Descricao)
                .HasColumnType("VARCHAR")
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(p => p.Situacao)
                .HasColumnType("CHAR")
                .HasMaxLength(1);
            
            builder.Property(p => p.DataFabricacao)
                .HasColumnType("DATETIME");
            
            builder.Property(p => p.DataValidade)
                .HasColumnType("DATETIME");

            builder.HasIndex(p => p.FornecedorId).IsUnique(false);
            //builder
            //    .HasOne(d => d.Fornecedor)
            //    .WithOne(d => d.Produto).HasForeignKey();
                

        }
    }
}
