using CooperativaCreditoAPI.Models.Enums;

public class ContaService
{
    private readonly IRepository<Conta> _contaRepository;

    public ContaService(IRepository<Conta> contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public Conta? GetContaById(long id) => _contaRepository.GetById(id);

    public IEnumerable<Conta> GetAllContas() => _contaRepository.GetAll();

    public long AddConta(TipoContaEnum tipoConta, long correntistaId, int numero, int agencia, double saldoInicial, double limite = 0)
    {
        var conta = ContaFactory.CriarConta(tipoConta, correntistaId, numero, agencia, saldoInicial, limite);

        if (conta == null)
        {
            throw new ArgumentException("Tipo de conta inválido.");
        }

        _contaRepository.Add(conta);
        _contaRepository.Save();
        return conta.Id;
    }

    public void UpdateConta(Conta conta)
    {
        _contaRepository.Update(conta);
        _contaRepository.Save();
    }

    public void DeleteConta(long id)
    {
        var conta = _contaRepository.GetById(id);
        if (conta != null)
        {
            _contaRepository.Delete(conta);
            _contaRepository.Save();
        }
    }

    public void Depositar(int contaId, double valor)
    {
        var conta = _contaRepository.GetById(contaId);
        if (conta == null) throw new Exception("Conta não encontrada.");

        conta.Depositar(valor);
        _contaRepository.Update(conta);
        _contaRepository.Save();
    }

    public void Sacar(int contaId, double valor)
    {
        var conta = _contaRepository.GetById(contaId);

        if (conta == null) throw new Exception("Conta não encontrada.");

        try
        {
            conta.Sacar(valor);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            return;
        }
        

        _contaRepository.Update(conta);
        _contaRepository.Save();
    }

    public void AplicarJurosContaPoupanca(int contaId, double taxaJuros)
    {
        var conta = _contaRepository.GetById(contaId) as ContaPoupanca;
        if (conta == null) throw new Exception("Conta poupança não encontrada.");

        try
        {
            conta.AplicarJuros(taxaJuros);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            return;
        }
        
        _contaRepository.Update(conta);
        _contaRepository.Save();
    }

    public void AplicarJurosContaCorrente(int contaId, double taxaJuros)
    {
        var conta = _contaRepository.GetById(contaId) as ContaCorrente;
        if (conta == null) throw new Exception("Conta corrente não encontrada.");

        try
        {
            conta.AplicarJuros(taxaJuros);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            return;
        }


        _contaRepository.Update(conta);
        _contaRepository.Save();
    }
}
