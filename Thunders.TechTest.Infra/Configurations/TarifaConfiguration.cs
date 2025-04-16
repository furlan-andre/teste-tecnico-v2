using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Tarifas;

namespace Thunders.TechTest.Infra.Configurations;

public class TarifaConfiguration: IEntityTypeConfiguration<Tarifa>
{
    public void Configure(EntityTypeBuilder<Tarifa> builder)
    {
        builder.ToTable("Tarifa");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Valor)
            .HasColumnType("decimal(6,2)")
            .HasPrecision(6,2)
            .IsRequired();
        builder.Property(p => p.TipoDeVeiculo)
            .HasColumnType("int")
            .IsRequired();
        builder.HasOne(p => p.Praca)
            .WithMany()
            .HasForeignKey(f => f.PracaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}