using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Correntista> Correntistas { get; set; }
    public DbSet<Conta> Contas { get; set; }

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
    }
}
