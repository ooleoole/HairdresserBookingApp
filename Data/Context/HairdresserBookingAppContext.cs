﻿using Data.EntityConfigurations;
using Domain.Entities;
using Domain.Entities.Junctions;
using Domain.Entities.ScheduleObjects;
using Domain.Entities.Structs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Data.Context
{
    public class HairdresserBookingAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduleBaseSettings> ScheduleBaseSettingses { get; set; }
        public DbSet<CompanyCostumer> CompanyCostumers { get; set; }
        public DbSet<DateBoundTimeRanges> DateBoundTimeRangeses { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.ModelValidationWarning));
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HairdresserBookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<HairDresser>().HasAlternateKey(h => h.SocialSecurityNumber);
            MapConfiguration.Map(modelBuilder.Entity<HairDresser>());
            modelBuilder.Entity<Costumer>().HasAlternateKey(c => new { c.FirstName, c.LastName, c.AddressId });
            modelBuilder.Entity<Company>().HasAlternateKey(c => c.Name);
            modelBuilder.Entity<CompanyCostumer>().HasKey(cc => new { cc.CompanyId, cc.CostumerId });
            modelBuilder.Entity<Skill>().HasAlternateKey(s => new { s.Type, s.MasterId });
            modelBuilder.Entity<Employee>().HasKey(e => new { e.CompanyId, e.HairDresserId, e.EmploymentNumber });
            modelBuilder.Entity<Treatment>().HasAlternateKey(t => new { t.Type, t.CompanyId });
            //modelBuilder.Entity<Booking>().HasAlternateKey(b => new { b.TreatmentId, b.CostumerId, b.DateAndTime });
            modelBuilder.Entity<Costumer>().HasAlternateKey(e => new { e.Email });
            //MapConfiguration.Map(modelBuilder.Entity<NoneStandardAvailableWorkDay>());
            MapConfiguration.Map(modelBuilder.Entity<DateBoundTimeRanges>());
            MapConfiguration.Map(modelBuilder.Entity<DayOff>());
            MapConfiguration.Map(modelBuilder.Entity<TreatmentHairDresser>());
            // MapConfiguration.Map(modelBuilder.Entity<WeekDay>());
            MapConfiguration.Map(modelBuilder.Entity<Booking>());
            MapConfiguration.Map(modelBuilder.Entity<TimeRange>());
            MapConfiguration.Map(modelBuilder.Entity<Address>());


        }
    }
}
