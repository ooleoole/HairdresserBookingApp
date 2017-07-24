using System.Collections.Generic;

namespace Domain.Entities.ScheduleObjects
{
    public class WeeklyWorkingHours
    {
        public Dictionary<DailyWorkingHours, TimeRange> Week { get; set; } = new Dictionary<DailyWorkingHours, TimeRange>();
        public int WeekNumber { get; set; }

        public WeeklyWorkingHours(Employee employee)
        {
            GenerateBaseWeek(employee);
            
        }

        private void GenerateBaseWeek(Employee employee)
        {
            for (int i = 0; i < 7; i++)
            {
               
            }
        }
    }
}
