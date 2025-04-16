using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain;
using Thunders.TechTest.Domain.Cidades;
using Thunders.TechTest.Domain.Estados;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pracas;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PedagioConfiguration());
        modelBuilder.ApplyConfiguration(new PracaConfiguration());
        modelBuilder.ApplyConfiguration(new CidadeConfiguration());
        modelBuilder.ApplyConfiguration(new EstadoConfiguration());
        modelBuilder.ApplyConfiguration(new TarifaConfiguration());
    }
}