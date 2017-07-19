using System;

namespace Domain.Entities.ScheduleObjects
{
    public class TimeRange
    {
        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeRange(DateTime startTime, DateTime endTime)
        {
            if (startTime < endTime) throw new ArgumentException("end time must be larger then start time");

            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
