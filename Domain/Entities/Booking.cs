using System;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.ScheduleObjects;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime DateAndTime { get; set; }

        public int TotalPrice => Treatment.BasePrice + ExtraCost;
        public TimeSpan TotalTime => Treatment.BaseTime + ExtraTime;
        
        public TimeSpan ExtraTime { get; set; }
        public int ExtraCost { get; set; }

        public bool EmployeeIsNotified { get; set; }
        [MaxLength(256)]
        public string Notes { get; set; }

        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }

        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int PerformerId { get; set; }
        public Employee Performer { get; set; }



    }
}
