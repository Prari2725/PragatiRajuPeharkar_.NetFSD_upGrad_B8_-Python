using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScorecardService.Migrations
{
    /// <inheritdoc />
    public partial class a3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "ScoreCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "ScoreCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "ScoreCards",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "ScoreCards");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "ScoreCards");
        }
    }
}
