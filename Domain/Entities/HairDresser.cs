using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Junctions;

namespace Domain.Entities
{
    public class HairDresser
    {

        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(36)]
        public string FirstName { get; set; }
        [Required, MinLength(2), MaxLength(36)]
        public string LastName { get; set; }
        [Required, MinLength(9), MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(10), MaxLength(13)]
        public string SocialSecurityNumber { get; set; }

        public Address Address { get; set; }
        public IEnumerable<TreatmentHairDresser> MasteredTreatments { get; set; }
        public IEnumerable<Employee> Employments { get; set; }
    }
}
