using System.Collections.Generic;

namespace CodeFirst.Migrations.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
