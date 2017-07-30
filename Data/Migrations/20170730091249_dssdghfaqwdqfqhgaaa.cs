using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dssdghfaqwdqfqhgaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeRange_DateBoundTimeRangeses_DateBoundTimeRangesId",
                table: "TimeRange");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRange_DateBoundTimeRangeses_DateBoundTimeRangesId",
                table: "TimeRange",
                column: "DateBoundTimeRangesId",
                principalTable: "DateBoundTimeRangeses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeRange_DateBoundTimeRangeses_DateBoundTimeRangesId",
                table: "TimeRange");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRange_DateBoundTimeRangeses_DateBoundTimeRangesId",
                table: "TimeRange",
                column: "DateBoundTimeRangesId",
                principalTable: "DateBoundTimeRangeses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
