using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thunders.TechTest.Domain.Cidades;

namespace Thunders.TechTest.Infra.Configurations;

public class CidadeConfiguration: IEntityTypeConfiguration<Cidade>
{
    public void Configure(EntityTypeBuilder<Cidade> builder)
    {
        builder.ToTable("Cidade");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome)
            .HasMaxLength(150)
            .HasColumnType("varchar(150)")
            .IsRequired();
        builder.Property(p => p.EstadoId)
            .HasColumnType("int")
            .IsRequired();
        builder.HasOne(p => p.Estado)
            .WithMany()
            .HasForeignKey(f => f.EstadoId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}