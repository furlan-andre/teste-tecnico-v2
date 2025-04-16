using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain.Estados;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.Infra.Repositories;

public class EstadoRepository : IEstadoRepository
{
    private readonly DatabaseContext _context;
    
    public EstadoRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<Estado> ObterPorIdAsync(int id)
    {
        return await _context.Estados.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Estado>> ObterTodosAsync()
    {
        return await _context.Estados.ToListAsync();
    }
}