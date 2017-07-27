using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.ScheduleObjects;

namespace Domain.Entities.Junctions
{
    public class NoneStandardAvailableWorkDay
    {
        public int DateBoundTimeRangesId { get; set; }
        public DateBoundTimeRanges DateBoundTimeRanges { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
