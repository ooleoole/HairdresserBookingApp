using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayId",
                table: "DayOff");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_DayId",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekDay",
                table: "WeekDay");

            migrationBuilder.DropIndex(
                name: "IX_DateBoundTimeRanges_DayId",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropIndex(
                name: "IX_DayOff_WeekDayId",
                table: "DayOff");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WeekDay");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "DateBoundTimeRanges");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "DateBoundTimeRanges",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeekDayDayOfWeek",
                table: "DayOff",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekDay",
                table: "WeekDay",
                column: "DayOfWeek");

            migrationBuilder.CreateIndex(
                name: "IX_DateBoundTimeRanges_DayOfWeek",
                table: "DateBoundTimeRanges",
                column: "DayOfWeek");

            migrationBuilder.CreateIndex(
                name: "IX_DayOff_WeekDayDayOfWeek",
                table: "DayOff",
                column: "WeekDayDayOfWeek");

            migrationBuilder.AddForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayDayOfWeek",
                table: "DayOff",
                column: "WeekDayDayOfWeek",
                principalTable: "WeekDay",
                principalColumn: "DayOfWeek",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_DayOfWeek",
                table: "DateBoundTimeRanges",
                column: "DayOfWeek",
                principalTable: "WeekDay",
                principalColumn: "DayOfWeek",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayOff_WeekDay_WeekDayDayOfWeek",
                table: "DayOff");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_WeekDay_DayOfWeek",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeekDay",
                table: "WeekDay");

            migrationBuilder.DropIndex(
                name: "IX_DateBoundTimeRanges_DayOfWeek",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropIndex(
                name: "IX_DayOff_WeekDayDayOfWeek",
                table: "DayOff");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "DateBoundTimeRanges");

            migrationBuilder.DropColumn(
                name: "WeekDayDayOfWeek",
                table: "DayOff");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WeekDay",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "DateBoundTimeRanges",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeekDay",
                table: "WeekDay",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DateBoundTimeRanges_DayId",
                table: "DateBoundTimeRanges",
                column: "DayId");

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
    }
}
