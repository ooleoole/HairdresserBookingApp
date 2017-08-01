using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class wbw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedules_ScheduleBaseSettingsId",
                table: "Schedules");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleBaseSettingsId",
                table: "Schedules",
                column: "ScheduleBaseSettingsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Schedules_ScheduleBaseSettingsId",
                table: "Schedules");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ScheduleBaseSettingsId",
                table: "Schedules",
                column: "ScheduleBaseSettingsId");
        }
    }
}
