using System.Collections.Generic;
using Domain.Entities.Junctions;

namespace Domain.Entities.ScheduleObjects
{
    public class Schedule
    {
        public int Id { get; set; }
        public IEnumerable<NoneStandardAvailableWorkDay> NoneStandardAvailableHours { get; private set; } = new HashSet<NoneStandardAvailableWorkDay>();
        //public IEnumerable<DateBoundTimeRanges> DisabledHours { get; private set; } = new HashSet<DateBoundTimeRanges>();
        public IEnumerable<Booking> Bookings { get; private set; } = new HashSet<Booking>();

        public ScheduleBaseSettings ScheduleBaseSettings { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        

        public Schedule()
        {
        }

       
    }
}
