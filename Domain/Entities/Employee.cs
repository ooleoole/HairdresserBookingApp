using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Employee : IEmployee
    {
        public int EmploymentNumber { get; set; }
        [Required]
        public int HairDresserId { get; set; }
        public HairDresser HairDresser { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Employment { get; set; }
        public IEnumerable<Treatment> WorkLoad { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
