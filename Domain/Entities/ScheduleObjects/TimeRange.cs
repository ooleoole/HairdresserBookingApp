using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Domain.Entities.ScheduleObjects
{
    
    public class TimeRange
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime => StartTime + Duration;

        public TimeSpan Duration { get; set; }

        public TimeRange(DateTime startTime, TimeSpan duration)
        {
            StartTime = startTime.TimeOfDay;
            Duration = duration;
        }
        public TimeRange(TimeSpan startTime, TimeSpan duration)
        {
            StartTime = startTime;
            Duration = duration;
        }


        public override string ToString() => $"StartTime: {StartTime.Hours}:{StartTime.Minutes} Duration: {Duration:g}";

        public override bool Equals(object obj)
        {
            if (obj is TimeRange)
            {
                var timeRange = (TimeRange)obj;
                return StartTime == timeRange.StartTime && Duration == timeRange.Duration;
            }
            return false;

        }

        protected bool Equals(TimeRange other)
        {
            return StartTime.Equals(other.StartTime) && Duration.Equals(other.Duration);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (StartTime.GetHashCode() * 397) ^ Duration.GetHashCode();
            }
        }
    }
}
