using Contador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Contador.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null;

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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
                "Data Source=Localhost;" +
                "Initial Catalog=ContadorDB;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True"
                );
    }
}
