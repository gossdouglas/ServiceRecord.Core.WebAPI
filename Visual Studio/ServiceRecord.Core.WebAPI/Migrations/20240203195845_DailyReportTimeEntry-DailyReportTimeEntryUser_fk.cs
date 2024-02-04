using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class DailyReportTimeEntryDailyReportTimeEntryUser_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_DailyReportTimeEntryUsers_DailyReportTimeEntrys_TimeEntryID",
                table: "DailyReportTimeEntryUsers",
                column: "TimeEntryID",
                principalTable: "DailyReportTimeEntrys",
                principalColumn: "TimeEntryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyReportTimeEntryUsers_DailyReportTimeEntrys_TimeEntryID",
                table: "DailyReportTimeEntryUsers");
        }
    }
}
