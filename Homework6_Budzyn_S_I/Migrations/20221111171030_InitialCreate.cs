using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Number = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstMonthValue1 = table.Column<long>(type: "bigint", nullable: false),
                    FirstMonthValue2 = table.Column<long>(type: "bigint", nullable: false),
                    SecondMonthValue1 = table.Column<long>(type: "bigint", nullable: false),
                    SecondMonthValue2 = table.Column<long>(type: "bigint", nullable: false),
                    ThirdMonthValue1 = table.Column<long>(type: "bigint", nullable: false),
                    ThirdMonthValue2 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Number);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
