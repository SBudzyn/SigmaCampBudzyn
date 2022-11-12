using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6.Migrations
{
    /// <inheritdoc />
    public partial class IdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentData",
                table: "ApartmentData");

            migrationBuilder.AlterColumn<long>(
                name: "Number",
                table: "ApartmentData",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApartmentData",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentData",
                table: "ApartmentData",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentData",
                table: "ApartmentData");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApartmentData");

            migrationBuilder.AlterColumn<long>(
                name: "Number",
                table: "ApartmentData",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentData",
                table: "ApartmentData",
                column: "Number");
        }
    }
}
