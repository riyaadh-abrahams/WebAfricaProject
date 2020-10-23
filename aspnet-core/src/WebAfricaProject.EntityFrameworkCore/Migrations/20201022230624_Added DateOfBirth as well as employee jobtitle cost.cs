using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAfricaProject.Migrations
{
    public partial class AddedDateOfBirthaswellasemployeejobtitlecost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExtraProjectCost",
                table: "JobTitles",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtraProjectCost",
                table: "JobTitles");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Employee");
        }
    }
}
