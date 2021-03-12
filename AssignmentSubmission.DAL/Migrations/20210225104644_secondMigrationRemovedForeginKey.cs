using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentSubmission.DAL.Migrations
{
    public partial class secondMigrationRemovedForeginKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignmentSubmissionDetails_courseDetails_CourseId",
                table: "assignmentSubmissionDetails");

            migrationBuilder.DropIndex(
                name: "IX_assignmentSubmissionDetails_CourseId",
                table: "assignmentSubmissionDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_assignmentSubmissionDetails_CourseId",
                table: "assignmentSubmissionDetails",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentSubmissionDetails_courseDetails_CourseId",
                table: "assignmentSubmissionDetails",
                column: "CourseId",
                principalTable: "courseDetails",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
