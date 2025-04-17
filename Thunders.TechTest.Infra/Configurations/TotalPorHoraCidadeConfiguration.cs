using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;

namespace Thunders.TechTest.Infra.Configurations;

public class TotalPorHoraCidadeConfiguration: IEntityTypeConfiguration<TotalPorHoraCidade>
{
    public void Configure(EntityTypeBuilder<TotalPorHoraCidade> builder)
    {
        builder.ToView("TotalPorHoraCidade");
        builder.HasNoKey();
        builder.Property(p => p.ValorTotal)
            .HasColumnType("decimal(38,2)")
            .HasPrecision(38,2);
    }
}