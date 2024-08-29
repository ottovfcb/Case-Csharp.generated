using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Correntista> Correntistas { get; set; }
    public DbSet<Conta> Contas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("CooperativaCreditoDB");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conta>()
            .HasDiscriminator<string>("TipoConta")
            .HasValue<ContaCorrente>("Corrente")
            .HasValue<ContaPoupanca>("Poupanca");

        modelBuilder.Entity<Conta>().HasKey(m => m.Id);
        modelBuilder.Entity<Correntista>().HasKey(m => m.Id);
        modelBuilder.Entity<ContaCorrente>()
            .Property(c => c.Limite)
            .IsRequired(false);
    }
}
