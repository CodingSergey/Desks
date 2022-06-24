using Microsoft.EntityFrameworkCore.Migrations;

namespace Desks.Migrations
{
    public partial class maybefinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "desk_Reserved",
                table: "accounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desk_Reserved",
                table: "accounts");
        }
    }
}
