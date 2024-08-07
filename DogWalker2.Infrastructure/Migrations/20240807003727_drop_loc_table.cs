using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogWalker2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class drop_loc_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Locations_LocationID",
                table: "Walks");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Walks_LocationID",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "Walks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "Walks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_LocationID",
                table: "Walks",
                column: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Locations_LocationID",
                table: "Walks",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }
    }
}
