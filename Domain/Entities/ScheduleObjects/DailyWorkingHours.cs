using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.ScheduleObjects
{
    public class DailyWorkingHours
    {
        public DateTime Date { get; set; }
        public IEnumerable<TimeRange> TimeRanges { get; set; } = new List<TimeRange>();
        public DayOfWeek Day { get; set; }

        public DailyWorkingHours(DateTime date)
        {
            Date = date.Date;
            Day = date.DayOfWeek;
        }

        public void AddTimeRange(TimeRange timeRange)
        {
            ValidateTimeRange(timeRange);
            var timeRangesTemp = TimeRanges.ToList();


            for (int i = 0; i < timeRangesTemp.Count; i++)
            {
                var storedTimeRange = TimeRanges.ToList()[i];
                if (storedTimeRange.Equals(timeRange))
                    break;

                if (storedTimeRange.EndTime > timeRange.StartTime && storedTimeRange.StartTime <= timeRange.StartTime && storedTimeRange.EndTime <= timeRange.EndTime)
                {
                    timeRange = new TimeRange(storedTimeRange.StartTime, timeRange.Duration);
                    timeRangesTemp.RemoveAt(i);

                }
                else if (timeRange.StartTime <= storedTimeRange.StartTime && timeRange.EndTime <= storedTimeRange.EndTime)
                {
                    timeRange = new TimeRange(timeRange.StartTime, storedTimeRange.Duration);
                    timeRangesTemp.RemoveAt(i);
                }
                else if (timeRange.StartTime <= storedTimeRange.StartTime && timeRange.EndTime >= storedTimeRange.EndTime)
                {
                    timeRangesTemp.RemoveAt(i);
                }

               
            }
            timeRangesTemp.Add(timeRange);


            if (timeRangesTemp.Count == 0)
                timeRangesTemp.Add(timeRange);


            TimeRanges = timeRangesTemp;
        }

        private static void ValidateTimeRange(TimeRange timeRange)
        {
            if (timeRange.EndTime > new TimeSpan(1, 0, 0, 0))
                throw new ArgumentOutOfRangeException($"The range of the working day cannot stretch pass midnight." +
                                                      $"The working day must not end after 24:00");
        }

        public override string ToString()
        {
            return $"{Date:d} {Day}";
        }
    }
}
