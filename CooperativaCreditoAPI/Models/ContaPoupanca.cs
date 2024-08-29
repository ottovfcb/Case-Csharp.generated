public class ContaPoupanca : Conta
{
    public override void Sacar(decimal valor)
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

    public override void AplicarJuros(decimal taxaDeJuros)
    {

        ValidarValorPositivo(taxaDeJuros);
        Saldo += Saldo * taxaDeJuros;
    }
}
