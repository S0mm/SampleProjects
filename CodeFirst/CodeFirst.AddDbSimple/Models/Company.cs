using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.AddDbSimple.Models
{
    [Table("Company")]
    public class Company
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
