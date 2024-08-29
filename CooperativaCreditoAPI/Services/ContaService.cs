public class ContaService
{
    private readonly IRepository<Conta> _contaRepository;

    public ContaService(IRepository<Conta> contaRepository)
    {
        _contaRepository = contaRepository;
    }

    public Conta? GetContaById(int id) => _contaRepository.GetById(id);

    public IEnumerable<Conta> GetAllContas() => _contaRepository.GetAll();

    public void AddConta(string tipoConta, Correntista correntista, int numero, int agencia, decimal saldoInicial, decimal limite = 0)
{
    var conta = ContaFactory.CriarConta(tipoConta, correntista, numero, agencia, saldoInicial, limite);

    if (conta == null)
    {
        throw new ArgumentException("Tipo de conta inválido.");
    }

    _contaRepository.Add(conta);
    _contaRepository.Save();
}

    public void UpdateConta(Conta conta)
    {
        _contaRepository.Update(conta);
        _contaRepository.Save();
    }

    public void DeleteConta(int id)
    {
        var conta = _contaRepository.GetById(id);
        if (conta != null)
        {
            _contaRepository.Delete(conta);
            _contaRepository.Save();
        }
    }

    public void Depositar(int contaId, decimal valor)
    {
        var conta = _contaRepository.GetById(contaId);
        if (conta == null) throw new Exception("Conta não encontrada.");

        conta.Depositar(valor);
        _contaRepository.Update(conta);
        _contaRepository.Save();
    }

    public void Sacar(int contaId, decimal valor)
    {
        var conta = _contaRepository.GetById(contaId);
        if (conta == null) throw new Exception("Conta não encontrada.");

        conta.Sacar(valor);
        _contaRepository.Update(conta);
        _contaRepository.Save();
    }

    public void AplicarJurosContaPoupanca(int contaId, decimal taxaJuros)
    {
        var conta = _contaRepository.GetById(contaId) as ContaPoupanca;
        if (conta == null) throw new Exception("Conta poupança não encontrada.");

        conta.AplicarJuros(taxaJuros);
        _contaRepository.Update(conta);
        _contaRepository.Save();
    }

    public void AplicarJurosContaCorrente(int contaId, decimal taxaJuros)
    {
        var conta = _contaRepository.GetById(contaId) as ContaCorrente;
        if (conta == null) throw new Exception("Conta corrente não encontrada.");

        conta.AplicarJuros(taxaJuros);
        _contaRepository.Update(conta);
        _contaRepository.Save();
    }
}
