using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Entities.Junctions;

namespace Domain.Interfaces
{
    public interface IEmployee
    {
        Company Employment { get; set; }
        int EmploymentNumber { get; set; }
        
        IEnumerable<TreatmentPerformer> Treatments { get; set; }
        
    }
}