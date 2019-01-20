using System;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CodeFirstTest;Integrated Security=True;");

            using (var context = new AppContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();


            }



            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
