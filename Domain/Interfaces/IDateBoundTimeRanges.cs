using System;
using System.Collections.Generic;
using Domain.Entities.ScheduleObjects;
using Domain.Entities.Wrappers;

namespace Domain.Interfaces
{
    public interface IDateBoundTimeRanges
    {
        bool Bookable { get; }
        DateTime Date { get; set; }
        WeekDay Day { get; set; }
        IEnumerable<TimeRange> TimeRanges { get; }

        DateBoundTimeRanges AddTimeRange(TimeRange newTimeRange);
        DateBoundTimeRanges Clear();
        DateBoundTimeRanges RemoveTimeRange(TimeRange timeRange);
    }
}