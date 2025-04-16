using System.Text.RegularExpressions;
using Thunders.TechTest.Domain.Pedagios.Enums;

namespace Thunders.TechTest.Domain.Pedagios;

public class Pedagio
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public decimal ValorPago { get; set; }
    public int PracaId { get; set; }
    public TipoDeVeiculo TipoDeVeiculo { get; set; }
    public DateTime DataDaUtilizacao { get; set; }
    
    protected Pedagio() { }
    public  Pedagio(string placa, int pracaId, int tipoDeVeiculo,decimal valorPago, DateTime dataDaUtilizacao) {
        
        ValidarDadosObrigatorios(placa, pracaId, tipoDeVeiculo);
        
        DataDaUtilizacao = dataDaUtilizacao;
        Placa = placa;
        ValorPago = valorPago;
        TipoDeVeiculo = (TipoDeVeiculo) tipoDeVeiculo;
        PracaId = pracaId;
    }

    private void ValidarDadosObrigatorios(string placa, int pracaId, int tipoDeVeiculo)
    {
        if(!ValidarPlaca(placa))
            throw new ArgumentException("Placa inválida");
        
        if(pracaId <= 0)
            throw new ArgumentException("Praça inválida");
        
        if(!Enum.IsDefined(typeof(TipoDeVeiculo), tipoDeVeiculo))
            throw new ArgumentException("Tipo de veículo inválido");
    }
    
    private static bool ValidarPlaca(string placa)
    {
        Regex regexPlaca = new Regex(@"^[A-Z]{3}[0-9]{4}$|^[A-Z]{3}[0-9]{1}[A-Z]{1}[0-9]{2}$", RegexOptions.Compiled);
        if (string.IsNullOrWhiteSpace(placa) || placa.Length != 7)
            return false;

        return regexPlaca.IsMatch(placa);
    }
}