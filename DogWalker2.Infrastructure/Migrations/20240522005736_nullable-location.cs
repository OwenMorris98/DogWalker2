using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogWalker2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nullablelocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Locations_LocationID",
                table: "Walks");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Walks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Locations_LocationID",
                table: "Walks",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Locations_LocationID",
                table: "Walks");

            migrationBuilder.AlterColumn<int>(
                name: "LocationID",
                table: "Walks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Locations_LocationID",
                table: "Walks",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
