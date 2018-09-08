using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTamara.Migrations
{
    public partial class GeneralUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralUser",
                columns: table => new
                {
                    GeneralUserId = table.Column<string>(nullable: false),
                    Occupation = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Income = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralUser", x => x.GeneralUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralUser");
        }
    }
}
