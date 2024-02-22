using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class DailyReportTables_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyReport",
                columns: table => new
                {
                    DailyReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SubJobID = table.Column<int>(type: "int", nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LunchHours = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    DailyReportAuthor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SubmissionStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReport", x => x.DailyReportID);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportTimeEntrys",
                columns: table => new
                {
                    TimeEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyReportID = table.Column<int>(type: "int", nullable: false),
                    WorkDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    WorkDescriptionCategory = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportTimeEntrys", x => x.TimeEntryID);
                });

            migrationBuilder.CreateTable(
                name: "DailyReportTimeEntryUsers",
                columns: table => new
                {
                    TimeEntryID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportTimeEntryUsers", x => new { x.TimeEntryID, x.UserName });
                });

            migrationBuilder.CreateTable(
                name: "DailyReportUsers",
                columns: table => new
                {
                    DailyReportID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyReportUsers", x => new { x.DailyReportID, x.UserName });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyReport");

            migrationBuilder.DropTable(
                name: "DailyReportTimeEntrys");

            migrationBuilder.DropTable(
                name: "DailyReportTimeEntryUsers");

            migrationBuilder.DropTable(
                name: "DailyReportUsers");
        }
    }
}
