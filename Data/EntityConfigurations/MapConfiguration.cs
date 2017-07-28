using Domain.Entities;
using Domain.Entities.Junctions;
using Domain.Entities.ScheduleObjects;
using Domain.Entities.Wrappers;
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

        public static void Map(EntityTypeBuilder<NoneStandardAvailableWorkDay> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(p => p.DateBoundTimeRangesId);
            entityTypeBuilder.Property(p => p.ScheduleId).IsRequired();
        }

        public static void Map(EntityTypeBuilder<DateBoundTimeRanges> entityTypeBuilder)
        {

            entityTypeBuilder.HasMany(p => p.TimeRanges).WithOne();
        }

        public static void Map(EntityTypeBuilder<Schedule> entityTypeBuilder)
        {


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





    }
}
