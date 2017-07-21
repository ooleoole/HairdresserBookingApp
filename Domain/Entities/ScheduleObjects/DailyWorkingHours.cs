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

            if (CheckIfTimeToAddOverlapsAnyStoredTime(timeRange, timeRangesTemp))
            {
                for (int i = 0; i < timeRangesTemp.Count; i++)
                {
                    var storedTimeRange = timeRangesTemp.ToList()[i];

                    if (storedTimeRange.Equals(timeRange))
                        return;
                    //StoredTimeRange  Is bigger then timeRange to Add
                    if (storedTimeRange.StartTime <= timeRange.StartTime && storedTimeRange.EndTime >= timeRange.EndTime)
                        return;

                    //TimeRange to add is bigger then storedTimeRange
                    if (storedTimeRange.StartTime >= timeRange.StartTime && storedTimeRange.EndTime <= timeRange.EndTime)
                    {
                        timeRangesTemp.RemoveAt(i);
                        i--;
                        continue;
                    }
                    if (storedTimeRange.StartTime <= timeRange.StartTime && storedTimeRange.EndTime <= timeRange.EndTime)
                    {
                        timeRange = new TimeRange(storedTimeRange.StartTime, timeRange.EndTime - storedTimeRange.StartTime);
                        timeRangesTemp.RemoveAt(i);
                    }
                    else if (storedTimeRange.StartTime >= timeRange.StartTime && storedTimeRange.EndTime >= timeRange.EndTime)
                    {
                        timeRange = new TimeRange(timeRange.StartTime, storedTimeRange.EndTime - timeRange.StartTime);
                        timeRangesTemp.RemoveAt(i);
                    }

                }

            }

            timeRangesTemp.Add(timeRange);

            TimeRanges = timeRangesTemp;
        }

        private static bool CheckIfTimeToAddOverlapsAnyStoredTime(TimeRange timeRange, IReadOnlyCollection<TimeRange> timeRangesTemp)
        {
            return !(timeRangesTemp.Count == 0 ||
                     timeRangesTemp.Any(t => t.EndTime < timeRange.StartTime ||
                                             timeRange.EndTime < t.StartTime));
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
