public class CorrentistaService
{
    private readonly IRepository<Correntista> _correntistaRepository;

    public CorrentistaService(IRepository<Correntista> correntistaRepository)
    {
        _correntistaRepository = correntistaRepository;
    }

    public Correntista? GetCorrentistaById(int id) => _correntistaRepository.GetById(id);

    public IEnumerable<Correntista> GetAllCorrentistas() => _correntistaRepository.GetAll();

    public void AddCorrentista(Correntista correntista)
    {
        _correntistaRepository.Add(correntista);
        _correntistaRepository.Save();
    }

    public void UpdateCorrentista(Correntista correntista)
    {
        _correntistaRepository.Update(correntista);
        _correntistaRepository.Save();
    }

    public void DeleteCorrentista(int id)
    {
        var correntista = _correntistaRepository.GetById(id);
        if (correntista != null)
        {
            _correntistaRepository.Delete(correntista);
            _correntistaRepository.Save();
        }
    }
}