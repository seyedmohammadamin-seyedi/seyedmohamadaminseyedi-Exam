using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSeyyedi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UodateFildCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "City",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "City",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "City",
                newName: "CityName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "City",
                newName: "CityId");
        }
    }
}
