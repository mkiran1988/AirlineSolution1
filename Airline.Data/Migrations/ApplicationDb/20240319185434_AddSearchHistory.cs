using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airline.API.Data.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddSearchHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SearchTerm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    PageSize = table.Column<int>(type: "int", nullable: false),
                    SortBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchHistory_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 5, 24, 31, 826, DateTimeKind.Local).AddTicks(1515), new DateTime(2024, 3, 20, 0, 24, 31, 826, DateTimeKind.Local).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1532), new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1536), new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1535) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1539), new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1539) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1543), new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1542) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 4, 24, 31, 826, DateTimeKind.Local).AddTicks(1546), new DateTime(2024, 3, 20, 2, 24, 31, 826, DateTimeKind.Local).AddTicks(1545) });

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistory_UserId",
                table: "SearchHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchHistory");

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 4, 57, 45, 819, DateTimeKind.Local).AddTicks(5971), new DateTime(2024, 3, 19, 23, 57, 45, 819, DateTimeKind.Local).AddTicks(5960) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(5987), new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(5987) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(5992), new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(5991) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(5995), new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(5994) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(5999), new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(5999) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 3, 57, 45, 819, DateTimeKind.Local).AddTicks(6003), new DateTime(2024, 3, 20, 1, 57, 45, 819, DateTimeKind.Local).AddTicks(6002) });
        }
    }
}
