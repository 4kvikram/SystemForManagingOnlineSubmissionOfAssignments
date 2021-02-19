using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentSubmission.DAL.Migrations
{
    public partial class initialmigraiton2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentDetails_ProgramsDetails_StudentProgramId",
                table: "studentDetails");

            migrationBuilder.DropIndex(
                name: "IX_studentDetails_StudentProgramId",
                table: "studentDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_studentDetails_StudentProgramId",
                table: "studentDetails",
                column: "StudentProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentDetails_ProgramsDetails_StudentProgramId",
                table: "studentDetails",
                column: "StudentProgramId",
                principalTable: "ProgramsDetails",
                principalColumn: "ProgramId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
