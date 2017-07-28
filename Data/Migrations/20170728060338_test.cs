using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Co = table.Column<string>(maxLength: 96, nullable: true),
                    Street = table.Column<string>(maxLength: 96, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekDay",
                columns: table => new
                {
                    Day = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDay", x => x.Day);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.UniqueConstraint("AK_Companies_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(maxLength: 36, nullable: false),
                    Notes = table.Column<string>(maxLength: 256, nullable: true),
                    NotifyExtraCostOrTime = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.Id);
                    table.UniqueConstraint("AK_Costumers_Email", x => x.Email);
                    table.UniqueConstraint("AK_Costumers_FirstName_LastName_AddressId", x => new { x.FirstName, x.LastName, x.AddressId });
                    table.ForeignKey(
                        name: "FK_Costumers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HairDresser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(maxLength: 56, nullable: false),
                    FirstName = table.Column<string>(maxLength: 36, nullable: false),
                    LastName = table.Column<string>(maxLength: 36, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    SocialSecurityNumber = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairDresser", x => x.Id);
                    table.UniqueConstraint("AK_HairDresser_SocialSecurityNumber", x => x.SocialSecurityNumber);
                    table.ForeignKey(
                        name: "FK_HairDresser_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DateBoundTimeRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Day1 = table.Column<int>(nullable: true),
                    NoneStandardAvailableWorkDayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateBoundTimeRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateBoundTimeRanges_WeekDay_Day1",
                        column: x => x.Day1,
                        principalTable: "WeekDay",
                        principalColumn: "Day",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCostumers",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    CostumerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCostumers", x => new { x.CompanyId, x.CostumerId });
                    table.ForeignKey(
                        name: "FK_CompanyCostumers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCostumers_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    HairDresserId = table.Column<int>(nullable: false),
                    EmploymentNumber = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    WorkingHoursEnd = table.Column<DateTime>(nullable: false),
                    WorkingHoursStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => new { x.CompanyId, x.HairDresserId, x.EmploymentNumber });
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_HairDresser_HairDresserId",
                        column: x => x.HairDresserId,
                        principalTable: "HairDresser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MasterId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 96, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.UniqueConstraint("AK_Skills_Type_MasterId", x => new { x.Type, x.MasterId });
                    table.ForeignKey(
                        name: "FK_Skills_HairDresser_MasterId",
                        column: x => x.MasterId,
                        principalTable: "HairDresser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeRange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateBoundTimeRangesId = table.Column<int>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeRange_DateBoundTimeRanges_DateBoundTimeRangesId",
                        column: x => x.DateBoundTimeRangesId,
                        principalTable: "DateBoundTimeRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeCompanyId = table.Column<int>(nullable: true),
                    EmployeeEmploymentNumber = table.Column<int>(nullable: true),
                    EmployeeHairDresserId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Employees_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                        columns: x => new { x.EmployeeCompanyId, x.EmployeeHairDresserId, x.EmployeeEmploymentNumber },
                        principalTable: "Employees",
                        principalColumns: new[] { "CompanyId", "HairDresserId", "EmploymentNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasePrice = table.Column<int>(nullable: false),
                    BaseTime = table.Column<TimeSpan>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    EmployeeCompanyId = table.Column<int>(nullable: true),
                    EmployeeEmploymentNumber = table.Column<int>(nullable: true),
                    EmployeeHairDresserId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(maxLength: 256, nullable: true),
                    SkillId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(maxLength: 96, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.UniqueConstraint("AK_Treatment_Type_CompanyId", x => new { x.Type, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_Treatment_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatment_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Employees_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                        columns: x => new { x.EmployeeCompanyId, x.EmployeeHairDresserId, x.EmployeeEmploymentNumber },
                        principalTable: "Employees",
                        principalColumns: new[] { "CompanyId", "HairDresserId", "EmploymentNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoneStandardAvailableWorkDay",
                columns: table => new
                {
                    DateBoundTimeRangesId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoneStandardAvailableWorkDay", x => x.DateBoundTimeRangesId);
                    table.ForeignKey(
                        name: "FK_NoneStandardAvailableWorkDay_DateBoundTimeRanges_DateBoundTimeRangesId",
                        column: x => x.DateBoundTimeRangesId,
                        principalTable: "DateBoundTimeRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoneStandardAvailableWorkDay_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleBaseSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LunchId = table.Column<int>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: false),
                    WorkHoursId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleBaseSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleBaseSettings_TimeRange_LunchId",
                        column: x => x.LunchId,
                        principalTable: "TimeRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleBaseSettings_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleBaseSettings_TimeRange_WorkHoursId",
                        column: x => x.WorkHoursId,
                        principalTable: "TimeRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CostumerId = table.Column<int>(nullable: false),
                    DateAndTime = table.Column<DateTime>(nullable: false),
                    EmployeeIsNotified = table.Column<bool>(nullable: false),
                    ExtraCost = table.Column<int>(nullable: false),
                    ExtraTime = table.Column<TimeSpan>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(maxLength: 256, nullable: true),
                    ScheduleId = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
                    TotalTime = table.Column<TimeSpan>(nullable: false),
                    TreatmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.UniqueConstraint("AK_Booking_TreatmentId_CostumerId_DateAndTime", x => new { x.TreatmentId, x.CostumerId, x.DateAndTime });
                    table.ForeignKey(
                        name: "FK_Booking_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentHairDresser",
                columns: table => new
                {
                    HairDresserId = table.Column<int>(nullable: false),
                    TreatmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentHairDresser", x => new { x.HairDresserId, x.TreatmentId });
                    table.ForeignKey(
                        name: "FK_TreatmentHairDresser_HairDresser_HairDresserId",
                        column: x => x.HairDresserId,
                        principalTable: "HairDresser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentHairDresser_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayOff",
                columns: table => new
                {
                    ScheduleBaseSettingsId = table.Column<int>(nullable: false),
                    DayId = table.Column<int>(nullable: false),
                    Day1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOff", x => new { x.ScheduleBaseSettingsId, x.DayId });
                    table.ForeignKey(
                        name: "FK_DayOff_WeekDay_Day1",
                        column: x => x.Day1,
                        principalTable: "WeekDay",
                        principalColumn: "Day",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayOff_ScheduleBaseSettings_ScheduleBaseSettingsId",
                        column: x => x.ScheduleBaseSettingsId,
                        principalTable: "ScheduleBaseSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CostumerId",
                table: "Booking",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ScheduleId",
                table: "Booking",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Costumers_AddressId",
                table: "Costumers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HairDresserId",
                table: "Employees",
                column: "HairDresserId");

            migrationBuilder.CreateIndex(
                name: "IX_HairDresser_AddressId",
                table: "HairDresser",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCostumers_CostumerId",
                table: "CompanyCostumers",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOff_Day1",
                table: "DayOff",
                column: "Day1");

            migrationBuilder.CreateIndex(
                name: "IX_NoneStandardAvailableWorkDay_ScheduleId",
                table: "NoneStandardAvailableWorkDay",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHairDresser_TreatmentId",
                table: "TreatmentHairDresser",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DateBoundTimeRanges_Day1",
                table: "DateBoundTimeRanges",
                column: "Day1");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Schedule",
                columns: new[] { "EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettings_LunchId",
                table: "ScheduleBaseSettings",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettings_ScheduleId",
                table: "ScheduleBaseSettings",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettings_WorkHoursId",
                table: "ScheduleBaseSettings",
                column: "WorkHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRange_DateBoundTimeRangesId",
                table: "TimeRange",
                column: "DateBoundTimeRangesId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MasterId",
                table: "Skills",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_CompanyId",
                table: "Treatment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_SkillId",
                table: "Treatment",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Treatment",
                columns: new[] { "EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "CompanyCostumers");

            migrationBuilder.DropTable(
                name: "DayOff");

            migrationBuilder.DropTable(
                name: "NoneStandardAvailableWorkDay");

            migrationBuilder.DropTable(
                name: "TreatmentHairDresser");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.DropTable(
                name: "ScheduleBaseSettings");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "TimeRange");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "DateBoundTimeRanges");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "WeekDay");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "HairDresser");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
