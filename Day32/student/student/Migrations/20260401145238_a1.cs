using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace student.Migrations
{
    /// <inheritdoc />
    public partial class a1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(name: "Student Name", type: "Varchar(80)", nullable: false),
                    Standard = table.Column<string>(type: "Varchar(5)", nullable: false),
                    Medium = table.Column<string>(type: "Varchar(12)", nullable: false),
                    Mobile = table.Column<string>(type: "Varchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
