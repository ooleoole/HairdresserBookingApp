using System;
using Domain.Entities;
using Domain.Entities.Junctions;
using Domain.Entities.ScheduleObjects;
using Domain.Entities.Wrappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityConfigurations
{
    public static class MapConfiguration
    {
        public static void Map(EntityTypeBuilder<HairDresser> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.FirstName).IsRequired().HasMaxLength(36);
            entityTypeBuilder.Property(p => p.LastName).IsRequired().HasMaxLength(36);
            entityTypeBuilder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);
            entityTypeBuilder.Property(p => p.Email).IsRequired().HasMaxLength(56);
            entityTypeBuilder.Property(p => p.SocialSecurityNumber).IsRequired().HasMaxLength(13);
            entityTypeBuilder.HasAlternateKey(p => p.SocialSecurityNumber);
        }



        public static void Map(EntityTypeBuilder<DateBoundTimeRanges> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.Id).UseSqlServerIdentityColumn();

            entityTypeBuilder.HasMany(p => p.TimeRanges).WithOne();
            //entityTypeBuilder.Property<int>("NoneStandardAvailableHoursScheduleId");
            //entityTypeBuilder.HasOne("NoneStandardAvailableHoursScheduleId")
            //    .WithMany("NoneStandardAvailableHours")
            //    .HasForeignKey("NoneStandardAvailableHoursScheduleId");

            //entityTypeBuilder.HasOne(p => p.DisabledHoursSchedule)
            //    .WithMany(p => p.DisabledHours).HasForeignKey(p => p.DisabledHoursScheduleId);
            //entityTypeBuilder.Property<int>("NoneStandardAvailableHoursScheduleId");
            //entityTypeBuilder.Property<int>("DisabledHoursScheduleId");
            entityTypeBuilder.Property<int?>("ScheduleId").HasColumnName("DisabledHoursScheduleId");
            entityTypeBuilder.Property<int?>("ScheduleId1").HasColumnName("NoneStandardAvailableHoursScheduleId");
        }

        public static void Map(EntityTypeBuilder<Schedule> entityTypeBuilder)
        {
            entityTypeBuilder.Property(p => p.Id).UseSqlServerIdentityColumn();
            entityTypeBuilder.HasMany(p => p.DisabledHours).WithOne();
            entityTypeBuilder.HasMany(p => p.NoneStandardAvailableHours)
                .WithOne();


        }

        public static void Map(EntityTypeBuilder<ScheduleBaseSettings> entityTypeBuilder)
        {


        }

        public static void Map(EntityTypeBuilder<DayOff> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => new { p.ScheduleBaseSettingsId, p.WeekDayId });
            entityTypeBuilder.HasOne(p => p.WeekDay).WithMany(p => p.DaysOff).HasForeignKey(p => p.WeekDayId);

        }

        public static void Map(EntityTypeBuilder<TreatmentHairDresser> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => new { p.HairDresserId, p.TreatmentId });

        }
        public static void Map(EntityTypeBuilder<WeekDay> entityTypeBuilder)
        {
            entityTypeBuilder.HasAlternateKey(p => p.Day);

        }

        public static void Map(EntityTypeBuilder<Booking> entityTypeBuilder)
        {
            entityTypeBuilder.HasAlternateKey(b => new { b.TreatmentId, b.CostumerId, b.DateAndTime });

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


    }
}
