using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class JobCustomerCode_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Customers_CustomerCode",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CustomerCode",
                table: "Jobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CustomerCode",
                table: "Jobs",
                column: "CustomerCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Customers_CustomerCode",
                table: "Jobs",
                column: "CustomerCode",
                principalTable: "Customers",
                principalColumn: "CustomerCode");
        }
    }
}
