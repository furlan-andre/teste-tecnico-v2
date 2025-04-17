using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Cidades;
using Thunders.TechTest.Domain.Estados;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pracas;
using Thunders.TechTest.Domain.Relatorios.QuantidadeTipoPraca;
using Thunders.TechTest.Domain.Relatorios.Ranqueamentos;
using Thunders.TechTest.Domain.Relatorios.TotalPorHoraCidades;
using Thunders.TechTest.Domain.Tarifas;
using Thunders.TechTest.Infra.Configurations;

namespace Thunders.TechTest.Infra.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<Pedagio> Pedagios { get; set; }
    public DbSet<Praca> Pracas { get; set; }
    public DbSet<Cidade> Cidades { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Tarifa> Tarifas { get; set; }
    public DbSet<RanqueamentoMensalPorPraca> RanqueamentoMensalPorPracas { get; set; }
    public DbSet<QuantidadeTipoPraca> QuantidadeTipoPracas { get; set; }
    public DbSet<TotalPorHoraCidade> TotalPorHoraCidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PedagioConfiguration());
        modelBuilder.ApplyConfiguration(new PracaConfiguration());
        modelBuilder.ApplyConfiguration(new CidadeConfiguration());
        modelBuilder.ApplyConfiguration(new EstadoConfiguration());
        modelBuilder.ApplyConfiguration(new TarifaConfiguration());
        modelBuilder.ApplyConfiguration(new RanqueamentoMensalPorPracaConfiguration());
        modelBuilder.Entity<RanqueamentoMensalPorPraca>().Metadata.SetIsTableExcludedFromMigrations(true);
        modelBuilder.ApplyConfiguration(new QuantidadeTipoPracaConfiguration());
        modelBuilder.Entity<QuantidadeTipoPraca>().Metadata.SetIsTableExcludedFromMigrations(true);
        modelBuilder.ApplyConfiguration(new TotalPorHoraCidadeConfiguration());
        modelBuilder.Entity<TotalPorHoraCidade>().Metadata.SetIsTableExcludedFromMigrations(true);
    }
}