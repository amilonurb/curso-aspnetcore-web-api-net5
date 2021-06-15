using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAPI.Business.Models;

namespace MyAPI.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("TB_PRODUTOS");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Descricao).HasMaxLength(1000).IsRequired();

            builder.Property(p => p.Valor).HasPrecision(10, 2).IsRequired();

            builder.Property(p => p.ImagemBase64).IsRequired();
        }
    }
}