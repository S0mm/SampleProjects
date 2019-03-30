namespace CodeFirst.FluentConfiguration.Models
{
    public class Employee
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; }
        public int CompanyId { get; set; }

        public Address Address { get; set; }
        public virtual Company Company { get; set; }
    }
}
    