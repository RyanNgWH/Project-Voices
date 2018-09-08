using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTamara.Migrations
{
    public partial class newAttr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByBeneficiaryId",
                table: "Service",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_CreatedByBeneficiaryId",
                table: "Service",
                column: "CreatedByBeneficiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Beneficiary_CreatedByBeneficiaryId",
                table: "Service",
                column: "CreatedByBeneficiaryId",
                principalTable: "Beneficiary",
                principalColumn: "BeneficiaryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Beneficiary_CreatedByBeneficiaryId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_CreatedByBeneficiaryId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CreatedByBeneficiaryId",
                table: "Service");
        }
    }
}
