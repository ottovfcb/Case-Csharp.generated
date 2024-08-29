public class ContaCorrente : Conta
{
    public decimal Limite { get; set; }

    public override void Sacar(decimal valor)
    {
        ValidarValorPositivo(valor);

        if (Saldo + Limite >= valor)
        {
            Saldo -= valor;
        }
        else
        {
            throw new InvalidOperationException("Saldo insuficiente.");
        }
    }

    public override void AplicarJuros(decimal taxaJuros)
    {
        if (Saldo < 0)
        {
            Saldo -= Saldo * taxaJuros;
        }
    }
}
