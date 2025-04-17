using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Estados;

namespace Thunders.TechTest.Infra.Configurations;

public class EstadoConfiguration: IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estado");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)")
            .IsRequired();
        builder.Property(p => p.Sigla)
            .HasMaxLength(2)
            .HasColumnType("char(2)")
            .IsRequired();
    }
}