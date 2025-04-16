using Thunders.TechTest.Domain.Tarifas;
using Thunders.TechTest.Domain.Tarifas.Dtos;
using Thunders.TechTest.Infra.Database;

namespace Thunders.TechTest.ApiService.Tarifa.ArmazenadorTarifa;

public class ArmazenadorTarifa : IArmazenadorTarifa
{
    private readonly ITarifaRepository _tarifaRepository;

    public ArmazenadorTarifa(ITarifaRepository tarifaRepository)
    {
        _tarifaRepository = tarifaRepository;
    }

    public async Task<TarifaDto> Armazenar(ArmazenadorTarifaDto armazenadorTarifaDto)
    {
        var tarifa = new Domain.Tarifas.Tarifa(
            armazenadorTarifaDto.PracaId,
            armazenadorTarifaDto.TipoDeVeiculo,
            armazenadorTarifaDto.Valor);

        await _tarifaRepository.AdicionarAsync(tarifa);
        var tarifaDto = new TarifaDto(tarifa.Id, tarifa.PracaId, (int)tarifa.TipoDeVeiculo, tarifa.Valor);
        return tarifaDto;
    }
}