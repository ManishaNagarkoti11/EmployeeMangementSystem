using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeMangementSystem.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateStatuses",
                table: "CandidateStatuses");

            migrationBuilder.RenameTable(
                name: "CandidateStatuses",
                newName: "CandidateStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateStatus",
                table: "CandidateStatus",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateStatus",
                table: "CandidateStatus");

            migrationBuilder.RenameTable(
                name: "CandidateStatus",
                newName: "CandidateStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateStatuses",
                table: "CandidateStatuses",
                column: "Id");
        }
    }
}
