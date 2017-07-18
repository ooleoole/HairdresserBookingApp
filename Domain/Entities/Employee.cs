using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Employee
    {
        public int EmploymentNumber { get; set; }
        [Required]
        public int HairDresserId { get; set; }
        public HairDresser HairDresser { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Employment { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }

    }
}
