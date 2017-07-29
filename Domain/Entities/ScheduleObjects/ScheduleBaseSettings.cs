using System.Collections.Generic;
using Domain.Entities.Junctions;
using Domain.Entities.Wrappers;

namespace Domain.Entities.ScheduleObjects
{
    public class ScheduleBaseSettings
    {
        public int Id { get; set; }

        public TimeRange WorkHours { get; set; }
        public int WorkHoursId { get; set; }
        public TimeRange Lunch { get; set; }
        public int LunchId { get; set; }
        public IEnumerable<DayOff> DaysOff { get; set; } = new HashSet<DayOff>();

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

    }
}
