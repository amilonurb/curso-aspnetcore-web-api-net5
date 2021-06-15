using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAPI.Business.Models;

namespace MyAPI.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TB_ENDERECOS");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Logradouro).HasMaxLength(200).IsRequired();

            builder.Property(c => c.Numero).HasMaxLength(50).IsRequired();

            builder.Property(c => c.Cep).HasMaxLength(8).IsRequired();

            builder.Property(c => c.Complemento).HasMaxLength(250);

            builder.Property(c => c.Bairro).HasMaxLength(100).IsRequired();

            builder.Property(c => c.Cidade).HasMaxLength(100).IsRequired();

            builder.Property(c => c.Estado).HasMaxLength(50).IsRequired();
        }
    }
}