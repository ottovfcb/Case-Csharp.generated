using CooperativaCreditoAPI.Models.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;

public class CorrentistaService
{
    private readonly IRepository<Correntista> _correntistaRepository;

    public CorrentistaService(IRepository<Correntista> correntistaRepository)
    {
        _correntistaRepository = correntistaRepository;
    }

    public Correntista? GetCorrentistaById(long id) => _correntistaRepository.GetById(id);

    public IEnumerable<Correntista> GetAllCorrentistas() => _correntistaRepository.GetAll();

    //public void AddCorrentista(Correntista correntista)
    //{
    //    _correntistaRepository.Add(correntista);
    //    _correntistaRepository.Save();
    //}

    public long AddCorrentista(string cpf, string nome, string endereco, string profissao)
    {
        var correntista = new Correntista
        {
            CPF = cpf,
            Nome = nome,
            Endereco = endereco,
            Profissao = profissao
        };

        _correntistaRepository.Add(correntista);
        _correntistaRepository.Save();
        return correntista.Id;
    }

    public void UpdateCorrentista(Correntista correntista)
    {
        _correntistaRepository.Update(correntista);
        _correntistaRepository.Save();
    }

    public void DeleteCorrentista(long id)
    {
        var correntista = _correntistaRepository.GetById(id);
        if (correntista != null)
        {
            _correntistaRepository.Delete(correntista);
            _correntistaRepository.Save();
        }
    }
}