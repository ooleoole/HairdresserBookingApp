using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Structs;

namespace Domain.Entities.ScheduleObjects
{
    public class Schedule
    {
        public int Id { get; set; }

        public ICollection<DateBoundTimeRanges> NoneStandardAvailableHours
        { get; private set; } = new HashSet<DateBoundTimeRanges>();

        public ICollection<DateBoundTimeRanges> DisabledHours
        { get; private set; } = new HashSet<DateBoundTimeRanges>();

        public ICollection<Booking> Bookings
        { get; private set; } = new HashSet<Booking>();

        public ScheduleBaseSettings ScheduleBaseSettings { get; set; }
        public int ScheduleBaseSettingsId { get; set; }
      


        public Schedule()
        {
        }


    }
}
