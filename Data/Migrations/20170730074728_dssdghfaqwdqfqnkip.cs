using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dssdghfaqwdqfqnkip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayId",
                table: "DayOff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayOff",
                table: "DayOff");

            migrationBuilder.DropIndex(
                name: "IX_DayOff_WeekDayId",
                table: "DayOff");

            migrationBuilder.DropColumn(
                name: "WeekDayId",
                table: "DayOff");

            migrationBuilder.AddColumn<int>(
                name: "WeekDay",
                table: "DayOff",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayOff",
                table: "DayOff",
                columns: new[] { "ScheduleBaseSettingsId", "WeekDay" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DayOff",
                table: "DayOff");

            migrationBuilder.DropColumn(
                name: "WeekDay",
                table: "DayOff");

            migrationBuilder.AddColumn<int>(
                name: "WeekDayId",
                table: "DayOff",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayOff",
                table: "DayOff",
                columns: new[] { "ScheduleBaseSettingsId", "WeekDayId" });

            migrationBuilder.CreateIndex(
                name: "IX_DayOff_WeekDayId",
                table: "DayOff",
                column: "WeekDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayId",
                table: "DayOff",
                column: "WeekDayId",
                principalTable: "WeekDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
