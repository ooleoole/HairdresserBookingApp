using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class Beta : Migration
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
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
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
                    CompanyId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(maxLength: 36, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(maxLength: 36, nullable: false),
                    Notes = table.Column<string>(maxLength: 256, nullable: true),
                    NotifyExtraCostOrTime = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.Id);
                    table.UniqueConstraint("AK_Costumers_FirstName_LastName_AddressId_CompanyId", x => new { x.FirstName, x.LastName, x.AddressId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_Costumers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Costumers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmploymentNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 56, nullable: false),
                    FirstName = table.Column<string>(maxLength: 36, nullable: false),
                    LastName = table.Column<string>(maxLength: 36, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    SocialSecurityNumber = table.Column<string>(maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmploymentNumber);
                    table.UniqueConstraint("AK_Employees_EmploymentNumber_CompanyId_SocialSecurityNumber", x => new { x.EmploymentNumber, x.CompanyId, x.SocialSecurityNumber });
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
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
                    Notes = table.Column<string>(maxLength: 256, nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmploymentNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentPerformer",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    TreatmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentPerformer", x => new { x.EmployeeId, x.TreatmentId });
                    table.ForeignKey(
                        name: "FK_TreatmentPerformer_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmploymentNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentPerformer_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
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
                    PerformerId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false),
                    TreatmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.UniqueConstraint("AK_Bookings_TreatmentId_CostumerId_DateAndTime", x => new { x.TreatmentId, x.CostumerId, x.DateAndTime });
                    table.ForeignKey(
                        name: "FK_Bookings_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Employees_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Employees",
                        principalColumn: "EmploymentNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DateBoundTimeRangeses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    DisabledHoursScheduleId = table.Column<int>(nullable: true),
                    NoneStandardAvailableHoursScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateBoundTimeRangeses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateBoundTimeRangeses_Schedules_DisabledHoursScheduleId",
                        column: x => x.DisabledHoursScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DateBoundTimeRangeses_Schedules_NoneStandardAvailableHoursScheduleId",
                        column: x => x.NoneStandardAvailableHoursScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingManagement",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false),
                    HairDresserId = table.Column<int>(nullable: false),
                    Action = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingManagement", x => new { x.BookingId, x.HairDresserId, x.Action });
                    table.ForeignKey(
                        name: "FK_BookingManagement_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingManagement_Employees_HairDresserId",
                        column: x => x.HairDresserId,
                        principalTable: "Employees",
                        principalColumn: "EmploymentNumber",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_TimeRange_DateBoundTimeRangeses_DateBoundTimeRangesId",
                        column: x => x.DateBoundTimeRangesId,
                        principalTable: "DateBoundTimeRangeses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleBaseSettingses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LunchId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false),
                    WorkHoursId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleBaseSettingses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleBaseSettingses_TimeRange_LunchId",
                        column: x => x.LunchId,
                        principalTable: "TimeRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleBaseSettingses_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduleBaseSettingses_TimeRange_WorkHoursId",
                        column: x => x.WorkHoursId,
                        principalTable: "TimeRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayOff",
                columns: table => new
                {
                    ScheduleBaseSettingsId = table.Column<int>(nullable: false),
                    WeekDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOff", x => new { x.ScheduleBaseSettingsId, x.WeekDay });
                    table.ForeignKey(
                        name: "FK_DayOff_ScheduleBaseSettingses_ScheduleBaseSettingsId",
                        column: x => x.ScheduleBaseSettingsId,
                        principalTable: "ScheduleBaseSettingses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CostumerId",
                table: "Bookings",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PerformerId",
                table: "Bookings",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ScheduleId",
                table: "Bookings",
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
                name: "IX_Costumers_CompanyId",
                table: "Costumers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingManagement_HairDresserId",
                table: "BookingManagement",
                column: "HairDresserId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentPerformer_TreatmentId",
                table: "TreatmentPerformer",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EmployeeId",
                table: "Schedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettingses_LunchId",
                table: "ScheduleBaseSettingses",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettingses_ScheduleId",
                table: "ScheduleBaseSettingses",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettingses_WorkHoursId",
                table: "ScheduleBaseSettingses",
                column: "WorkHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_DateBoundTimeRangeses_DisabledHoursScheduleId",
                table: "DateBoundTimeRangeses",
                column: "DisabledHoursScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DateBoundTimeRangeses_NoneStandardAvailableHoursScheduleId",
                table: "DateBoundTimeRangeses",
                column: "NoneStandardAvailableHoursScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeRange_DateBoundTimeRangesId",
                table: "TimeRange",
                column: "DateBoundTimeRangesId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_CompanyId",
                table: "Treatment",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingManagement");

            migrationBuilder.DropTable(
                name: "DayOff");

            migrationBuilder.DropTable(
                name: "TreatmentPerformer");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ScheduleBaseSettingses");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "TimeRange");

            migrationBuilder.DropTable(
                name: "DateBoundTimeRangeses");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
