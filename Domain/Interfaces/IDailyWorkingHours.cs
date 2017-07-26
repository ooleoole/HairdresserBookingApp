using System;
using System.Collections.Generic;
using Domain.Entities.ScheduleObjects;

namespace Domain.ScheduleObjects.Entities
{
    public interface IDailyWorkingHours
    {
        bool Bookable { get; }
        DateTime Date { get; set; }
        DayOfWeek Day { get; set; }
        IEnumerable<TimeRange> TimeRanges { get; }

        DailyWorkingHours AddTimeRange(TimeRange newTimeRange);
        DailyWorkingHours Clear();
        DailyWorkingHours RemoveTimeRange(TimeRange timeRange);
    }
}