using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class JobJobCorrespondent_drop_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCorrespondents_Jobs_JobID",
                table: "JobCorrespondents");

            migrationBuilder.DropIndex(
                name: "IX_JobCorrespondents_JobID",
                table: "JobCorrespondents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobCorrespondents_JobID",
                table: "JobCorrespondents",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCorrespondents_Jobs_JobID",
                table: "JobCorrespondents",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID");
        }
    }
}
