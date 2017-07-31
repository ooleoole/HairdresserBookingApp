using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Data.Context;
using Domain.Entities;
using Domain.Entities.ScheduleObjects;
using Domain.Entities.Structs;
using Microsoft.EntityFrameworkCore;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new TimeRange(new TimeSpan(8, 0, 0), new TimeSpan(3, 0, 0));

            var db = new HairdresserBookingAppContext();
            var ttt = new Schedule();

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
            var time7 = new TimeRange(new TimeSpan(8, 0, 0), new TimeSpan(2, 0, 0));
            var booking = new Booking();
            booking.Costumer = new Costumer()
            {
                Address = new Address()
                {
                    City = "Bgg",
                    Street = "sdrfgsa",
                    ZipCode = "47496"

                },
                Email = "asdaw@asdad.com",
                FirstName = "ola",
                LastName = "Popp",
                PhoneNumber = "0705416351"

            };
            booking.DateAndTime = DateTime.Now;
            booking.ExtraCost = 0;
            
            booking.Schedule = ttt;
           
            booking.Treatment = new Treatment()
            {
                BasePrice = 45,
                BaseTime = new TimeSpan(1,0,0),
                Type = "Klipp",
                Company = new Company() {Address = new Address()
                {
                    City = "Bgg",
                    Street = "sdrfgsa",
                    ZipCode = "47496"
                },
                Email = "awdawd@awdd.com",
                Name = "Carins klipp",
                PhoneNumber = "45454124"
                }
            };

            workingHours.AddTimeRange(time2).AddTimeRange(time1).AddTimeRange(time3).AddTimeRange(time4).AddTimeRange(time5).AddTimeRange(time6).RemoveTimeRange(time7);
            ttt.NoneStandardAvailableHours.Add(workingHours);

            //db.Schedules.Add(ttt);
            //db.Schedules.Add(ttt);
            //db.Schedules.Add(ttt);
            foreach (var sc in db.Bookings.Include(p => p.ExtraTime).Include(p => p.Treatment).Include(p=>p.Schedule))
            {
                db.Bookings.Remove(sc);
            }
            //db.Bookings.Add(booking);
            db.ChangeTracker.Context.SaveChanges();

            Console.WriteLine((int)DayOfWeek.Saturday);
            Console.ReadKey();
        }
    }
}