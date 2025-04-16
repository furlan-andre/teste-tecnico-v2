using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pedagios.Enums;
using Thunders.TechTest.Domain.Tarifas;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.Infra.Repositories;

public class TarifaRepository : ITarifaRepository
{
    private readonly DatabaseContext _context;

    public TarifaRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Tarifa tarifa)
    {
        _context.Tarifas.Add(tarifa);
        await _context.SaveChangesAsync();
    }

    public async Task<Tarifa> ObterPorPracaETipoDeVeiculoAsync(int pracaId, int tipoDeVeiculo)
    {
        var retorno =
            await _context.Tarifas.Where(x => 
                    x.PracaId == pracaId &&
                    x.TipoDeVeiculo == (TipoDeVeiculo)tipoDeVeiculo)
            .FirstOrDefaultAsync();
        return retorno;
    }
    
    public async Task<Tarifa> ObterPorIdAsync(int tarifaId)
    {
        var retorno = await _context.Tarifas.Where(x => x.Id == tarifaId).FirstOrDefaultAsync();
        return retorno;
    }

    public async Task<List<Tarifa>> ObterPorPracaIdAsync(int pracaId)
    {
        var retorno = await _context.Tarifas.Where(x => x.PracaId == pracaId).ToListAsync();
        return retorno;
    }

}