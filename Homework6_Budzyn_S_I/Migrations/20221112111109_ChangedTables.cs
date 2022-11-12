using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentData",
                table: "ApartmentData");

            migrationBuilder.RenameTable(
                name: "ApartmentData",
                newName: "Apartments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.RenameTable(
                name: "Apartments",
                newName: "ApartmentData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentData",
                table: "ApartmentData",
                column: "Id");
        }
    }
}
