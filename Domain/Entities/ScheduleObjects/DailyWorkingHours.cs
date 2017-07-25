using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.ScheduleObjects
{
    public class DailyWorkingHours
    {
        public DateTime Date { get; set; }
        public IEnumerable<TimeRange> TimeRanges { get; private set; } = new List<TimeRange>();
        public DayOfWeek Day { get; set; }

        private DailyWorkingHours() { }

        public DailyWorkingHours(DateTime date)
        {
            Date = date.Date;
            Day = date.DayOfWeek;
        }

        public DailyWorkingHours AddTimeRange(TimeRange newTimeRange)
        {
            ValidateTimeRange(newTimeRange);
            var timeRangesTemp = TimeRanges.ToList();
            if (CheckIfTimeRangeToAddFitsWithinAnyStoredTimeRange(newTimeRange, timeRangesTemp))
                return this;

            if (timeRangesTemp.Count != 0)
                newTimeRange = MergePotentialOverlaps(newTimeRange, timeRangesTemp);

            timeRangesTemp.Add(newTimeRange);
            TimeRanges = timeRangesTemp;
            return this;
        }

        public DailyWorkingHours RemoveTimeRange(TimeRange timeRange)
        {
            var timeRangesTemp = TimeRanges.ToList();
            for (var i = 0; i < timeRangesTemp.Count; i++)
            {
                var storedTimeRange = timeRangesTemp[i];
                if (storedTimeRange.Equals(timeRange))
                {
                    timeRangesTemp.RemoveAt(i);
                    i--;
                }
                else if (TimeRangeSplitsStoredTimeRange(timeRange, storedTimeRange))
                {
                    var newTimeRangeLower = new TimeRange(storedTimeRange.StartTime, timeRange.StartTime - storedTimeRange.StartTime);
                    var newTimeRangeUpper = new TimeRange(timeRange.EndTime, storedTimeRange.EndTime - timeRange.EndTime);
                    timeRangesTemp.RemoveAt(i);
                    timeRangesTemp.AddRange(new[] { newTimeRangeUpper, newTimeRangeLower });
                    break;
                }
                else if (TimeRangeCutsStartOfStoredTimeRange(timeRange, storedTimeRange))
                {
                    storedTimeRange.StartTime = timeRange.EndTime;
                    timeRangesTemp[i] = storedTimeRange;
                }
                else if (TimeRangeCutsEndOfStoredTimeRange(timeRange, storedTimeRange))
                {
                    storedTimeRange.Duration -= (storedTimeRange.EndTime - timeRange.StartTime);
                    timeRangesTemp[i] = storedTimeRange;
                }
            }
            TimeRanges = timeRangesTemp;
            return this;
        }



        private static TimeRange MergePotentialOverlaps(TimeRange newTimeRange, IList<TimeRange> timeRangesTemp)
        {
            for (var i = 0; i < timeRangesTemp.Count; i++)
            {
                var storedTimeRange = timeRangesTemp[i];


                if (TimeRangeStartsBeforeAndEndsAfterStoredTimeRange(newTimeRange, storedTimeRange))
                {
                    timeRangesTemp.RemoveAt(i);
                    i--;
                }
                else if (CheckForOverLapWhereNewTimeRangeStartFirst(newTimeRange, storedTimeRange))
                {
                    newTimeRange = MergeTimes(newTimeRange, storedTimeRange);
                    timeRangesTemp.RemoveAt(i);
                    i--;
                }
                else if (CheckForOverLapWhereStoredTimeRangeStartFirst(newTimeRange, storedTimeRange))
                {
                    newTimeRange = MergeTimes(storedTimeRange, newTimeRange);
                    timeRangesTemp.RemoveAt(i);
                    i--;

                }
            }
            return newTimeRange;
        }
        private static bool TimeRangeCutsEndOfStoredTimeRange(TimeRange timeRange,
            TimeRange storedTimeRange) =>
            storedTimeRange.EndTime <= timeRange.EndTime &&
            StoredTimeRangeStartsBeforeTimeRange(timeRange, storedTimeRange);

        private static bool TimeRangeCutsStartOfStoredTimeRange(TimeRange timeRange,
            TimeRange storedTimeRange) =>
            storedTimeRange.StartTime >= timeRange.StartTime &&
            TimeRangeEndBeforStoredTimeRange(timeRange, storedTimeRange);


        private static bool TimeRangeSplitsStoredTimeRange(TimeRange timeRange,
            TimeRange storedTimeRange) =>
            StoredTimeRangeStartsBeforeTimeRange(timeRange, storedTimeRange) &&
            TimeRangeEndBeforStoredTimeRange(timeRange, storedTimeRange);

        private static bool StoredTimeRangeStartsBeforeTimeRange(TimeRange timeRange,
            TimeRange storedTimeRange) =>
            storedTimeRange.StartTime < timeRange.StartTime;

        private static bool TimeRangeEndBeforStoredTimeRange(TimeRange timeRange,
            TimeRange storedTimeRange) =>
            timeRange.EndTime < storedTimeRange.EndTime;

        private static TimeRange MergeTimes(TimeRange start,
            TimeRange end) =>
            new TimeRange(start.StartTime, end.EndTime - start.StartTime);

        private static bool OverLap(TimeRange lower,
            TimeRange upper) => lower.EndTime >= upper.StartTime;

        private static bool CheckForOverLapWhereNewTimeRangeStartFirst(TimeRange newTimeRange,
            TimeRange storedTimeRange) =>
            NewTimeRangeDoNotStartAfterStoredTimeRange(newTimeRange, storedTimeRange) &&
            NewTimeRangeDoNotEndAfterStoredTimeRange(newTimeRange, storedTimeRange) &&
            OverLap(newTimeRange, storedTimeRange);

        private static bool CheckForOverLapWhereStoredTimeRangeStartFirst(TimeRange newTimeRange,
            TimeRange storedTimeRange) =>
            !NewTimeRangeDoNotStartAfterStoredTimeRange(newTimeRange, storedTimeRange) &&
            !NewTimeRangeDoNotEndAfterStoredTimeRange(newTimeRange, storedTimeRange) &&
            OverLap(storedTimeRange, newTimeRange);

        private static bool NewTimeRangeDoNotStartAfterStoredTimeRange(TimeRange timeRange,
            TimeRange storedTimeRange) =>
            storedTimeRange.StartTime >= timeRange.StartTime;

        private static bool NewTimeRangeDoNotEndAfterStoredTimeRange(TimeRange timeRange,
            TimeRange storedTimeRange) =>
            storedTimeRange.EndTime >= timeRange.EndTime;

        private static bool TimeRangeStartsBeforeAndEndsAfterStoredTimeRange(TimeRange timeRange,
            TimeRange storedTimeRange) =>
            NewTimeRangeDoNotStartAfterStoredTimeRange(timeRange, storedTimeRange) &&
            storedTimeRange.EndTime <= timeRange.EndTime;

        private static bool CheckIfTimeRangeToAddFitsWithinAnyStoredTimeRange(TimeRange timeRange,
            IEnumerable<TimeRange> timeRangesTemp) =>
            timeRangesTemp.Any(t => t.StartTime <= timeRange.StartTime &&
            NewTimeRangeDoNotEndAfterStoredTimeRange(timeRange, t) ||
            t.Equals(timeRange));

        private static void ValidateTimeRange(TimeRange timeRange)
        {
            if (timeRange.EndTime > new TimeSpan(1, 0, 0, 0))
                throw new ArgumentOutOfRangeException($"The range of the working day cannot stretch pass midnight." +
                                                      $"The working day must not end after 24:00");
        }

        public override string ToString() => $"{Date:d} {Day}";
    }
}
