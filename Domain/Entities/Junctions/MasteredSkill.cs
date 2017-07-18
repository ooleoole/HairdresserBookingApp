using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Junctions
{
    public class MasteredSkill
    {
        [Required]
        public int HairDresserId { get; set; }
        public HairDresser HairDresser { get; set; }
        [Required]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
