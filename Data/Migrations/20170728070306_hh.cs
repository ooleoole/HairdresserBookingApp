using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class hh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayDay",
                table: "DayOff");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_Day1",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekDay",
                table: "WeekDay");

            migrationBuilder.DropIndex(
                name: "IX_DayOff_WeekDayDay",
                table: "DayOff");

            migrationBuilder.DropColumn(
                name: "WeekDayDay",
                table: "DayOff");

            migrationBuilder.RenameColumn(
                name: "Day1",
                table: "DateBoundTimeRanges",
                newName: "DayId");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRanges_Day1",
                table: "DateBoundTimeRanges",
                newName: "IX_DateBoundTimeRanges_DayId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WeekDay",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_WeekDay_Day",
                table: "WeekDay",
                column: "Day");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekDay",
                table: "WeekDay",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_DayId",
                table: "DateBoundTimeRanges",
                column: "DayId",
                principalTable: "WeekDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayId",
                table: "DayOff");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_DayId",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_WeekDay_Day",
                table: "WeekDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekDay",
                table: "WeekDay");

            migrationBuilder.DropIndex(
                name: "IX_DayOff_WeekDayId",
                table: "DayOff");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WeekDay");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "DateBoundTimeRanges",
                newName: "Day1");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRanges_DayId",
                table: "DateBoundTimeRanges",
                newName: "IX_DateBoundTimeRanges_Day1");

            migrationBuilder.AddColumn<int>(
                name: "WeekDayDay",
                table: "DayOff",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekDay",
                table: "WeekDay",
                column: "Day");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_Day1",
                table: "DateBoundTimeRanges",
                column: "Day1",
                principalTable: "WeekDay",
                principalColumn: "Day",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
