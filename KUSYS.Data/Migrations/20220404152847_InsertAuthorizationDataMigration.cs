using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYS.Data.Migrations
{
    public partial class InsertAuthorizationDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "Admin", "Admin" },
                    { "User", "User" },
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "RoleId", "FirstName", "LastName", "UserName", "Password" },
                values: new object[,]
                {
                    { 1, "Kadir", "Coşar", "admin", "123456" },
                    { 2, "Asya", "Coşar", "user", "123456" },
                });
        }
    }
}
