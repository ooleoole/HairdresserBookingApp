using System;
using System.Collections.Generic;
using Domain.Entities.ScheduleObjects;
using Domain.Entities.Structs;

namespace Domain.Interfaces
{
    public interface IDateBoundTimeRanges
    {
        
        DateTime Date { get; set; }
        DayOfWeek Day { get; }
        IEnumerable<TimeRange> TimeRanges { get; }

        DateBoundTimeRanges AddTimeRange(TimeRange newTimeRange);
        DateBoundTimeRanges Clear();
        DateBoundTimeRanges RemoveTimeRange(TimeRange timeRange);
    }
}