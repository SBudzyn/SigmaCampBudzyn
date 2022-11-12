using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6.Migrations
{
    /// <inheritdoc />
    public partial class InitialNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FirstDate",
                table: "ApartmentData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QuarterNumber",
                table: "ApartmentData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecondDate",
                table: "ApartmentData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ThirdDate",
                table: "ApartmentData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstDate",
                table: "ApartmentData");

            migrationBuilder.DropColumn(
                name: "QuarterNumber",
                table: "ApartmentData");

            migrationBuilder.DropColumn(
                name: "SecondDate",
                table: "ApartmentData");

            migrationBuilder.DropColumn(
                name: "ThirdDate",
                table: "ApartmentData");
        }
    }
}
