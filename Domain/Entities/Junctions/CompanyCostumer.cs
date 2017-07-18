using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Junctions
{
    public class CompanyCostumer
    {
        [Required]
        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
