using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class qwrt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_AddressId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Costumers_AddressId",
                table: "Costumers");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Costumers_AddressId",
                table: "Costumers",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_AddressId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Costumers_AddressId",
                table: "Costumers");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Costumers_AddressId",
                table: "Costumers",
                column: "AddressId");
        }
    }
}
