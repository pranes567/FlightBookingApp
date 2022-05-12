using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airlineservice.Migrations
{
    public partial class FlightBookingTable_Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookFlights",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNR = table.Column<long>(type: "bigint", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    FromPlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToPlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightToDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    No_of_Seats = table.Column<int>(type: "int", nullable: false),
                    TicketCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountCouponID = table.Column<int>(type: "int", nullable: true),
                    FinalPrice = table.Column<int>(type: "int", nullable: false),
                    FlightSeatNo = table.Column<int>(type: "int", nullable: false),
                    Meal = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookFlights", x => x.BookingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookFlights");
        }
    }
}
