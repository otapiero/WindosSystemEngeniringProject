using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppServer_Project.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxCpu",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "MaxMemory",
                table: "Servers");

            migrationBuilder.AddColumn<int>(
                name: "MaxScore",
                table: "Servers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerTimeMin",
                table: "Servers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxScore",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "PlayerTimeMin",
                table: "Servers");

            migrationBuilder.AddColumn<float>(
                name: "MaxCpu",
                table: "Servers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MaxMemory",
                table: "Servers",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
