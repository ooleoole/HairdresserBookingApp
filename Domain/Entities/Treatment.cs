using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        [Required]
        public TimeSpan BaseTime { get; set; }
        [Required]
        public int BasePrice { get; set; }
        [MaxLength(256)]
        public string Notes { get; set; }

        [Required]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
