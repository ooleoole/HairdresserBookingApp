using System;

namespace Domain.Entities.ScheduleObjects
{
    public struct TimeRange
    {

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


        public override string ToString()
        {
            return $"StartTime: {StartTime.Hours}:{StartTime.Minutes} Duration: {Duration:g}";
        }
    }
}
