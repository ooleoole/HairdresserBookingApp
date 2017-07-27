using System;
using System.Linq;
using Domain.Entities;
using Domain.Entities.ScheduleObjects;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TimeRange(new TimeSpan(8, 0, 0), new TimeSpan(3, 0, 0));

           
            var timeRange2 = test;
            timeRange2.Duration = new TimeSpan(4, 0, 0);
            var test2 = new DateBoundTimeRanges(DateTime.Now);
            var timeRange3 = new TimeRange(new TimeSpan(7, 0, 0), new TimeSpan(10, 0, 0));
            var timeRange4 = new TimeRange(new TimeSpan(19, 0, 0), new TimeSpan(2, 0, 0));
            var timeRange5 = new TimeRange(new TimeSpan(6, 0, 0), new TimeSpan(14, 0, 0));
            var timeRange6 = new TimeRange(new TimeSpan(6, 0, 0), new TimeSpan(14, 0, 0));
            
            test2.AddTimeRange(timeRange2);
            test2.AddTimeRange(timeRange3);
            test2.AddTimeRange(timeRange4);
            test2.AddTimeRange(timeRange5);
            test2.AddTimeRange(timeRange6);
            test2.AddTimeRange(timeRange2);
            Console.WriteLine(test);

            var workingHours = new DateBoundTimeRanges(DateTime.Now);
            var time1 = new TimeRange(new TimeSpan(2, 0, 0), new TimeSpan(1, 0, 0));
            var time2 = new TimeRange(new TimeSpan(5, 0, 0), new TimeSpan(1, 0, 0));
            var time3 = new TimeRange(new TimeSpan(6, 0, 0), new TimeSpan(1, 0, 0));
            var time4 = new TimeRange(new TimeSpan(8, 0, 0), new TimeSpan(4, 0, 0));
            var time5 = new TimeRange(new TimeSpan(16, 0, 0), new TimeSpan(4, 0, 0));
            var time6 = new TimeRange(new TimeSpan(3, 0, 0), new TimeSpan(13, 0, 0));
            var time7 = new TimeRange(new TimeSpan(17, 0, 0), new TimeSpan(6, 0, 0));
            workingHours.AddTimeRange(time2).AddTimeRange(time1).AddTimeRange(time3).AddTimeRange(time4).AddTimeRange(time5).AddTimeRange(time6).RemoveTimeRange(time7);
            Console.WriteLine((int)DayOfWeek.Saturday);
            Console.ReadKey();
        }
    }
}