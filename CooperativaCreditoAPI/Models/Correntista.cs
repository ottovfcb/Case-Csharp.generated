public class Correntista
{
    public int Id { get; set; }
    public required string CPF { get; set; }
    public required string Nome { get; set; }
    public required string Endereco { get; set; }
    public required string Profissao { get; set; }

    public List<Conta> Contas { get; set; } = new List<Conta>();
}