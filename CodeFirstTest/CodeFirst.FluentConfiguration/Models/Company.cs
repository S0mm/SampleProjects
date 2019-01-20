using System.Collections.Generic;

namespace CodeFirst.FluentConfiguration.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
