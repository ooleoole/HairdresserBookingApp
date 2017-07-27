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
            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_Skills_SkillId",
                table: "Treatment");

            migrationBuilder.DropTable(
                name: "MasteredSkill");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Treatment_EmployeeId_SkillId_CompanyId",
                table: "Treatment");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Skills_Type",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "WorkingHoursEnd",
                table: "HairDresser");

            migrationBuilder.DropColumn(
                name: "WorkingHoursStart",
                table: "HairDresser");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "Treatment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Treatment",
                maxLength: 96,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MasterId",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingHoursEnd",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingHoursStart",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Costumers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "NotifyExtraCostOrTime",
                table: "Costumers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "HairDresser",
                maxLength: 56,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Treatment_Type_CompanyId",
                table: "Treatment",
                columns: new[] { "Type", "CompanyId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Skills_Type_MasterId",
                table: "Skills",
                columns: new[] { "Type", "MasterId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Costumers_Email",
                table: "Costumers",
                column: "Email");

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
                name: "WeekDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDay", x => x.Id);
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
                name: "DateBoundTimeRanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DayId = table.Column<int>(nullable: true),
                    NoneStandardAvailableWorkDayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateBoundTimeRanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateBoundTimeRanges_WeekDay_DayId",
                        column: x => x.DayId,
                        principalTable: "WeekDay",
                        principalColumn: "Id",
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
                name: "DayOff",
                columns: table => new
                {
                    ScheduleBaseSettingsId = table.Column<int>(nullable: false),
                    WeekDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOff", x => new { x.ScheduleBaseSettingsId, x.WeekDayId });
                    table.ForeignKey(
                        name: "FK_DayOff_ScheduleBaseSettings_ScheduleBaseSettingsId",
                        column: x => x.ScheduleBaseSettingsId,
                        principalTable: "ScheduleBaseSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayOff_WeekDay_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "WeekDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MasterId",
                table: "Skills",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CostumerId",
                table: "Booking",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ScheduleId",
                table: "Booking",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOff_WeekDayId",
                table: "DayOff",
                column: "WeekDayId");

            migrationBuilder.CreateIndex(
                name: "IX_NoneStandardAvailableWorkDay_ScheduleId",
                table: "NoneStandardAvailableWorkDay",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHairDresser_TreatmentId",
                table: "TreatmentHairDresser",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DateBoundTimeRanges_DayId",
                table: "DateBoundTimeRanges",
                column: "DayId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_HairDresser_MasterId",
                table: "Skills",
                column: "MasterId",
                principalTable: "HairDresser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_Skills_SkillId",
                table: "Treatment",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_HairDresser_MasterId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_Skills_SkillId",
                table: "Treatment");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "DayOff");

            migrationBuilder.DropTable(
                name: "NoneStandardAvailableWorkDay");

            migrationBuilder.DropTable(
                name: "TreatmentHairDresser");

            migrationBuilder.DropTable(
                name: "ScheduleBaseSettings");

            migrationBuilder.DropTable(
                name: "TimeRange");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "DateBoundTimeRanges");

            migrationBuilder.DropTable(
                name: "WeekDay");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Treatment_Type_CompanyId",
                table: "Treatment");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Skills_Type_MasterId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_MasterId",
                table: "Skills");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Costumers_Email",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "WorkingHoursEnd",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkingHoursStart",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NotifyExtraCostOrTime",
                table: "Costumers");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "Treatment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Treatment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Costumers",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "HairDresser",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 56);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingHoursEnd",
                table: "HairDresser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingHoursStart",
                table: "HairDresser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Treatment_EmployeeId_SkillId_CompanyId",
                table: "Treatment",
                columns: new[] { "EmployeeId", "SkillId", "CompanyId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Skills_Type",
                table: "Skills",
                column: "Type");

            migrationBuilder.CreateTable(
                name: "MasteredSkill",
                columns: table => new
                {
                    HairDresserId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasteredSkill", x => new { x.HairDresserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_MasteredSkill_HairDresser_HairDresserId",
                        column: x => x.HairDresserId,
                        principalTable: "HairDresser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasteredSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasteredSkill_SkillId",
                table: "MasteredSkill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_Skills_SkillId",
                table: "Treatment",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
