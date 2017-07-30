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
        public static void Map(EntityTypeBuilder<HairDresser> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => new {p.EmploymentNumber, p.CompanyId, p.SocialSecurityNumber});
            entityTypeBuilder.Property(p => p.FirstName).IsRequired().HasMaxLength(36);
            entityTypeBuilder.Property(p => p.LastName).IsRequired().HasMaxLength(36);
            entityTypeBuilder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);
            entityTypeBuilder.Property(p => p.Email).IsRequired().HasMaxLength(56);
            entityTypeBuilder.Property(p => p.SocialSecurityNumber).IsRequired().HasMaxLength(13);
            entityTypeBuilder.Property(p => p.EmploymentNumber).ValueGeneratedOnAdd();

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

        public static void Map(EntityTypeBuilder<TreatmentHairDresser> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => new { p.HairDresserId, p.TreatmentId });

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
        public static void Map(EntityTypeBuilder<Costumer> entityTypeBuilder)
        {
            entityTypeBuilder.HasAlternateKey(c => new { c.FirstName, c.LastName, c.AddressId, c.CompanyId });
        }



    }
}
