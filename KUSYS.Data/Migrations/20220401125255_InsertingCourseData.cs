using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYS.Data.Migrations
{
    public partial class InsertingCourseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CourseName" },
                values: new object[,]
                {
                    { "CSI101", "Introduction to Computer Science" },
                    { "CSI102", "Algorithms" },
                    { "MAT101", "Calculus" },
                    { "PHY101", "Physics" }
                });
        }
    }
}
