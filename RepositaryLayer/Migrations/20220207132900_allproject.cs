using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositaryLayer.Migrations
{
    public partial class allproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Createat",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiedat",
                table: "Notes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Createat",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Modifiedat",
                table: "Notes");
        }
    }
}
