using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persons.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_CityId",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_CityId",
                table: "Persons");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId",
                unique: true);
        }
    }
}
