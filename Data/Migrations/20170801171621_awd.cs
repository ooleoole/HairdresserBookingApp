using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class awd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Schedules_ScheduleId1",
                table: "Employees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_ScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ScheduleId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ScheduleId1",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Schedules_ScheduleId",
                table: "Employees",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Schedules_ScheduleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId1",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_ScheduleId",
                table: "Employees",
                column: "ScheduleId");

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
        }
    }
}
