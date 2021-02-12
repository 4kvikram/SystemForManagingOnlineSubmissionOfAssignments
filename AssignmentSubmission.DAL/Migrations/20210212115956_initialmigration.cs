using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentSubmission.DAL.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assignmentDateSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModify = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignmentDateSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModify = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    OTP = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModify = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coursecode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramDetailsId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModify = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courseDetails_ProgramsDetails_ProgramDetailsId",
                        column: x => x.ProgramDetailsId,
                        principalTable: "ProgramsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyCenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramDetailsId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModify = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentDetails_ProgramsDetails_ProgramDetailsId",
                        column: x => x.ProgramDetailsId,
                        principalTable: "ProgramsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentDetails_userDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StudyCenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subjects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModify = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teacherDetails_userDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assignmentSubmissionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AssignmentsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<int>(type: "int", nullable: false),
                    VivaMarks = table.Column<int>(type: "int", nullable: false),
                    CheckedBy = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfModify = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assignmentSubmissionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_assignmentSubmissionDetails_courseDetails_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assignmentSubmissionDetails_userDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "userDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignmentSubmissionDetails_CourseId",
                table: "assignmentSubmissionDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_assignmentSubmissionDetails_UserId",
                table: "assignmentSubmissionDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_courseDetails_ProgramDetailsId",
                table: "courseDetails",
                column: "ProgramDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_studentDetails_ProgramDetailsId",
                table: "studentDetails",
                column: "ProgramDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_studentDetails_UserId",
                table: "studentDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_teacherDetails_UserId",
                table: "teacherDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assignmentDateSettings");

            migrationBuilder.DropTable(
                name: "assignmentSubmissionDetails");

            migrationBuilder.DropTable(
                name: "studentDetails");

            migrationBuilder.DropTable(
                name: "teacherDetails");

            migrationBuilder.DropTable(
                name: "courseDetails");

            migrationBuilder.DropTable(
                name: "userDetails");

            migrationBuilder.DropTable(
                name: "ProgramsDetails");
        }
    }
}
