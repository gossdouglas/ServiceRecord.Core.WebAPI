using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class DailyReportForeignKeys_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DailyReportID",
                table: "DailyReportTimeEntryUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportTimeEntryUsers_DailyReportID",
                table: "DailyReportTimeEntryUsers",
                column: "DailyReportID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReportTimeEntrys_DailyReportID",
                table: "DailyReportTimeEntrys",
                column: "DailyReportID");

            migrationBuilder.CreateIndex(
                name: "IX_DailyReport_JobID",
                table: "DailyReport",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReport_Jobs_JobID",
                table: "DailyReport",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReportTimeEntrys_DailyReport_DailyReportID",
                table: "DailyReportTimeEntrys",
                column: "DailyReportID",
                principalTable: "DailyReport",
                principalColumn: "DailyReportID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReportTimeEntryUsers_DailyReport_DailyReportID",
                table: "DailyReportTimeEntryUsers",
                column: "DailyReportID",
                principalTable: "DailyReport",
                principalColumn: "DailyReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyReportUsers_DailyReport_DailyReportID",
                table: "DailyReportUsers",
                column: "DailyReportID",
                principalTable: "DailyReport",
                principalColumn: "DailyReportID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReport_Jobs_JobID",
                table: "DailyReport");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyReportTimeEntrys_DailyReport_DailyReportID",
                table: "DailyReportTimeEntrys");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyReportTimeEntryUsers_DailyReport_DailyReportID",
                table: "DailyReportTimeEntryUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyReportUsers_DailyReport_DailyReportID",
                table: "DailyReportUsers");

            migrationBuilder.DropIndex(
                name: "IX_DailyReportTimeEntryUsers_DailyReportID",
                table: "DailyReportTimeEntryUsers");

            migrationBuilder.DropIndex(
                name: "IX_DailyReportTimeEntrys_DailyReportID",
                table: "DailyReportTimeEntrys");

            migrationBuilder.DropIndex(
                name: "IX_DailyReport_JobID",
                table: "DailyReport");

            migrationBuilder.DropColumn(
                name: "DailyReportID",
                table: "DailyReportTimeEntryUsers");
        }
    }
}
