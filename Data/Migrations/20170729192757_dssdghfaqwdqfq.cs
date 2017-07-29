using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dssdghfaqwdqfq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_Schedule_Tess",
                table: "DateBoundTimeRanges");

            migrationBuilder.AlterColumn<int>(
                name: "Tess",
                table: "DateBoundTimeRanges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRanges_Schedule_Tess",
                table: "DateBoundTimeRanges",
                column: "Tess",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRanges_Schedule_Tess",
                table: "DateBoundTimeRanges");

            migrationBuilder.AlterColumn<int>(
                name: "Tess",
                table: "DateBoundTimeRanges",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRanges_Schedule_Tess",
                table: "DateBoundTimeRanges",
                column: "Tess",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
