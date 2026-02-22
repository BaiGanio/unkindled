using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planetarium.Docker.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MassEarths = table.Column<double>(type: "float", nullable: false),
                    RadiusKm = table.Column<double>(type: "float", nullable: false),
                    DistanceAU = table.Column<double>(type: "float", nullable: false),
                    HasRings = table.Column<bool>(type: "bit", nullable: false),
                    Atmosphere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscoveredBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscoveryYear = table.Column<int>(type: "int", nullable: true),
                    DGD = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeedState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JsonHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedState", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "SeedState");
        }
    }
}
