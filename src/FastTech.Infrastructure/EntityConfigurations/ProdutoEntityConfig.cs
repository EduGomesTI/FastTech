using FastTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastTech.Infrastructure.EntityConfigurations;

public class ProdutoEntityConfig : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .IsUnicode(false);
        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasColumnType("varchar(500)")
            .IsUnicode(false);
        builder.Property(p => p.Ativo)
            .IsRequired();
        builder.Property(p => p.Valor)
            .IsRequired()
            .HasPrecision(7, 2);
        builder.Property(p => p.QuantidadeEstoque)
            .IsRequired()
            .HasDefaultValue(0);
        builder.Property(p => p.Cadastro)
            .IsRequired();
        builder.Property(p => p.Tipo)
            .IsRequired();
    }
}
