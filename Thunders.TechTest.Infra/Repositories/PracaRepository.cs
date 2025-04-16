using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Pracas;
using Thunders.TechTest.Domain.Pracas.Dtos;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.Infra.Repositories;

public class PracaRepository : IPracaRepository
{
    private readonly DatabaseContext _context;

    public PracaRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<Praca> ObterPorIdAsync(int pracaId)
    {
        var retorno = await _context.Pracas.Where(x => x.Id == pracaId).FirstOrDefaultAsync();
        return retorno;
    }

    public async Task<Praca> ObterPorIdComCidadeAsync(int pracaId)
    {
        var retorno = await _context.Pracas.Where(x => x.Id == pracaId)
            .Include(p => p.Cidade)
            .FirstOrDefaultAsync();
        return retorno;
    }

    public async Task<List<Praca>> ObterTodosComCidadeAsync()
    {
        return await _context.Pracas.AsNoTracking()
                .Include(p => p.Cidade)
                .ThenInclude(e => e.Estado)
                .ToListAsync();
    }

    public async Task<int> ObterQuantidadeDePracas()
    {
        var query = _context.Pracas.AsNoTracking();
        return await query.CountAsync();
    }
}