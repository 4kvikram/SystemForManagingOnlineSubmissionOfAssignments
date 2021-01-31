using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentSubmission.DAL.Migrations
{
    public partial class updateCourseDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Programmid",
                table: "courseDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "courseDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_ProgramId",
                table: "courseDetails",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_courseDetails_ProgramsDetails_ProgramId",
                table: "courseDetails",
                column: "ProgramId",
                principalTable: "ProgramsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseDetails_ProgramsDetails_ProgramId",
                table: "courseDetails");

            migrationBuilder.DropIndex(
                name: "IX_courseDetails_ProgramId",
                table: "courseDetails");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "courseDetails");

            migrationBuilder.AddColumn<int>(
                name: "Programmid",
                table: "courseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
