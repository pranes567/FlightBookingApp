using Microsoft.EntityFrameworkCore.Migrations;

namespace Airlineservice.Migrations
{
    public partial class usernameadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "bookFlights");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "bookFlights",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "bookFlights");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "bookFlights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
