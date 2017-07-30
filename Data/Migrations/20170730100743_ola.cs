using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_DisabledHoursScheduleId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_NoneStandardAvailableHoursScheduleId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_DisabledHoursScheduleId",
                table: "DateBoundTimeRangeses",
                column: "DisabledHoursScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_NoneStandardAvailableHoursScheduleId",
                table: "DateBoundTimeRangeses",
                column: "NoneStandardAvailableHoursScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_DisabledHoursScheduleId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_NoneStandardAvailableHoursScheduleId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_DisabledHoursScheduleId",
                table: "DateBoundTimeRangeses",
                column: "DisabledHoursScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_NoneStandardAvailableHoursScheduleId",
                table: "DateBoundTimeRangeses",
                column: "NoneStandardAvailableHoursScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
