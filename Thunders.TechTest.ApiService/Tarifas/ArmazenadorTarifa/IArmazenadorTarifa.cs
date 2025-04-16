using Thunders.TechTest.Domain.Tarifas.Dtos;

namespace Thunders.TechTest.ApiService.Tarifa.ArmazenadorTarifa;

public interface IArmazenadorTarifa
{
    Task<TarifaDto> Armazenar(ArmazenadorTarifaDto armazenadorTarifaDto);
}