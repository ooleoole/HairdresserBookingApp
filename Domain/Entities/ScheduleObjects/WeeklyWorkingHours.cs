using System;
using System.Collections.Generic;

namespace Domain.Entities.ScheduleObjects
{
    public class WeeklyWorkingHours
    {
        public IEnumerable<DailyWorkingHours> Week { get; private set; } = new HashSet<DailyWorkingHours>();
        public int WeekNumber { get; set; }

        public WeeklyWorkingHours(Employee employee, int weekNumber)
        {
            GenerateBaseWeek(employee);

        }

        private void GenerateBaseWeek(Employee employee, params DayOfWeek[] daysOff)
        {
            for (int i = 0; i < 7; i++)
            {

            }
        }
    }
}
