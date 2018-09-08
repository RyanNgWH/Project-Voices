using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTamara.Migrations
{
    public partial class soemupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "GeneralUser",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "GeneralUser");
        }
    }
}
