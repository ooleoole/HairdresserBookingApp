using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Junctions;

namespace Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(9), MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public Address Address { get; set; }

        public IEnumerable<CompanyCostumer> Costumers { get; set; }

    }
}

