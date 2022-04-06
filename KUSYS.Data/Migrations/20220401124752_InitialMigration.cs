using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYS.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, maxLength: 255),
                    CourseName = table.Column<string>(nullable: false, maxLength: 255),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<string>(nullable: false, maxLength: 255),
                    FirstName = table.Column<string>(nullable: false, maxLength: 255),
                    LastName = table.Column<string>(nullable: false, maxLength: 255),
                    BirthDate = table.Column<DateTime>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                }
            );
        }
    }
}
