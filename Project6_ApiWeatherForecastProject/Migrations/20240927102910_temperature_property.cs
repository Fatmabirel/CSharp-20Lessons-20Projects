using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project6_ApiWeatherForecastProject.Migrations
{
    /// <inheritdoc />
    public partial class temperature_property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Temprature",
                table: "Cities",
                newName: "Temperature");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "Cities",
                newName: "Temprature");
        }
    }
}
