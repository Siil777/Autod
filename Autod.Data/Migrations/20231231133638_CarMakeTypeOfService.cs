using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autod.Data.Migrations
{
    public partial class CarMakeTypeOfService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "LandingPages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CarServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarServices_LandingPages_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "LandingPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_CustomerId",
                table: "CarServices",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarServices");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "LandingPages");
        }
    }
}
