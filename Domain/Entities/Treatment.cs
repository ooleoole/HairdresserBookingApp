using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Junctions;
using Domain.Entities.Structs;

namespace Domain.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        public int BasePrice { get; set; }
        public string Type { get; set; }
        public string Notes { get; set; }
        public TimeSpan BaseTime { get; set; }

        public IEnumerable<TreatmentPerformer> Performers { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }


    }
}
