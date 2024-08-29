using CooperativaCreditoAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public abstract class Conta
{
    [Key]
    public long Id { get; set; }
    public TipoContaEnum Tipo { get; set; }
    public int Numero { get; set; }
    public int Agencia { get; set; }
    public double Saldo { get; protected set; }
    public required long CorrentistaId { get; set; }
    public double? Limite { get; set; }

    public Conta(){}

    [JsonConstructor]
    public Conta(TipoContaEnum tipo, int numero, int agencia, double saldo, long correntistaId, double? limite)
    {
        Tipo = tipo;
        Numero = numero;
        Agencia = agencia;
        Saldo = saldo;
        CorrentistaId = correntistaId;
        Limite = limite;
    }

    public void Depositar(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do depósito deve ser positivo.");
        }

        Saldo += valor;
    }
    public abstract void Sacar(double valor);

    public abstract void AplicarJuros(double taxaJuros);

    protected void ValidarValorPositivo(double valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor deve ser positivo.");
        }
    }
}