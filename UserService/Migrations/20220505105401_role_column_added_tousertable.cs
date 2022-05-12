using Microsoft.EntityFrameworkCore.Migrations;

namespace UserService.Migrations
{
    public partial class role_column_added_tousertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "userRegistrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "userRegistrations");
        }
    }
}
