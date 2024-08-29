using Microsoft.AspNetCore.Authentication;
using System.Security.Principal;

namespace CooperativaCreditoAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Verificar se o banco já está populado
            if (context.Correntistas.Any())
            {
                return;   // DB já foi populado
            }

            // Adicionar clientes
            var correntistas = new Correntista[]
            {
            new() { CPF = "11111111111", Nome = "Maria Silva", Endereco = "Avenida Paulista, 1000", Profissao = "Advogada" },
            new() { CPF = "22222222222", Nome = "Carlos Pereira", Endereco = "Rua das Flores, 200", Profissao = "Médico" },
            new() { CPF = "33333333333", Nome = "Ana Souza", Endereco = "Praça da Sé, 50", Profissao = "Professora" },
            new() { CPF = "44444444444", Nome = "João Oliveira", Endereco = "Rua XV de Novembro, 300", Profissao = "Arquiteto" },
            new() { CPF = "55555555555", Nome = "Beatriz Santos", Endereco = "Rua das Acácias, 150", Profissao = "Designer" }
            };

            context.Correntistas.AddRange(correntistas);
            context.SaveChanges();

            // Adicionar contas
            var contasCorrentes = new ContaCorrente[]
            {
            new() { Tipo = Models.Enums.TipoContaEnum.Corrente, Numero = 67890, Agencia = 1234, CorrentistaId = correntistas[0].Id, Limite = 500.00 },
            new() { Tipo = Models.Enums.TipoContaEnum.Corrente, Numero = 12346, Agencia = 5678, CorrentistaId = correntistas[1].Id, Limite = 1000.00 },
            new() { Tipo = Models.Enums.TipoContaEnum.Corrente, Numero = 54323, Agencia = 5679, CorrentistaId = correntistas[2].Id, Limite = 2000.00 },
            new() { Tipo = Models.Enums.TipoContaEnum.Corrente, Numero = 54324, Agencia = 6780, CorrentistaId = correntistas[3].Id, Limite = 1500.00 },
            new() { Tipo = Models.Enums.TipoContaEnum.Corrente, Numero = 54325, Agencia = 6781, CorrentistaId = correntistas[4].Id, Limite = 2500.00 },
            };

            context.Contas.AddRange(contasCorrentes);
            context.SaveChanges();

            // Adicionar contas
            var contasPoupancas = new ContaPoupanca[]
            {
            new() { Tipo = Models.Enums.TipoContaEnum.Poupanca, Numero = 11111, Agencia = 1111, CorrentistaId = correntistas[0].Id, Limite = null },
            new() { Tipo = Models.Enums.TipoContaEnum.Poupanca, Numero = 22222, Agencia = 2222, CorrentistaId = correntistas[1].Id, Limite = null },
            new() { Tipo = Models.Enums.TipoContaEnum.Poupanca, Numero = 33333, Agencia = 3333, CorrentistaId = correntistas[2].Id, Limite = null },
            new() { Tipo = Models.Enums.TipoContaEnum.Poupanca, Numero = 44444, Agencia = 4444, CorrentistaId = correntistas[3].Id, Limite = null },
            new() { Tipo = Models.Enums.TipoContaEnum.Poupanca, Numero = 55555, Agencia = 5555, CorrentistaId = correntistas[4].Id, Limite = null },
            };

            context.Contas.AddRange(contasPoupancas);
            context.SaveChanges();

        }
    }
}
