using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KUSYS.Data.Migrations
{
    public partial class CreateAuthorizationTablesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false, maxLength: 255),
                    Name = table.Column<string>(nullable: false, maxLength: 255),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false, maxLength: 255),
                    LastName = table.Column<string>(nullable: false, maxLength: 255),
                    UserName = table.Column<string>(nullable: false, maxLength: 255),
                    Password = table.Column<string>(nullable: false, maxLength: 255),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                }
            );
        }
    }
}
