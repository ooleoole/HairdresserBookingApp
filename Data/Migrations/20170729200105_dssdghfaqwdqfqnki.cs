using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dssdghfaqwdqfqnki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_Tess",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_ScheduleId1",
                table: "DateBoundTimeRangeses");

            migrationBuilder.RenameColumn(
                name: "ScheduleId1",
                table: "DateBoundTimeRangeses",
                newName: "NoneStandardAvailableHoursScheduleId");

            migrationBuilder.RenameColumn(
                name: "Tess",
                table: "DateBoundTimeRangeses",
                newName: "DisabledHoursScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRangeses_ScheduleId1",
                table: "DateBoundTimeRangeses",
                newName: "IX_DateBoundTimeRangeses_NoneStandardAvailableHoursScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRangeses_Tess",
                table: "DateBoundTimeRangeses",
                newName: "IX_DateBoundTimeRangeses_DisabledHoursScheduleId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_DisabledHoursScheduleId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_Schedules_NoneStandardAvailableHoursScheduleId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.RenameColumn(
                name: "NoneStandardAvailableHoursScheduleId",
                table: "DateBoundTimeRangeses",
                newName: "ScheduleId1");

            migrationBuilder.RenameColumn(
                name: "DisabledHoursScheduleId",
                table: "DateBoundTimeRangeses",
                newName: "Tess");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRangeses_NoneStandardAvailableHoursScheduleId",
                table: "DateBoundTimeRangeses",
                newName: "IX_DateBoundTimeRangeses_ScheduleId1");

            migrationBuilder.RenameIndex(
                name: "IX_DateBoundTimeRangeses_DisabledHoursScheduleId",
                table: "DateBoundTimeRangeses",
                newName: "IX_DateBoundTimeRangeses_Tess");

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
        }
    }
}
