using Contador.Models;
using Microsoft.EntityFrameworkCore;

namespace Contador.Context;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null;
    public DbSet<Person> Persons { get; set; } = null;
    public DbSet<Category> Categories { get; set; } = null;
    public DbSet<Wallet> Wallets { get; set; } = null;
    public DbSet<Debt> Debts { get; set; } = null;
    public DbSet<Installment> Installments { get; set; } = null;
    public DbSet<MoneyTransfer> MoneyTransfer { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Entity<Person>()
            .Property(p => p.Cpf)
            .HasMaxLength(14)
            .IsRequired(false);

        builder.Entity<Category>()
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Entity<Category>()
            .Property(p => p.Description)
            .HasMaxLength(500)
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(
            "Data Source=DESKTOP-LTBAOUJ\\SQLEXPRESS;" +
            "Initial Catalog=ContadorDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True"
            );
}
