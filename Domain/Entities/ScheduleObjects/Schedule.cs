using System;
using System.Collections.Generic;
using Domain.Interfaces;

namespace Domain.Entities.ScheduleObjects
{
    public class Schedule
    {
        public IEnumerable<DailyWorkingHours> AvailableHours { get; private set; } = new HashSet<DailyWorkingHours>();
        public IEnumerable<Booking> Bookings { get; private set; } = new HashSet<Booking>();

        private const int BaseDays = 60;

        public Schedule(IEmployee employee)
        {
            GenerateBaseSchedule(employee);
        }

        private void GenerateBaseSchedule(IEmployee employee)
        {

            //TODO: Schedule settings
            var startDate = DateTime.Now.Subtract(TimeSpan.FromDays(60/2));
            for (int i = 0; i < BaseDays; i++)
            {
                var dailyWorkingHour= new DailyWorkingHours(startDate);
            }
        }
}
