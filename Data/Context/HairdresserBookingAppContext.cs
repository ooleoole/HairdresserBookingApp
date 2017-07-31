using Data.EntityConfigurations;
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
        public DbSet<DateBoundTimeRanges> DateBoundTimeRangeses { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.ModelValidationWarning));
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HairdresserBookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            MapConfiguration.Map(modelBuilder.Entity<DateBoundTimeRanges>());
            MapConfiguration.Map(modelBuilder.Entity<DayOff>());
            MapConfiguration.Map(modelBuilder.Entity<TreatmentPerformer>());
            MapConfiguration.Map(modelBuilder.Entity<Booking>());
            MapConfiguration.Map(modelBuilder.Entity<TimeRange>());
            MapConfiguration.Map(modelBuilder.Entity<Address>());
            MapConfiguration.Map(modelBuilder.Entity<Costumer>());
            MapConfiguration.Map(modelBuilder.Entity<Employee>());
            MapConfiguration.Map(modelBuilder.Entity<BookingManagement>());
            MapConfiguration.Map(modelBuilder.Entity<Company>());
            MapConfiguration.Map(modelBuilder.Entity<Treatment>());
            MapConfiguration.Map(modelBuilder.Entity<Costumer>());


        }
    }
}
