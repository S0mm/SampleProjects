using CodeFirstTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstTest
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
