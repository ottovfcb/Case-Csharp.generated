using Microsoft.EntityFrameworkCore;
public class CorrentistaRepository : IRepository<Correntista>
{
    private readonly AppDbContext _context;

    public CorrentistaRepository(AppDbContext context)
    {
        _context = context;
    }

    //public Correntista? GetById(long id) => _context.Correntistas.Find(id);
    public Correntista? GetById(long id)
    {
        return _context.Correntistas
                       .Include(c => c.Contas) // Inclui as contas associadas
                       .FirstOrDefault(c => c.Id == id);
    }
    public IEnumerable<Correntista> GetAll() => _context.Correntistas.Include(c => c.Contas).ToList();
    public void Add(Correntista entity) => _context.Correntistas.Add(entity);
    public void Update(Correntista entity) => _context.Correntistas.Update(entity);
    public void Delete(Correntista entity) => _context.Correntistas.Remove(entity);
    public void Save() => _context.SaveChanges();
}
