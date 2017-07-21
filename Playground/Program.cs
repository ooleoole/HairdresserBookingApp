using System;
using Domain.Entities;
using Domain.Entities.ScheduleObjects;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TimeRange();

            test.StartTime = new TimeSpan(8, 0, 0);
            test.Duration = new TimeSpan(3, 0, 0);
            var timeRange2 = test;
            timeRange2.Duration = new TimeSpan(4, 0, 0);
            var test2 = new DailyWorkingHours(DateTime.Now);
            var timeRange3 = new TimeRange(new TimeSpan(7, 0, 0), new TimeSpan(10, 0, 0));
            var timeRange4 = new TimeRange(new TimeSpan(19, 0, 0), new TimeSpan(2, 0, 0));
            var timeRange5 = new TimeRange(new TimeSpan(6, 0, 0), new TimeSpan(14, 0, 0));
            var timeRange6 = new TimeRange(new TimeSpan(6, 0, 0), new TimeSpan(14, 0, 0));
            test2.AddTimeRange(test);
            test2.AddTimeRange(timeRange2);
            test2.AddTimeRange(timeRange3);
            test2.AddTimeRange(timeRange4);
            test2.AddTimeRange(timeRange5);
            test2.AddTimeRange(timeRange6);
            Console.WriteLine(test);

        }
    }
}