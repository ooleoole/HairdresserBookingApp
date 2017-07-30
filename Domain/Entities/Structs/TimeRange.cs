using System;

namespace Domain.Entities.Structs
{

    public class TimeRange
    {
        private TimeSpan _duration;

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime => StartTime + Duration;
        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                ValidateDuration(value);
                _duration = value;
            }
        }

        public TimeRange()
        {
        }
        public TimeRange(DateTime startTime, TimeSpan duration)
        {
            ValidateDuration(duration);
            StartTime = startTime.TimeOfDay;
            Duration = duration;
        }
        public TimeRange(TimeSpan startTime, TimeSpan duration)
        {
            ValidateDuration(duration);
            StartTime = startTime;
            Duration = duration;
        }

        private void ValidateDuration(TimeSpan duration)
        {
            if (duration < TimeSpan.Zero)
                throw new ArgumentOutOfRangeException($"Duration cannot be negativ");
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
