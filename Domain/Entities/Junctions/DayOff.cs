using Domain.Entities.ScheduleObjects;
using Domain.Entities.Wrappers;

namespace Domain.Entities.Junctions
{
   public class DayOff
    {
        public WeekDay WeekDay { get; set; }
        public int WeekDayId { get; set; }
        public ScheduleBaseSettings ScheduleBaseSettings { get; set; }
        public int ScheduleBaseSettingsId { get; set; }
    }
}
