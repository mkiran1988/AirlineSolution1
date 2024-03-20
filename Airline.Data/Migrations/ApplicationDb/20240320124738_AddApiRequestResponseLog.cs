using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airline.API.Data.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddApiRequestResponseLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SortBy",
                table: "SearchHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SearchTerm",
                table: "SearchHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Criteria",
                table: "SearchHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ApiLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 23, 17, 36, 756, DateTimeKind.Local).AddTicks(8264), new DateTime(2024, 3, 20, 18, 17, 36, 756, DateTimeKind.Local).AddTicks(8253) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 22, 17, 36, 756, DateTimeKind.Local).AddTicks(8278), new DateTime(2024, 3, 20, 20, 17, 36, 756, DateTimeKind.Local).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 22, 17, 36, 756, DateTimeKind.Local).AddTicks(8282), new DateTime(2024, 3, 20, 20, 17, 36, 756, DateTimeKind.Local).AddTicks(8281) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 22, 17, 36, 756, DateTimeKind.Local).AddTicks(8285), new DateTime(2024, 3, 20, 20, 17, 36, 756, DateTimeKind.Local).AddTicks(8284) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 22, 17, 36, 756, DateTimeKind.Local).AddTicks(8288), new DateTime(2024, 3, 20, 20, 17, 36, 756, DateTimeKind.Local).AddTicks(8287) });

            migrationBuilder.UpdateData(
                table: "FlightSchedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 3, 20, 22, 17, 36, 756, DateTimeKind.Local).AddTicks(8291), new DateTime(2024, 3, 20, 20, 17, 36, 756, DateTimeKind.Local).AddTicks(8290) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiLogs");

            migrationBuilder.AlterColumn<string>(
                name: "SortBy",
                table: "SearchHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SearchTerm",
                table: "SearchHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Criteria",
                table: "SearchHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
