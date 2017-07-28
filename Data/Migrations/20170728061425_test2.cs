using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_WeekDay_Day1",
                table: "DayOff");

            migrationBuilder.DropIndex(
                name: "IX_DayOff_Day1",
                table: "DayOff");

            migrationBuilder.DropColumn(
                name: "Day1",
                table: "DayOff");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "DayOff",
                newName: "WeekDayId");

            migrationBuilder.AddColumn<int>(
                name: "WeekDayDay",
                table: "DayOff",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayOff_WeekDayDay",
                table: "DayOff",
                column: "WeekDayDay");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayDay",
                table: "DayOff",
                column: "WeekDayDay",
                principalTable: "WeekDay",
                principalColumn: "Day",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayDay",
                table: "DayOff");

            migrationBuilder.DropIndex(
                name: "IX_DayOff_WeekDayDay",
                table: "DayOff");

            migrationBuilder.DropColumn(
                name: "WeekDayDay",
                table: "DayOff");

            migrationBuilder.RenameColumn(
                name: "WeekDayId",
                table: "DayOff",
                newName: "DayId");

            migrationBuilder.AddColumn<int>(
                name: "Day1",
                table: "DayOff",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayOff_Day1",
                table: "DayOff",
                column: "Day1");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOff_WeekDay_Day1",
                table: "DayOff",
                column: "Day1",
                principalTable: "WeekDay",
                principalColumn: "Day",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
