using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Junctions;
using Domain.Enums;

namespace Domain.Entities
{
    public class Costumer
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        [Required, MinLength(2), MaxLength(36)]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(9), MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public bool NotifyExtraCostOrTime { get; set; }
        [MaxLength(256)]
        public string Notes { get; set; }

        [Required]
        public int AddressId { get; set; }
        [Required]
        public Address Address { get; set; }

        public IEnumerable<CompanyCostumer> Companies { get; set; }= new List<CompanyCostumer>();

    }
}
