using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persons.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectType = table.Column<int>(type: "int", nullable: false),
                    RelatedPersonId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Persons_RelatedPersonId",
                        column: x => x.RelatedPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Created", "IsDeleted", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 5, 4, 16, 8, 25, 565, DateTimeKind.Unspecified).AddTicks(2785), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tbilisi" },
                    { 2, new DateTimeOffset(new DateTime(2025, 5, 4, 16, 8, 25, 565, DateTimeKind.Unspecified).AddTicks(3639), new TimeSpan(0, 0, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Batumi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Id",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Id",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonalNumber",
                table: "Persons",
                column: "PersonalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_Id",
                table: "Phones",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PersonId",
                table: "Phones",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersons_Id",
                table: "RelatedPersons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersons_RelatedPersonId",
                table: "RelatedPersons",
                column: "RelatedPersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "RelatedPersons");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
