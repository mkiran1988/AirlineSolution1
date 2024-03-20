using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Airline.API.Data.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddFlightSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AircraftType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetails",
                columns: table => new
                {
                    CustomerDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetails", x => x.CustomerDetailID);
                    table.ForeignKey(
                        name: "FK_CustomerDetails_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FlightSchedules",
                columns: new[] { "Id", "AircraftType", "Airline", "ArrivalAirport", "ArrivalTime", "DepartureAirport", "DepartureTime", "Duration", "FlightNumber", "Price" },
                values: new object[,]
                {
                    { 1, "Boeing 737", "Example Airlines", "DEL", new DateTime(2024, 3, 20, 4, 57, 45, 819, DateTimeKind.Local).AddTicks(5971), "JAK", new DateTime(2024, 3, 19, 23, 57, 45, 819, DateTimeKind.Local).AddTicks(5960), new TimeSpan(0, 5, 0, 0, 0), "ABC123", 500.00m },
                    { 2, "Airbus A320", "Another Airlines", "KOCHI", new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(5987), "HYD", new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(5987), new TimeSpan(0, 2, 0, 0, 0), "XYZ456", 350.00m },
                    { 3, "Airbus A320", "Another Airlines", "HWD", new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(5992), "LHR", new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(5991), new TimeSpan(0, 2, 0, 0, 0), "XYZ440", 350.00m },
                    { 4, "Airbus A320", "Another Airlines", "AHM", new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(5995), "BANG", new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(5994), new TimeSpan(0, 2, 0, 0, 0), "XYZ300", 350.00m },
                    { 5, "Boeing 737", "Another Airlines", "BBSR", new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(5999), "MUM", new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(5999), new TimeSpan(0, 2, 0, 0, 0), "ABC456", 350.00m },
                    { 6, "Airbus A320", "Another Airlines", "CDG", new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(6003), "HYD", new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(6002), new TimeSpan(0, 2, 0, 0, 0), "AFG250", 350.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDetails_UserId",
                table: "CustomerDetails",
                column: "UserId");
            migrationBuilder.Sql(sql: "CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;",suppressTransaction: true);

            migrationBuilder.Sql(sql: "CREATE FULLTEXT INDEX ON FlightSchedules(FlightNumber,DepartureAirport,ArrivalAirport,Airline,AircraftType) KEY INDEX PK_FlightSchedules;", suppressTransaction: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerDetails");

            migrationBuilder.DropTable(
                name: "FlightSchedules");
        }
    }
}
