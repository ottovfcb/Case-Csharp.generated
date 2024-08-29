public class ContaDto
{
    public required string TipoConta { get; set; }
    public required Correntista Correntista { get; set; }
    public int Numero { get; set; }
    public int Agencia { get; set; }
    public decimal SaldoInicial { get; set; }
    public decimal Limite { get; set; }
}