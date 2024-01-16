using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autod.Data.Migrations
{
    public partial class ModifiedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Modifieted",
                table: "LandingPages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifieted",
                table: "CarServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modifieted",
                table: "LandingPages");

            migrationBuilder.DropColumn(
                name: "Modifieted",
                table: "CarServices");
        }
    }
}
