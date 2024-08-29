using CooperativaCreditoAPI.Models.Enums;

public class ContaDto
{
    public required TipoContaEnum Tipo { get; set; }
    public required long CorrentistaId { get; set; }
    public int Numero { get; set; }
    public int Agencia { get; set; }
    public double SaldoInicial { get; set; }
    public double Limite { get; set; }
}