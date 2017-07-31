using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Junctions
{
    public class TreatmentPerformer
    {
       
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

        private TreatmentPerformer()
        {
            
        }
    }
}
