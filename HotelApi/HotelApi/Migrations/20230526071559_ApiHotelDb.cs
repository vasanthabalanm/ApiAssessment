using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelApi.Migrations
{
    /// <inheritdoc />
    public partial class ApiHotelDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "HotelDetails",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelRoomPrice = table.Column<int>(type: "int", nullable: false),
                    HotelRoomsAvailable = table.Column<int>(type: "int", nullable: false),
                    HotelLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelDetails", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerDetailsCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingDetails_CustomerDetails_CustomerDetailsCustomerId",
                        column: x => x.CustomerDetailsCustomerId,
                        principalTable: "CustomerDetails",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "HotelAdmins",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Staffemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelDetailsHotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelAdmins", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_HotelAdmins_HotelDetails_HotelDetailsHotelId",
                        column: x => x.HotelDetailsHotelId,
                        principalTable: "HotelDetails",
                        principalColumn: "HotelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_CustomerDetailsCustomerId",
                table: "BookingDetails",
                column: "CustomerDetailsCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelAdmins_HotelDetailsHotelId",
                table: "HotelAdmins",
                column: "HotelDetailsHotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "HotelAdmins");

            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "HotelDetails");
        }
    }
}
