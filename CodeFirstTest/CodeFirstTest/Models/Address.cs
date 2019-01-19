﻿using System.Collections.Generic;

namespace CodeFirstTest.Models
{
    public class Address
    {
        public Address()
        {
            Employees = new List<Employee>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
