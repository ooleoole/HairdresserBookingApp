using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Junctions
{
    public class BookingManagement
    {
        public bool CancelledBooking { get; set; }
        [Required]
        public int HairDresserId { get; set; }
        public HairDresser HairDresser { get; set; }
        [Required]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
