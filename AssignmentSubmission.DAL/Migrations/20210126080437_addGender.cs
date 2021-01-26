using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentSubmission.DAL.Migrations
{
    public partial class addGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "userDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "userDetails");
        }
    }
}
