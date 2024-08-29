using Microsoft.EntityFrameworkCore;
public class ContaRepository : IRepository<Conta>
{
    private readonly AppDbContext _context;

    public ContaRepository(AppDbContext context)
    {
        _context = context;
    }

    public Conta? GetById(long id) => _context.Contas.Find(id);
    //public IEnumerable<Conta> GetAll() => _context.Contas.Include(c => c.Id).ToList();
    public IEnumerable<Conta> GetAll() => _context.Contas.ToList();
    public void Add(Conta entity) => _context.Contas.Add(entity);
    public void Update(Conta entity) => _context.Contas.Update(entity);
    public void Delete(Conta entity) => _context.Contas.Remove(entity);
    public void Save() => _context.SaveChanges();
}
