using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Junctions
{
    public class WorksAt
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
