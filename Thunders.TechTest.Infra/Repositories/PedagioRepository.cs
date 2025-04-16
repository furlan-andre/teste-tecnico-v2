using System.Data;
using System.Text;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Thunders.TechTest.Domain;
using Thunders.TechTest.Domain.Pedagios;
using Thunders.TechTest.Domain.Pedagios.Dtos;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.Infra.Repositories;

public class PedagioRepository : IPedagioRepository
{
    private readonly DatabaseContext _context;
    
    public PedagioRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Pedagio pedagio)
    {
        _context.Pedagios.Add(pedagio);
        await _context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Pedagio>> ObterTodos()
    {
        return await _context.Pedagios.AsNoTracking()
            .ToListAsync();
    }
}