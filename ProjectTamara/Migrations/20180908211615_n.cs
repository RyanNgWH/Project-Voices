using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTamara.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Beneficiary_CreatedByBeneficiaryId",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "CreatedByBeneficiaryId",
                table: "Service",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Service_CreatedByBeneficiaryId",
                table: "Service",
                newName: "IX_Service_CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AspNetUsers_CreatedById",
                table: "Service",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_AspNetUsers_CreatedById",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Service",
                newName: "CreatedByBeneficiaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_CreatedById",
                table: "Service",
                newName: "IX_Service_CreatedByBeneficiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Beneficiary_CreatedByBeneficiaryId",
                table: "Service",
                column: "CreatedByBeneficiaryId",
                principalTable: "Beneficiary",
                principalColumn: "BeneficiaryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
