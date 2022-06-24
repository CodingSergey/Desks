using Microsoft.EntityFrameworkCore.Migrations;

namespace Desks.Migrations
{
    public partial class acouplemore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "desk_ID",
                table: "accounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desk_ID",
                table: "accounts");
        }
    }
}
