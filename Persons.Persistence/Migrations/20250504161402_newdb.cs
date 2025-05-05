using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persons.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 16, 8, 25, 565, DateTimeKind.Unspecified).AddTicks(2785), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2025, 5, 4, 16, 8, 25, 565, DateTimeKind.Unspecified).AddTicks(3639), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
