using System.Collections.Generic;

namespace Domain.Entities.ScheduleObjects
{
    public class Schedule
    {
        public List<WeeklyWorkingHours> AvailableHours { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
