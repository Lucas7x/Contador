using Contador.Models;
using Microsoft.EntityFrameworkCore;

namespace Contador.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
                "Data Source=Localhost;" +
                "Initial Catalog=ContadorDB;" +
                "Integrated Security=True"
                );
    }
}
