using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployee
    {
        Company Employment { get; set; }
        int EmploymentNumber { get; set; }
        HairDresser HairDresser { get; set; }
        IEnumerable<Treatment> Treatments { get; set; }
        DateTime WorkingHoursEnd { get; set; }
        DateTime WorkingHoursStart { get; set; }
    }
}