public class ContaPoupanca : Conta
{
    public override void Sacar(double valor)
    {
        ValidarValorPositivo(valor);

        if (Saldo >= valor)
        {
            Saldo -= valor;
        }
        else
        {
            throw new InvalidOperationException("Saldo insuficiente.");
        }
    }

    public override void AplicarJuros(double taxaJuros)
    {
        ValidarValorPositivo(taxaJuros);
        Saldo += Saldo * taxaJuros;
    }
}
