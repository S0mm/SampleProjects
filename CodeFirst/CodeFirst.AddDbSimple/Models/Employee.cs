using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.AddDbSimple.Models
{
    [Table("Employee")]
    public class Employee
    {   
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        public int? AddressId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Company Company { get; set; }
    }
}
