using CodeFirst.AddDbSimple.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.AddDbSimple
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
