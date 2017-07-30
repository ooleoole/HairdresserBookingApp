using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Migrations
{
    public partial class dssdghfaqwdqfqhg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateBoundTimeRangeses_WeekDay_DayId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropTable(
                name: "WeekDay");

            migrationBuilder.DropIndex(
                name: "IX_DateBoundTimeRangeses_DayId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "DateBoundTimeRangeses");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "DateBoundTimeRangeses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "DateBoundTimeRangeses");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "DateBoundTimeRangeses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeekDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDay", x => x.Id);
                    table.UniqueConstraint("AK_WeekDay_Day", x => x.Day);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateBoundTimeRangeses_DayId",
                table: "DateBoundTimeRangeses",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateBoundTimeRangeses_WeekDay_DayId",
                table: "DateBoundTimeRangeses",
                column: "DayId",
                principalTable: "WeekDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
