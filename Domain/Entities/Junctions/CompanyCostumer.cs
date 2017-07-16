using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Junctions
{
    public class CompanyCostumer
    {
        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
