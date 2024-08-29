public class ContaCorrente : Conta
{
    public override void Sacar(double valor)
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

    public override void AplicarJuros(double taxaJuros)
    {
        ValidarValorPositivo(taxaJuros);

        if (Saldo < 0)
        {
            Saldo += Saldo * taxaJuros;
        }
    }
}
