using System;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.ScheduleObjects;

namespace Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public bool IsCancelled { get; set; }
        [Required]
        public DateTime DateAndTime { get; set; }
        public int TotalPrice { get; set; }
        public TimeSpan TotalTime { get; set; }
        public bool EmployeeIsNotified { get; set; }
        public TimeSpan ExtraTime { get; set; }
        public int ExtraCost { get; set; }
        [MaxLength(256)]
        public string Notes { get; set; }
        [Required]
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        [Required]
        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }



    }
}
