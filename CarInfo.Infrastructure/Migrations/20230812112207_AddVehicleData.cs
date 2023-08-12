using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarInfo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Vehicles");
        }
    }
}
