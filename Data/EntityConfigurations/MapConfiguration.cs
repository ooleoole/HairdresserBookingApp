using System;
using Domain.Entities;
using Domain.Entities.Junctions;
using Domain.Entities.ScheduleObjects;
using Domain.Entities.Structs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public static class MapConfiguration
    {
        public static void Map(EntityTypeBuilder<Employee> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => p.EmploymentNumber);
            entityTypeBuilder.HasAlternateKey(p => new { p.EmploymentNumber, p.CompanyId, p.SocialSecurityNumber });
            entityTypeBuilder.Property(p => p.FirstName).IsRequired().HasMaxLength(36);
            entityTypeBuilder.Property(p => p.LastName).IsRequired().HasMaxLength(36);
            entityTypeBuilder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);
            entityTypeBuilder.Property(p => p.Email).IsRequired().HasMaxLength(56);
            entityTypeBuilder.Property(p => p.SocialSecurityNumber).IsRequired().HasMaxLength(13);


        }



        public static void Map(EntityTypeBuilder<DateBoundTimeRanges> entityTypeBuilder)
        {
            ConfigureShadowId(entityTypeBuilder);
            entityTypeBuilder.HasMany(p => p.TimeRanges).WithOne().OnDelete(DeleteBehavior.Cascade);
            entityTypeBuilder.Property<int?>("ScheduleId").HasColumnName("DisabledHoursScheduleId");
            entityTypeBuilder.Property<int?>("ScheduleId1").HasColumnName("NoneStandardAvailableHoursScheduleId");
        }

        public static void Map(EntityTypeBuilder<Schedule> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.Id).UseSqlServerIdentityColumn();
            entityTypeBuilder.HasMany(p => p.DisabledHours).WithOne().OnDelete(DeleteBehavior.Restrict);
            entityTypeBuilder.HasMany(p => p.NoneStandardAvailableHours)
                .WithOne().OnDelete(DeleteBehavior.Restrict);
        }

        public static void Map(EntityTypeBuilder<ScheduleBaseSettings> entityTypeBuilder)
        {


        }

        public static void Map(EntityTypeBuilder<DayOff> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => new { p.ScheduleBaseSettingsId, p.WeekDay });
            //entityTypeBuilder.HasOne(p => p.WeekDay).WithMany().HasForeignKey(p => p.WeekDay);

        }

        public static void Map(EntityTypeBuilder<TreatmentPerformer> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => new { p.EmployeeId, p.TreatmentId });

        }


        public static void Map(EntityTypeBuilder<Booking> entityTypeBuilder)
        {
            entityTypeBuilder.HasAlternateKey(b => new { b.TreatmentId, b.CostumerId, b.DateAndTime });
            entityTypeBuilder.Property(p => p.DateAndTime).IsRequired();
            entityTypeBuilder.Property(p => p.Notes).HasMaxLength(256);


        }
        public static void Map(EntityTypeBuilder<TimeRange> entityTypeBuilder)
        {
            ConfigureShadowId(entityTypeBuilder);
        }



        public static void Map(EntityTypeBuilder<Address> entityTypeBuilder)
        {
            ConfigureShadowId(entityTypeBuilder);
            entityTypeBuilder.Property(p => p.Street).IsRequired().HasMaxLength(96);
            entityTypeBuilder.Property(p => p.City).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(p => p.ZipCode).IsRequired().HasMaxLength(8);
            entityTypeBuilder.Property(p => p.Co).HasMaxLength(96);

        }

        private static void ConfigureShadowId(EntityTypeBuilder entityTypeBuilder)
        {
            entityTypeBuilder.Property<int>("Id").UseSqlServerIdentityColumn();
            entityTypeBuilder.HasKey("Id");
        }
        public static void Map(EntityTypeBuilder<Costumer> entityTypeBuilder)
        {
            entityTypeBuilder.HasAlternateKey(c => new { c.FirstName, c.LastName, c.AddressId, c.CompanyId });
            entityTypeBuilder.Property(p => p.FirstName).HasMaxLength(36).IsRequired();
            entityTypeBuilder.Property(p => p.LastName).HasMaxLength(36).IsRequired();
            entityTypeBuilder.Property(p => p.Email).HasMaxLength(50);
            entityTypeBuilder.Property(p => p.PhoneNumber).HasMaxLength(11).IsRequired();
            entityTypeBuilder.Property(p => p.Notes).HasMaxLength(256);



        }

        public static void Map(EntityTypeBuilder<BookingManagement> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => new { p.BookingId, p.HairDresserId, p.Action });
        }

        public static void Map(EntityTypeBuilder<Company> entityTypeBuilder)
        {
            entityTypeBuilder.HasAlternateKey(p => p.Name);
            entityTypeBuilder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(p => p.Email).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);
        }

        public static void Map(EntityTypeBuilder<Treatment> entityTypeBuilder)
        {
            entityTypeBuilder.HasAlternateKey(p => new { p.Type, p.CompanyId });
            entityTypeBuilder.Property(p => p.BasePrice).IsRequired();
            entityTypeBuilder.Property(p => p.BaseTime).IsRequired();
            entityTypeBuilder.Property(p => p.Notes).HasMaxLength(256);
            entityTypeBuilder.Property(p => p.Type).HasMaxLength(96);

        }



    }
}
