using System;
using System.Collections.Generic;
using Domain.Entities.Junctions;

namespace Domain.Entities.Wrappers
{
    public class WeekDay
    {
        
        public DayOfWeek DayOfWeek { get; set; }

        public IEnumerable<DayOff> DaysOff { get; set; }
    }
}
