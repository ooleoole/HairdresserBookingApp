using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Junctions;

namespace Domain.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        [Required]
        public TimeSpan BaseTime { get; set; }
        [Required]
        public int BasePrice { get; set; }
        [Required, MinLength(2), MaxLength(96)]
        public string Type { get; set; }
        [MaxLength(256)]
        public string Notes { get; set; }


        public IEnumerable<TreatmentHairDresser> Masters { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
