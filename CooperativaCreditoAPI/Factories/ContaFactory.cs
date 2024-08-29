public static class ContaFactory
{
    public static Conta CriarConta(string tipoConta, Correntista correntista, int numero, int agencia, decimal saldoInicial, decimal limite = 0)
    {
        Conta conta = tipoConta.ToLower() switch
        {
            "corrente" => new ContaCorrente
            {
                Correntista = correntista,
                Numero = numero,
                Agencia = agencia,
                Limite = limite
            },
            "poupanca" => new ContaPoupanca
            {
                Correntista = correntista,
                Numero = numero,
                Agencia = agencia
            },
            _ => throw new ArgumentException("Tipo de conta inválido."),
        };

        // Fazer um depósito inicial para ajustar o saldo
        conta.Depositar(saldoInicial);

        return conta;
    }
}