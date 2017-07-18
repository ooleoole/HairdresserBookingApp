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

        public IEnumerable<MasteredSkill> Masters { get; set; } = new List<MasteredSkill>();
        public IEnumerable<Treatment> Treatments { get; set; } = new List<Treatment>();
    }
}
