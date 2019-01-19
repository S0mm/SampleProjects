﻿namespace CodeFirstTest.Models
{
    public class Employee
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int CompanyId { get; set; }

        public Address Address { get; set; }
        public Company Company { get; set; }
    }
}
    