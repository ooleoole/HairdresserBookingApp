using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.ScheduleObjects;

namespace Domain.Entities.Wrappers
{
    public class WrappedTimeRange
    {
        public TimeRange TimeRange { get; set; }


        public DateBoundTimeRanges DateBoundTimeRanges { get; set; }
        public int DateBoundTimeRangesId { get; set; }

        public WrappedTimeRange()
        {
        }

        public WrappedTimeRange(TimeRange timeRange)
        {
            TimeRange = timeRange;
        }
    }
}
