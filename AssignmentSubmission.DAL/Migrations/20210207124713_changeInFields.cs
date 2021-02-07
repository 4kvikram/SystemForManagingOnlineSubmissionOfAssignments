using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentSubmission.DAL.Migrations
{
    public partial class changeInFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignmentSubmissionDetails_courseDetails_CourseId",
                table: "assignmentSubmissionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_assignmentSubmissionDetails_userDetails_UserId",
                table: "assignmentSubmissionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_studentDetails_ProgramsDetails_ProgramId",
                table: "studentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_studentDetails_userDetails_UserId",
                table: "studentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherDetails_userDetails_UserId",
                table: "teacherDetails");

            migrationBuilder.DropIndex(
                name: "IX_studentDetails_ProgramId",
                table: "studentDetails");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "studentDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "teacherDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "studentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgramDetailsId",
                table: "studentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "assignmentSubmissionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "assignmentSubmissionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentDetails_ProgramDetailsId",
                table: "studentDetails",
                column: "ProgramDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentSubmissionDetails_courseDetails_CourseId",
                table: "assignmentSubmissionDetails",
                column: "CourseId",
                principalTable: "courseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentSubmissionDetails_userDetails_UserId",
                table: "assignmentSubmissionDetails",
                column: "UserId",
                principalTable: "userDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentDetails_ProgramsDetails_ProgramDetailsId",
                table: "studentDetails",
                column: "ProgramDetailsId",
                principalTable: "ProgramsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentDetails_userDetails_UserId",
                table: "studentDetails",
                column: "UserId",
                principalTable: "userDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherDetails_userDetails_UserId",
                table: "teacherDetails",
                column: "UserId",
                principalTable: "userDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignmentSubmissionDetails_courseDetails_CourseId",
                table: "assignmentSubmissionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_assignmentSubmissionDetails_userDetails_UserId",
                table: "assignmentSubmissionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_studentDetails_ProgramsDetails_ProgramDetailsId",
                table: "studentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_studentDetails_userDetails_UserId",
                table: "studentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherDetails_userDetails_UserId",
                table: "teacherDetails");

            migrationBuilder.DropIndex(
                name: "IX_studentDetails_ProgramDetailsId",
                table: "studentDetails");

            migrationBuilder.DropColumn(
                name: "ProgramDetailsId",
                table: "studentDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "teacherDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "studentDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "studentDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "assignmentSubmissionDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "assignmentSubmissionDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_studentDetails_ProgramId",
                table: "studentDetails",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentSubmissionDetails_courseDetails_CourseId",
                table: "assignmentSubmissionDetails",
                column: "CourseId",
                principalTable: "courseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assignmentSubmissionDetails_userDetails_UserId",
                table: "assignmentSubmissionDetails",
                column: "UserId",
                principalTable: "userDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studentDetails_ProgramsDetails_ProgramId",
                table: "studentDetails",
                column: "ProgramId",
                principalTable: "ProgramsDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studentDetails_userDetails_UserId",
                table: "studentDetails",
                column: "UserId",
                principalTable: "userDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherDetails_userDetails_UserId",
                table: "teacherDetails",
                column: "UserId",
                principalTable: "userDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
