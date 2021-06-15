using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAPI.Business.Models;

namespace MyAPI.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("TB_FORNECEDORES");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome).HasMaxLength(200).IsRequired();

            builder.Property(f => f.Documento).HasMaxLength(14).IsRequired();

            builder.HasOne(f => f.Endereco)
                   .WithOne(e => e.Fornecedor);

            builder.HasMany(f => f.Produtos)
                   .WithOne(p => p.Fornecedor)
                   .HasForeignKey(p => p.FornecedorId);
        }
    }
}