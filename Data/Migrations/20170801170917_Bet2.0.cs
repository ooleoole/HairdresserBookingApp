using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Bet20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Employees_EmployeeId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleBaseSettingses_Schedules_ScheduleId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleBaseSettingses_ScheduleId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_EmployeeId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleBaseSettingsId",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId1",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_ScheduleId",
                table: "Employees",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleBaseSettingsId",
                table: "Schedules",
                column: "ScheduleBaseSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ScheduleId1",
                table: "Employees",
                column: "ScheduleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Schedules_ScheduleId1",
                table: "Employees",
                column: "ScheduleId1",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_ScheduleBaseSettingses_ScheduleBaseSettingsId",
                table: "Schedules",
                column: "ScheduleBaseSettingsId",
                principalTable: "ScheduleBaseSettingses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Schedules_ScheduleId1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_ScheduleBaseSettingses_ScheduleBaseSettingsId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_ScheduleBaseSettingsId",
                table: "Schedules");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_ScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ScheduleId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ScheduleBaseSettingsId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ScheduleId1",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "ScheduleBaseSettingses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettingses_ScheduleId",
                table: "ScheduleBaseSettingses",
                column: "ScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_EmployeeId",
                table: "Schedules",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Employees_EmployeeId",
                table: "Schedules",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmploymentNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleBaseSettingses_Schedules_ScheduleId",
                table: "ScheduleBaseSettingses",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
