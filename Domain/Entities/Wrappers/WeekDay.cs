using System;
using System.Collections.Generic;
using Domain.Entities.Junctions;

namespace Domain.Entities.Wrappers
{
    public class WeekDay
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }

        public IEnumerable<DayOff> DaysOff { get; set; }
    }

    
}
