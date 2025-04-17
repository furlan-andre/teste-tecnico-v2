using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;

namespace Thunders.TechTest.Infra.Configurations;

public class QuantidadeTipoPracaConfiguration: IEntityTypeConfiguration<QuantidadeTipoPraca>
{
    public void Configure(EntityTypeBuilder<QuantidadeTipoPraca> builder)
    {
        builder.ToView("QuantidadeTipoPraca");
        builder.HasNoKey();
    }
}