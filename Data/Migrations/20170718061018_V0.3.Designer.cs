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
    [Migration("20170718061018_V0.3")]
    partial class V03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.HasAlternateKey("FirstName", "LastName", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("Costumers");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("HairDresserId");

                    b.Property<int>("EmploymentNumber");

                    b.Property<int?>("AddressId");

                    b.HasKey("CompanyId", "HairDresserId", "EmploymentNumber");

                    b.HasIndex("AddressId");

                    b.HasIndex("HairDresserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.CompanyCostumer", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("CostumerId");

                    b.HasKey("CompanyId", "CostumerId");

                    b.HasIndex("CostumerId");

                    b.ToTable("CompanyCostumers");
                });

            modelBuilder.Entity("Domain.Entities.Junctions.MasteredSkill", b =>
                {
                    b.Property<int>("HairDresserId");

                    b.Property<int>("SkillId");

                    b.HasKey("HairDresserId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("MasteredSkill");
                });

            modelBuilder.Entity("Domain.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(96);

                    b.HasKey("Id");

                    b.HasAlternateKey("Type");

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

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Notes")
                        .HasMaxLength(256);

                    b.Property<int>("SkillId");

                    b.HasKey("Id");

                    b.HasAlternateKey("EmployeeId", "SkillId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SkillId");

                    b.HasIndex("EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Domain.HairDresser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<string>("Email")
                        .IsRequired();

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

                    b.Property<DateTime>("WorkingHoursEnd");

                    b.Property<DateTime>("WorkingHoursStart");

                    b.HasKey("Id");

                    b.HasAlternateKey("SocialSecurityNumber");

                    b.HasIndex("AddressId");

                    b.ToTable("HairDresser");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Companies")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Costumer", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany("Costumers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.HasOne("Domain.Entities.Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId");

                    b.HasOne("Domain.Entities.Company", "Employment")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.HairDresser", "HairDresser")
                        .WithMany("Employments")
                        .HasForeignKey("HairDresserId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("Domain.Entities.Junctions.MasteredSkill", b =>
                {
                    b.HasOne("Domain.HairDresser", "HairDresser")
                        .WithMany("MasteredSkills")
                        .HasForeignKey("HairDresserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Skill", "Skill")
                        .WithMany("Masters")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entities.Treatment", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Treatments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Skill", "Skill")
                        .WithMany("Treatments")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("Treatments")
                        .HasForeignKey("EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber");
                });

            modelBuilder.Entity("Domain.HairDresser", b =>
                {
                    b.HasOne("Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });
        }
    }
}
