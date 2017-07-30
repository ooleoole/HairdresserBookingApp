using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_Skills_SkillId",
                table: "Treatment");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Treatment_SkillId",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Treatment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Treatment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MasterCompanyId = table.Column<int>(nullable: true),
                    MasterEmploymentNumber = table.Column<int>(nullable: true),
                    MasterId = table.Column<int>(nullable: false),
                    MasterSocialSecurityNumber = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 96, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.UniqueConstraint("AK_Skills_Type_MasterId", x => new { x.Type, x.MasterId });
                    table.ForeignKey(
                        name: "FK_Skills_Employees_MasterEmploymentNumber_MasterCompanyId_MasterSocialSecurityNumber",
                        columns: x => new { x.MasterEmploymentNumber, x.MasterCompanyId, x.MasterSocialSecurityNumber },
                        principalTable: "Employees",
                        principalColumns: new[] { "EmploymentNumber", "CompanyId", "SocialSecurityNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_SkillId",
                table: "Treatment",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MasterEmploymentNumber_MasterCompanyId_MasterSocialSecurityNumber",
                table: "Skills",
                columns: new[] { "MasterEmploymentNumber", "MasterCompanyId", "MasterSocialSecurityNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_Skills_SkillId",
                table: "Treatment",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
