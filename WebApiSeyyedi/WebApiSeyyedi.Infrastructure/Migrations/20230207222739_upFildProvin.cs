using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSeyyedi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class upFildProvin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProvinceName",
                table: "Province",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "Province",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Province",
                newName: "ProvinceName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Province",
                newName: "ProvinceId");
        }
    }
}
