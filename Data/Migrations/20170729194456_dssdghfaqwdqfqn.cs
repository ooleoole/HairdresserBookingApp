using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dssdghfaqwdqfqn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Schedule_ScheduleId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_ScheduleBaseSettings_ScheduleBaseSettingsId",
                table: "DayOff");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_DayId",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_Schedule_Tess",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_Schedule_ScheduleId1",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Employees_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBaseSettings_TimeRange_LunchId",
                table: "ScheduleBaseSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBaseSettings_Schedule_ScheduleId",
                table: "ScheduleBaseSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBaseSettings_TimeRange_WorkHoursId",
                table: "ScheduleBaseSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeRange_DateBoundTimeRanges_DateBoundTimeRangesId",
                table: "TimeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleBaseSettings",
                table: "ScheduleBaseSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateBoundTimeRanges",
                table: "DateBoundTimeRanges");

            migrationBuilder.RenameTable(
                name: "ScheduleBaseSettings",
                newName: "ScheduleBaseSettingses");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameTable(
                name: "DateBoundTimeRanges",
                newName: "DateBoundTimeRangeses");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleBaseSettings_WorkHoursId",
                table: "ScheduleBaseSettingses",
                newName: "IX_ScheduleBaseSettingses_WorkHoursId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleBaseSettings_ScheduleId",
                table: "ScheduleBaseSettingses",
                newName: "IX_ScheduleBaseSettingses_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleBaseSettings_LunchId",
                table: "ScheduleBaseSettingses",
                newName: "IX_ScheduleBaseSettingses_LunchId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Schedules",
                newName: "IX_Schedules_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRanges_ScheduleId1",
                table: "DateBoundTimeRangeses",
                newName: "IX_DateBoundTimeRangeses_ScheduleId1");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRanges_Tess",
                table: "DateBoundTimeRangeses",
                newName: "IX_DateBoundTimeRangeses_Tess");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRanges_DayId",
                table: "DateBoundTimeRangeses",
                newName: "IX_DateBoundTimeRangeses_DayId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Schedules",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleBaseSettingses",
                table: "ScheduleBaseSettingses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateBoundTimeRangeses",
                table: "DateBoundTimeRangeses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Schedules_ScheduleId",
                table: "Booking",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOff_ScheduleBaseSettingses_ScheduleBaseSettingsId",
                table: "DayOff",
                column: "ScheduleBaseSettingsId",
                principalTable: "ScheduleBaseSettingses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRangeses_WeekDay_DayId",
                table: "DateBoundTimeRangeses",
                column: "DayId",
                principalTable: "WeekDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_Tess",
                table: "DateBoundTimeRangeses",
                column: "Tess",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_ScheduleId1",
                table: "DateBoundTimeRangeses",
                column: "ScheduleId1",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Employees_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Schedules",
                columns: new[] { "EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber" },
                principalTable: "Employees",
                principalColumns: new[] { "CompanyId", "HairDresserId", "EmploymentNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBaseSettingses_TimeRange_LunchId",
                table: "ScheduleBaseSettingses",
                column: "LunchId",
                principalTable: "TimeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBaseSettingses_Schedules_ScheduleId",
                table: "ScheduleBaseSettingses",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBaseSettingses_TimeRange_WorkHoursId",
                table: "ScheduleBaseSettingses",
                column: "WorkHoursId",
                principalTable: "TimeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRange_DateBoundTimeRangeses_DateBoundTimeRangesId",
                table: "TimeRange",
                column: "DateBoundTimeRangesId",
                principalTable: "DateBoundTimeRangeses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Schedules_ScheduleId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_ScheduleBaseSettingses_ScheduleBaseSettingsId",
                table: "DayOff");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_WeekDay_DayId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_Tess",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_ScheduleId1",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Employees_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBaseSettingses_TimeRange_LunchId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBaseSettingses_Schedules_ScheduleId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBaseSettingses_TimeRange_WorkHoursId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeRange_DateBoundTimeRangeses_DateBoundTimeRangesId",
                table: "TimeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleBaseSettingses",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateBoundTimeRangeses",
                table: "DateBoundTimeRangeses");

            migrationBuilder.RenameTable(
                name: "ScheduleBaseSettingses",
                newName: "ScheduleBaseSettings");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameTable(
                name: "DateBoundTimeRangeses",
                newName: "DateBoundTimeRanges");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleBaseSettingses_WorkHoursId",
                table: "ScheduleBaseSettings",
                newName: "IX_ScheduleBaseSettings_WorkHoursId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleBaseSettingses_ScheduleId",
                table: "ScheduleBaseSettings",
                newName: "IX_ScheduleBaseSettings_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleBaseSettingses_LunchId",
                table: "ScheduleBaseSettings",
                newName: "IX_ScheduleBaseSettings_LunchId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Schedule",
                newName: "IX_Schedule_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRangeses_ScheduleId1",
                table: "DateBoundTimeRanges",
                newName: "IX_DateBoundTimeRanges_ScheduleId1");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRangeses_Tess",
                table: "DateBoundTimeRanges",
                newName: "IX_DateBoundTimeRanges_Tess");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRangeses_DayId",
                table: "DateBoundTimeRanges",
                newName: "IX_DateBoundTimeRanges_DayId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleBaseSettings",
                table: "ScheduleBaseSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateBoundTimeRanges",
                table: "DateBoundTimeRanges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Schedule_ScheduleId",
                table: "Booking",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayOff_ScheduleBaseSettings_ScheduleBaseSettingsId",
                table: "DayOff",
                column: "ScheduleBaseSettingsId",
                principalTable: "ScheduleBaseSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_DayId",
                table: "DateBoundTimeRanges",
                column: "DayId",
                principalTable: "WeekDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRanges_Schedule_Tess",
                table: "DateBoundTimeRanges",
                column: "Tess",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRanges_Schedule_ScheduleId1",
                table: "DateBoundTimeRanges",
                column: "ScheduleId1",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Employees_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Schedule",
                columns: new[] { "EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber" },
                principalTable: "Employees",
                principalColumns: new[] { "CompanyId", "HairDresserId", "EmploymentNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBaseSettings_TimeRange_LunchId",
                table: "ScheduleBaseSettings",
                column: "LunchId",
                principalTable: "TimeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBaseSettings_Schedule_ScheduleId",
                table: "ScheduleBaseSettings",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBaseSettings_TimeRange_WorkHoursId",
                table: "ScheduleBaseSettings",
                column: "WorkHoursId",
                principalTable: "TimeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRange_DateBoundTimeRanges_DateBoundTimeRangesId",
                table: "TimeRange",
                column: "DateBoundTimeRangesId",
                principalTable: "DateBoundTimeRanges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
