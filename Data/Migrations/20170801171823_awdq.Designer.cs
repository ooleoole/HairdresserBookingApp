using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Data.Context;
using Domain.Enums;

namespace Data.Migrations
{
    [DbContext(typeof(HairdresserBookingAppContext))]
    [Migration("20170801171823_awdq")]
    partial class awdq
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Co")
                        .HasMaxLength(96);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(96);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CostumerId");

                    b.Property<DateTime>("DateAndTime");

                    b.Property<bool>("EmployeeIsNotified");

                    b.Property<int>("ExtraCost");

                    b.Property<TimeSpan>("ExtraTime");

                    b.Property<bool>("IsCancelled");

                    b.Property<string>("Notes")
                        .HasMaxLength(256);

                    b.Property<int>("PerformerId");

                    b.Property<int>("ScheduleId");

                    b.Property<int>("TreatmentId");

                    b.HasKey("Id");

                    b.HasAlternateKey("TreatmentId", "CostumerId", "DateAndTime");

                    b.HasIndex("CostumerId");

                    b.HasIndex("PerformerId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("AddressId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Entities.Costumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<int>("CompanyId");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<string>("Notes")
                        .HasMaxLength(256);

                    b.Property<bool>("NotifyExtraCostOrTime");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasAlternateKey("FirstName", "LastName", "AddressId", "CompanyId");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Costumers");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmploymentNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<int?>("CompanyId")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(56);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<int?>("ScheduleId");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasMaxLength(13);

                    b.HasKey("EmploymentNumber");

                    b.HasAlternateKey("EmploymentNumber", "CompanyId", "SocialSecurityNumber");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.BookingManagement", b =>
                {
                    b.Property<int>("BookingId");

                    b.Property<int>("HairDresserId");

                    b.Property<int>("Action");

                    b.HasKey("BookingId", "HairDresserId", "Action");

                    b.HasIndex("HairDresserId");

                    b.ToTable("BookingManagement");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.DayOff", b =>
                {
                    b.Property<int>("ScheduleBaseSettingsId");

                    b.Property<int>("WeekDay");

                    b.HasKey("ScheduleBaseSettingsId", "WeekDay");

                    b.ToTable("DayOff");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.TreatmentPerformer", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("TreatmentId");

                    b.HasKey("EmployeeId", "TreatmentId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("TreatmentPerformer");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ScheduleBaseSettingsId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleBaseSettingsId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.ScheduleBaseSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LunchId");

                    b.Property<int>("WorkHoursId");

                    b.HasKey("Id");

                    b.HasIndex("LunchId");

                    b.HasIndex("WorkHoursId");

                    b.ToTable("ScheduleBaseSettingses");
                });

            modelBuilder.Entity("Domain.Entities.Structs.DateBoundTimeRanges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("Day");

                    b.Property<int?>("ScheduleId")
                        .HasColumnName("DisabledHoursScheduleId");

                    b.Property<int?>("ScheduleId1")
                        .HasColumnName("NoneStandardAvailableHoursScheduleId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("ScheduleId1");

                    b.ToTable("DateBoundTimeRangeses");
                });

            modelBuilder.Entity("Domain.Entities.Structs.TimeRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DateBoundTimeRangesId");

                    b.Property<TimeSpan>("Duration");

                    b.Property<TimeSpan>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("DateBoundTimeRangesId");

                    b.ToTable("TimeRange");
                });

            modelBuilder.Entity("Domain.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BasePrice");

                    b.Property<TimeSpan>("BaseTime");

                    b.Property<int>("CompanyId");

                    b.Property<string>("Notes")
                        .HasMaxLength(256);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(96);

                    b.HasKey("Id");

                    b.HasAlternateKey("Type", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.HasOne("Domain.Entities.Costumer", "Costumer")
                        .WithMany()
                        .HasForeignKey("CostumerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Employee", "Performer")
                        .WithMany()
                        .HasForeignKey("PerformerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ScheduleObjects.Schedule", "Schedule")
                        .WithMany("Bookings")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Costumer", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Costumers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Company", "Employment")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ScheduleObjects.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.BookingManagement", b =>
                {
                    b.HasOne("Domain.Entities.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Employee", "HairDresser")
                        .WithMany()
                        .HasForeignKey("HairDresserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Junctions.DayOff", b =>
                {
                    b.HasOne("Domain.Entities.ScheduleObjects.ScheduleBaseSettings", "ScheduleBaseSettings")
                        .WithMany("DaysOff")
                        .HasForeignKey("ScheduleBaseSettingsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Junctions.TreatmentPerformer", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("Treatments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Treatment", "Treatment")
                        .WithMany("Performers")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.Schedule", b =>
                {
                    b.HasOne("Domain.Entities.ScheduleObjects.ScheduleBaseSettings", "ScheduleBaseSettings")
                        .WithMany()
                        .HasForeignKey("ScheduleBaseSettingsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.ScheduleBaseSettings", b =>
                {
                    b.HasOne("Domain.Entities.Structs.TimeRange", "Lunch")
                        .WithMany()
                        .HasForeignKey("LunchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Structs.TimeRange", "WorkHours")
                        .WithMany()
                        .HasForeignKey("WorkHoursId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Structs.DateBoundTimeRanges", b =>
                {
                    b.HasOne("Domain.Entities.ScheduleObjects.Schedule")
                        .WithMany("DisabledHours")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("Domain.Entities.ScheduleObjects.Schedule")
                        .WithMany("NoneStandardAvailableHours")
                        .HasForeignKey("ScheduleId1");
                });

            modelBuilder.Entity("Domain.Entities.Structs.TimeRange", b =>
                {
                    b.HasOne("Domain.Entities.Structs.DateBoundTimeRanges")
                        .WithMany("TimeRanges")
                        .HasForeignKey("DateBoundTimeRangesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Treatment", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Treatments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
