using System;
using Domain.Entities.ScheduleObjects;

namespace Domain.Entities.Junctions
{
   public class DayOff
    {
        public DayOfWeek WeekDay { get; set; }
        public ScheduleBaseSettings ScheduleBaseSettings { get; set; }
        public int ScheduleBaseSettingsId { get; set; }
    }
}
