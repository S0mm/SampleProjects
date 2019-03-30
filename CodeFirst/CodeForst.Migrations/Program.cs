using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CodeFirst.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Console.ReadLine();
        }
    }

    // The DesignTimeDbContextFactory class is needed because EF Core Migrations are launched from console app.
    // If use web application, just add 'services.AddDbContext<AppContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:StorageDB"]));'
    // to ConfigureServices method
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppContext>();

            var connectionString = configuration.GetConnectionString("StorageDB");

            builder.UseSqlServer(connectionString);

            return new AppContext(builder.Options);
        }
    }
}
