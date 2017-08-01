using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class qfff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ScheduleBaseSettingses_LunchId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleBaseSettingses_WorkHoursId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettingses_LunchId",
                table: "ScheduleBaseSettingses",
                column: "LunchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettingses_WorkHoursId",
                table: "ScheduleBaseSettingses",
                column: "WorkHoursId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ScheduleBaseSettingses_LunchId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleBaseSettingses_WorkHoursId",
                table: "ScheduleBaseSettingses");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettingses_LunchId",
                table: "ScheduleBaseSettingses",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBaseSettingses_WorkHoursId",
                table: "ScheduleBaseSettingses",
                column: "WorkHoursId");
        }
    }
}
