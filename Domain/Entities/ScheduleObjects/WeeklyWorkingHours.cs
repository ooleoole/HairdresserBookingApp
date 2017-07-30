using System;
using System.Collections.Generic;
using Domain.Entities.Structs;

namespace Domain.Entities.ScheduleObjects
{
    public class WeeklyWorkingHours
    {
        public IEnumerable<DateBoundTimeRanges> Week { get; private set; } = new HashSet<DateBoundTimeRanges>();
        public int WeekNumber { get; set; }

        public WeeklyWorkingHours(HairDresser employee, int weekNumber)
        {
            GenerateBaseWeek(employee);

        }

        private void GenerateBaseWeek(HairDresser employee, params DayOfWeek[] daysOff)
        {
            for (int i = 0; i < 7; i++)
            {

            }
        }
    }
}
