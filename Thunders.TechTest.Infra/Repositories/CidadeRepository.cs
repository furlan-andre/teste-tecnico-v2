using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Cidades;
using Thunders.TechTest.Domain.Cidades.Dtos;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.Infra.Repositories;

public class CidadeRepository : ICidadeRepository
{
    private readonly DatabaseContext _context;

    public CidadeRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<List<Cidade>> ObterCidadesPorEstadoId(int estadoId)
    {
        return await _context.Cidades.Where(c => c.EstadoId == estadoId)
            .Include(c => c.Estado)
            .ToListAsync();
    }

    public async Task<Cidade> ObterCidadePorId(int cidadeId)
    {
        return await _context.Cidades.FirstOrDefaultAsync(c => c.Id == cidadeId);
    }
    
    public async Task<Cidade> ObterCidadeComEstadoPorId(int cidadeId)
    {
        return await _context.Cidades.Where(c => c.EstadoId == cidadeId)
            .Include(c => c.Estado)
            .FirstOrDefaultAsync();
    }
}