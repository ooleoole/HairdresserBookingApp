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
    [Migration("20170729194456_dssdghfaqwdqfqn")]
    partial class dssdghfaqwdqfqn
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

                    b.Property<int?>("ExtraTimeId");

                    b.Property<bool>("IsCancelled");

                    b.Property<string>("Notes")
                        .HasMaxLength(256);

                    b.Property<int>("ScheduleId");

                    b.Property<int>("TotalPrice");

                    b.Property<int?>("TotalTimeId");

                    b.Property<int>("TreatmentId");

                    b.HasKey("Id");

                    b.HasAlternateKey("TreatmentId", "CostumerId", "DateAndTime");

                    b.HasIndex("CostumerId");

                    b.HasIndex("ExtraTimeId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("TotalTimeId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Email")
                        .IsRequired();

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

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

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

                    b.HasAlternateKey("Email");


                    b.HasAlternateKey("FirstName", "LastName", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("Costumers");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("HairDresserId");

                    b.Property<int>("EmploymentNumber");

                    b.Property<int>("AddressId");

                    b.HasKey("CompanyId", "HairDresserId", "EmploymentNumber");

                    b.HasIndex("AddressId");

                    b.HasIndex("HairDresserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.HairDresser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

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

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired()
                        .HasMaxLength(13);

                    b.HasKey("Id");

                    b.HasAlternateKey("SocialSecurityNumber");

                    b.HasIndex("AddressId");

                    b.ToTable("HairDresser");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.CompanyCostumer", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("CostumerId");

                    b.HasKey("CompanyId", "CostumerId");

                    b.HasIndex("CostumerId");

                    b.ToTable("CompanyCostumers");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.DayOff", b =>
                {
                    b.Property<int>("ScheduleBaseSettingsId");

                    b.Property<int>("WeekDayId");

                    b.HasKey("ScheduleBaseSettingsId", "WeekDayId");

                    b.HasIndex("WeekDayId");

                    b.ToTable("DayOff");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.TreatmentHairDresser", b =>
                {
                    b.Property<int>("HairDresserId");

                    b.Property<int>("TreatmentId");

                    b.HasKey("HairDresserId", "TreatmentId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("TreatmentHairDresser");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.DateBoundTimeRanges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int?>("DayId");

                    b.Property<int?>("ScheduleId")
                        .HasColumnName("Tess");

                    b.Property<int?>("ScheduleId1");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("ScheduleId1");

                    b.ToTable("DateBoundTimeRangeses");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeCompanyId");

                    b.Property<int?>("EmployeeEmploymentNumber");

                    b.Property<int?>("EmployeeHairDresserId");

                    b.Property<int?>("EmployeeId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.ScheduleBaseSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LunchId");

                    b.Property<int>("ScheduleId");

                    b.Property<int>("WorkHoursId");

                    b.HasKey("Id");

                    b.HasIndex("LunchId");

                    b.HasIndex("ScheduleId")
                        .IsUnique();

                    b.HasIndex("WorkHoursId");

                    b.ToTable("ScheduleBaseSettingses");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.TimeRange", b =>
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

            modelBuilder.Entity("Domain.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MasterId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(96);

                    b.HasKey("Id");

                    b.HasAlternateKey("Type", "MasterId");

                    b.HasIndex("MasterId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Domain.Entities.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BasePrice");

                    b.Property<TimeSpan>("BaseTime");

                    b.Property<int>("CompanyId");

                    b.Property<int?>("EmployeeCompanyId");

                    b.Property<int?>("EmployeeEmploymentNumber");

                    b.Property<int?>("EmployeeHairDresserId");

                    b.Property<string>("Notes")
                        .HasMaxLength(256);

                    b.Property<int?>("SkillId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(96);

                    b.HasKey("Id");

                    b.HasAlternateKey("Type", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SkillId");

                    b.HasIndex("EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Domain.Entities.Wrappers.WeekDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.HasKey("Id");

                    b.HasAlternateKey("Day");

                    b.ToTable("WeekDay");
                });

            modelBuilder.Entity("Domain.Entities.Booking", b =>
                {
                    b.HasOne("Domain.Entities.Costumer", "Costumer")
                        .WithMany()
                        .HasForeignKey("CostumerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ScheduleObjects.TimeRange", "ExtraTime")
                        .WithMany()
                        .HasForeignKey("ExtraTimeId");

                    b.HasOne("Domain.Entities.ScheduleObjects.Schedule", "Schedule")
                        .WithMany("Bookings")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ScheduleObjects.TimeRange", "TotalTime")
                        .WithMany()
                        .HasForeignKey("TotalTimeId");

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

                    b.HasOne("Domain.Entities.HairDresser", "HairDresser")
                        .WithMany("Employments")
                        .HasForeignKey("HairDresserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.HairDresser", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.CompanyCostumer", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Costumers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Costumer", "Costumer")
                        .WithMany("Companies")
                        .HasForeignKey("CostumerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Junctions.DayOff", b =>
                {
                    b.HasOne("Domain.Entities.ScheduleObjects.ScheduleBaseSettings", "ScheduleBaseSettings")
                        .WithMany("DaysOff")
                        .HasForeignKey("ScheduleBaseSettingsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Wrappers.WeekDay", "WeekDay")
                        .WithMany("DaysOff")
                        .HasForeignKey("WeekDayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Junctions.TreatmentHairDresser", b =>
                {
                    b.HasOne("Domain.Entities.HairDresser", "HairDresser")
                        .WithMany("MasteredTreatments")
                        .HasForeignKey("HairDresserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Treatment", "Treatment")
                        .WithMany("Masters")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.DateBoundTimeRanges", b =>
                {
                    b.HasOne("Domain.Entities.Wrappers.WeekDay", "Day")
                        .WithMany()
                        .HasForeignKey("DayId");

                    b.HasOne("Domain.Entities.ScheduleObjects.Schedule")
                        .WithMany("DisabledHours")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("Domain.Entities.ScheduleObjects.Schedule")
                        .WithMany("NoneStandardAvailableHours")
                        .HasForeignKey("ScheduleId1");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.Schedule", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.ScheduleBaseSettings", b =>
                {
                    b.HasOne("Domain.Entities.ScheduleObjects.TimeRange", "Lunch")
                        .WithMany()
                        .HasForeignKey("LunchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ScheduleObjects.Schedule", "Schedule")
                        .WithOne("ScheduleBaseSettings")
                        .HasForeignKey("Domain.Entities.ScheduleObjects.ScheduleBaseSettings", "ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.ScheduleObjects.TimeRange", "WorkHours")
                        .WithMany()
                        .HasForeignKey("WorkHoursId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.ScheduleObjects.TimeRange", b =>
                {
                    b.HasOne("Domain.Entities.ScheduleObjects.DateBoundTimeRanges")
                        .WithMany("TimeRanges")
                        .HasForeignKey("DateBoundTimeRangesId");
                });

            modelBuilder.Entity("Domain.Entities.Skill", b =>
                {
                    b.HasOne("Domain.Entities.HairDresser", "Master")
                        .WithMany()
                        .HasForeignKey("MasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Treatment", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Treatments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Skill")
                        .WithMany("Treatments")
                        .HasForeignKey("SkillId");

                    b.HasOne("Domain.Entities.Employee")
                        .WithMany("WorkLoad")
                        .HasForeignKey("EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber");
                });
        }
    }
}
