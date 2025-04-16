namespace Thunders.TechTest.Domain.Cidades.Dtos;

public interface ICidadeRepository
{
    Task<List<Cidade>> ObterCidadesPorEstadoId(int estadoId);
    Task<Cidade> ObterCidadePorId(int cidadeId);
    Task<Cidade> ObterCidadeComEstadoPorId(int cidadeId);
}