using Microsoft.EntityFrameworkCore.Migrations;

namespace Desks.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "locations");

            migrationBuilder.AddColumn<string>(
                name: "location_name",
                table: "locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location_name",
                table: "locations");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "locations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
