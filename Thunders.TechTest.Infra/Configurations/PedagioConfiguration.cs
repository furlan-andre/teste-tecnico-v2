using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Pedagios;

namespace Thunders.TechTest.Infra.Configurations;

public class PedagioConfiguration : IEntityTypeConfiguration<Pedagio>
{
    public void Configure(EntityTypeBuilder<Pedagio> builder)
    {
        builder.ToTable("Pedagio");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Placa)
            .HasMaxLength(7)
            .IsRequired();
        builder.Property(p => p.ValorPago)
            .HasColumnType("decimal(6,2)")
            .IsRequired();
        builder.Property(p => p.PracaId)
            .IsRequired();
        builder.Property(p => p.TipoDeVeiculo)
            .HasColumnType("integer")
            .IsRequired();
        builder.Property(p => p.DataDaUtilizacao)
            .HasColumnType("datetime")
            .IsRequired();
    }
}