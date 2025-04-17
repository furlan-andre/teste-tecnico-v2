using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Relatorios.Ranqueamentos;

namespace Thunders.TechTest.Infra.Configurations;

public class RanqueamentoMensalPorPracaConfiguration: IEntityTypeConfiguration<RanqueamentoMensalPorPraca>
{
    public void Configure(EntityTypeBuilder<RanqueamentoMensalPorPraca> builder)
    {
        builder.ToView("RanqueamentoMensalPorPraca");
        builder.HasNoKey();
        builder.Property(p => p.ValorTotal)
            .HasColumnType("decimal(38,2)")
            .HasPrecision(38,2);
        builder.Property(p => p.Ordem)
            .HasColumnType("bigint");
    }
}