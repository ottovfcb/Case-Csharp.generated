namespace CooperativaCreditoAPI.Models.DTOs
{
    public class CorrentistaDTO
    {
        public required string CPF { get; set; }
        public required string Nome { get; set; }
        public required string Endereco { get; set; }
        public required string Profissao { get; set; }

        public List<Conta> Contas { get; set; } = new List<Conta>();
    }
}
