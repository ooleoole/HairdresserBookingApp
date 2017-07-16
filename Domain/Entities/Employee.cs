using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(36)]
        public string Name { get; set; }
        [Required, MinLength(9), MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(10), MaxLength(13)]
        public string SocialSecurityNumber { get; set; }
        [Required]
        public DateTime WorkingHoursStart { get; set; }
        [Required]
        public DateTime WorkingHoursEnd { get; set; }


        public Address Address { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        
    }
}
