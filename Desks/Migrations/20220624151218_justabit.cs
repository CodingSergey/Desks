using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desks.Migrations
{
    public partial class justabit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "bookedUntil",
                table: "desks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookedUntil",
                table: "desks");
        }
    }
}
