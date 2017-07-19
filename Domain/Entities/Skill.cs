using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Junctions;

namespace Domain.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        [Required, MinLength(2), MaxLength(96)]
        public string Type { get; set; }

        [Required]
        public int MasterId { get; set; }
        public HairDresser Master { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; } = new List<Treatment>();
    }
}
