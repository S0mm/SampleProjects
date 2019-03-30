using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.AddDbSimple.Models
{
    [Table("Address")] // by default is 'Addresses'
    public class Address
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; }

        [Required, MaxLength(100)]
        public string Line1 { get; set; }

        [MaxLength(100)]
        public string Line2 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public Address()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Employees = new List<Employee>();
        }
    }
}
