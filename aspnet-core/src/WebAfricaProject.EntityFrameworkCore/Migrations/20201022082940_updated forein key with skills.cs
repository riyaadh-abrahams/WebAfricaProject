using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAfricaProject.Migrations
{
    public partial class updatedforeinkeywithskills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Skill_EmployeeId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Employee_SkillId",
                table: "EmployeeSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Employee_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Skill_SkillId",
                table: "EmployeeSkill",
                column: "SkillId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Employee_EmployeeId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Skill_SkillId",
                table: "EmployeeSkill");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Skill_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId",
                principalTable: "Skill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Employee_SkillId",
                table: "EmployeeSkill",
                column: "SkillId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
