using Domain.Enums;

namespace Domain.Entities.Junctions
{
    public class BookingManagement
    {
        public BookingAction Action { get; set; }
        public int HairDresserId { get; set; }
        public Employee HairDresser { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        private BookingManagement()
        {
        }
    }
}
