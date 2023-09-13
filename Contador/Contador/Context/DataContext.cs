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
