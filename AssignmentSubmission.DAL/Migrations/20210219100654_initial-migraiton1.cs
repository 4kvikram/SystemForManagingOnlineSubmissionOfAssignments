using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentSubmission.DAL.Migrations
{
    public partial class initialmigraiton1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseDetails_ProgramsDetails_ProgramDetailsId",
                table: "courseDetails");

            migrationBuilder.DropIndex(
                name: "IX_courseDetails_ProgramDetailsId",
                table: "courseDetails");

            migrationBuilder.RenameColumn(
                name: "ProgramDetailsId",
                table: "courseDetails",
                newName: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "courseDetails",
                newName: "ProgramDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_ProgramDetailsId",
                table: "courseDetails",
                column: "ProgramDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_courseDetails_ProgramsDetails_ProgramDetailsId",
                table: "courseDetails",
                column: "ProgramDetailsId",
                principalTable: "ProgramsDetails",
                principalColumn: "ProgramId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
