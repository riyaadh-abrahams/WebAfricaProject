using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAfricaProject.Migrations
{
    public partial class updatedforeinkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployee_Project_EmployeeId",
                table: "ProjectEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployee_Employee_ProjectId",
                table: "ProjectEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployee_Employee_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployee_Project_ProjectId",
                table: "ProjectEmployee",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployee_Employee_EmployeeId",
                table: "ProjectEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployee_Project_ProjectId",
                table: "ProjectEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployee_Project_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployee_Employee_ProjectId",
                table: "ProjectEmployee",
                column: "ProjectId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
