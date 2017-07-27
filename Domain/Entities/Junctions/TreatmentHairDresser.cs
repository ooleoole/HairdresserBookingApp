using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Junctions
{
    public class TreatmentHairDresser
    {
        [Required]
        public int HairDresserId { get; set; }
        public HairDresser HairDresser { get; set; }
        [Required]
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
