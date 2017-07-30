using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class HairDresser : IEmployee
    {
        public int EmploymentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SocialSecurityNumber { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

      
        public int? CompanyId { get; set; }
        public Company Employment { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }


    }
}
