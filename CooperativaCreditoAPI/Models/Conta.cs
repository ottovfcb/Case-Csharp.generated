public abstract class Conta
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public int Agencia { get; set; }
    public decimal Saldo { get; protected set; }

    public int CorrentistaId { get; set; }
    public required Correntista Correntista { get; set; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do depósito deve ser positivo.");
        }

        Saldo += valor;
    }
    public abstract void Sacar(decimal valor);

    public abstract void AplicarJuros(decimal taxaJuros);

    protected void ValidarValorPositivo(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor deve ser positivo.");
        }
    }
}