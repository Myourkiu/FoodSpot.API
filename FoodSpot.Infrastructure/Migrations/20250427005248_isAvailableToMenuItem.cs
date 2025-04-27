using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodSpot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class isAvailableToMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "MenuItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "MenuItems");
        }
    }
}
