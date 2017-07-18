using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class V02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorksAtRealtions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_SocialSecurityNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SocialSecurityNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkingHoursEnd",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkingHoursStart",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HairDresserId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentNumber",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                columns: new[] { "CompanyId", "HairDresserId", "EmploymentNumber" });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 96, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.UniqueConstraint("AK_Skills_Type", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "HairDresser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 36, nullable: false),
                    LastName = table.Column<string>(maxLength: 36, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 11, nullable: false),
                    SocialSecurityNumber = table.Column<string>(maxLength: 13, nullable: false),
                    WorkingHoursEnd = table.Column<DateTime>(nullable: false),
                    WorkingHoursStart = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairDresser", x => x.Id);
                    table.UniqueConstraint("AK_HairDresser_SocialSecurityNumber", x => x.SocialSecurityNumber);
                    table.ForeignKey(
                        name: "FK_HairDresser_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasePrice = table.Column<int>(nullable: false),
                    BaseTime = table.Column<TimeSpan>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    EmployeeCompanyId = table.Column<int>(nullable: true),
                    EmployeeEmploymentNumber = table.Column<int>(nullable: true),
                    EmployeeHairDresserId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 256, nullable: true),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.UniqueConstraint("AK_Treatment_EmployeeId_SkillId_CompanyId", x => new { x.EmployeeId, x.SkillId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_Treatment_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatment_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatment_Employees_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                        columns: x => new { x.EmployeeCompanyId, x.EmployeeHairDresserId, x.EmployeeEmploymentNumber },
                        principalTable: "Employees",
                        principalColumns: new[] { "CompanyId", "HairDresserId", "EmploymentNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasteredSkill",
                columns: table => new
                {
                    HairDresserId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasteredSkill", x => new { x.HairDresserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_MasteredSkill_HairDresser_HairDresserId",
                        column: x => x.HairDresserId,
                        principalTable: "HairDresser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasteredSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HairDresserId",
                table: "Employees",
                column: "HairDresserId");

            migrationBuilder.CreateIndex(
                name: "IX_MasteredSkill_SkillId",
                table: "MasteredSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_CompanyId",
                table: "Treatment",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_SkillId",
                table: "Treatment",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_EmployeeCompanyId_EmployeeHairDresserId_EmployeeEmploymentNumber",
                table: "Treatment",
                columns: new[] { "EmployeeCompanyId", "EmployeeHairDresserId", "EmployeeEmploymentNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_HairDresser_AddressId",
                table: "HairDresser",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_HairDresser_HairDresserId",
                table: "Employees",
                column: "HairDresserId",
                principalTable: "HairDresser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_HairDresser_HairDresserId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "MasteredSkill");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "HairDresser");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_HairDresserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HairDresserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmploymentNumber",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Employees",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                maxLength: 36,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SocialSecurityNumber",
                table: "Employees",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingHoursEnd",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkingHoursStart",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_SocialSecurityNumber",
                table: "Employees",
                column: "SocialSecurityNumber");

            migrationBuilder.CreateTable(
                name: "WorksAtRealtions",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksAtRealtions", x => new { x.CompanyId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_WorksAtRealtions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksAtRealtions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorksAtRealtions_EmployeeId",
                table: "WorksAtRealtions",
                column: "EmployeeId");
        }
    }
}
