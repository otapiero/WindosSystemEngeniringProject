using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppServer_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerCount = table.Column<int>(type: "int", nullable: false),
                    ServerRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpuUsage = table.Column<float>(type: "real", nullable: false),
                    MemoryUsage = table.Column<float>(type: "real", nullable: false),
                    MaxMemory = table.Column<float>(type: "real", nullable: false),
                    MaxCpu = table.Column<float>(type: "real", nullable: false),
                    ServerUp = table.Column<bool>(type: "bit", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => new { x.ServerName, x.DateTime });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
