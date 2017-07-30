using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ola3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Costumers_CostumerId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_TimeRange_ExtraTimeId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Schedules_ScheduleId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_TimeRange_TotalTimeId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Treatment_TreatmentId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Booking_TreatmentId_CostumerId_DateAndTime",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_TotalTimeId",
                table: "Bookings",
                newName: "IX_Bookings_TotalTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ScheduleId",
                table: "Bookings",
                newName: "IX_Bookings_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ExtraTimeId",
                table: "Bookings",
                newName: "IX_Bookings_ExtraTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_CostumerId",
                table: "Bookings",
                newName: "IX_Bookings_CostumerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Bookings_TreatmentId_CostumerId_DateAndTime",
                table: "Bookings",
                columns: new[] { "TreatmentId", "CostumerId", "DateAndTime" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Costumers_CostumerId",
                table: "Bookings",
                column: "CostumerId",
                principalTable: "Costumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TimeRange_ExtraTimeId",
                table: "Bookings",
                column: "ExtraTimeId",
                principalTable: "TimeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Schedules_ScheduleId",
                table: "Bookings",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TimeRange_TotalTimeId",
                table: "Bookings",
                column: "TotalTimeId",
                principalTable: "TimeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Treatment_TreatmentId",
                table: "Bookings",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Costumers_CostumerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TimeRange_ExtraTimeId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Schedules_ScheduleId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TimeRange_TotalTimeId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Treatment_TreatmentId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Bookings_TreatmentId_CostumerId_DateAndTime",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TotalTimeId",
                table: "Booking",
                newName: "IX_Booking_TotalTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ScheduleId",
                table: "Booking",
                newName: "IX_Booking_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ExtraTimeId",
                table: "Booking",
                newName: "IX_Booking_ExtraTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CostumerId",
                table: "Booking",
                newName: "IX_Booking_CostumerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Booking_TreatmentId_CostumerId_DateAndTime",
                table: "Booking",
                columns: new[] { "TreatmentId", "CostumerId", "DateAndTime" });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Costumers_CostumerId",
                table: "Booking",
                column: "CostumerId",
                principalTable: "Costumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_TimeRange_ExtraTimeId",
                table: "Booking",
                column: "ExtraTimeId",
                principalTable: "TimeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Schedules_ScheduleId",
                table: "Booking",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_TimeRange_TotalTimeId",
                table: "Booking",
                column: "TotalTimeId",
                principalTable: "TimeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Treatment_TreatmentId",
                table: "Booking",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
