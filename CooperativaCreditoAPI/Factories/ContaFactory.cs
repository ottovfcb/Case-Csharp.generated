using CooperativaCreditoAPI.Models.Enums;

public static class ContaFactory
{
    public static Conta CriarConta(TipoContaEnum tipo, long correntistaId, int numero, int agencia, double saldoInicial, double limite = 0)
    {
        Conta conta = tipo switch
        {
            TipoContaEnum.Corrente => new ContaCorrente
            {
                Tipo = tipo,
                CorrentistaId = correntistaId,
                Numero = numero,
                Agencia = agencia,
                Limite = limite
            },
            TipoContaEnum.Poupanca => new ContaPoupanca
            {
                Tipo = tipo,
                CorrentistaId = correntistaId,
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