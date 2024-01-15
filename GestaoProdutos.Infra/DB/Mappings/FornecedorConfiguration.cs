using GestaoProdutos.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoProdutos.Infra.DB.Mappings
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).UseIdentityColumn();            
            builder.Property(f => f.Descricao).HasColumnType("VARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(f => f.Cnpj).HasColumnType("VARCHAR").HasMaxLength(14).IsRequired();
        }
    }
}
