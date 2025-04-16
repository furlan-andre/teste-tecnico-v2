using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Pracas;

namespace Thunders.TechTest.Infra.Configurations;

public class PracaConfiguration: IEntityTypeConfiguration<Praca>
{
    public void Configure(EntityTypeBuilder<Praca> builder)
    {
        builder.ToTable("Praca");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome)
            .HasMaxLength(100)
            .HasColumnType("nvarchar(100)")
            .IsRequired();
        builder.Property(p => p.CidadeId)
            .HasColumnType("int")
            .IsRequired();
        builder.HasOne(p => p.Cidade)
            .WithMany()
            .HasForeignKey(f => f.CidadeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}