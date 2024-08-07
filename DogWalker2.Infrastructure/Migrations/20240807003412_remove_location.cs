using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogWalker2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_location : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Walks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Walks");
        }
    }
}
