using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class JobSubJobSubJobType_reverse_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubJobTypes_JobSubJobs_JobSubJobJobID_JobSubJobSubJobID",
                table: "SubJobTypes");

            migrationBuilder.DropTable(
                name: "JobSubJobs");

            migrationBuilder.DropIndex(
                name: "IX_SubJobTypes_JobSubJobJobID_JobSubJobSubJobID",
                table: "SubJobTypes");

            migrationBuilder.DropColumn(
                name: "JobSubJobJobID",
                table: "SubJobTypes");

            migrationBuilder.DropColumn(
                name: "JobSubJobSubJobID",
                table: "SubJobTypes");

            migrationBuilder.CreateTable(
                name: "JobSubJobTypes",
                columns: table => new
                {
                    JobID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SubJobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSubJobTypes", x => new { x.JobID, x.SubJobID });
                    table.ForeignKey(
                        name: "FK_JobSubJobTypes_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobSubJobTypes_SubJobTypes_SubJobID",
                        column: x => x.SubJobID,
                        principalTable: "SubJobTypes",
                        principalColumn: "SubJobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSubJobTypes_SubJobID",
                table: "JobSubJobTypes",
                column: "SubJobID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobSubJobTypes");

            migrationBuilder.AddColumn<string>(
                name: "JobSubJobJobID",
                table: "SubJobTypes",
                type: "nvarchar(8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobSubJobSubJobID",
                table: "SubJobTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobSubJobs",
                columns: table => new
                {
                    JobID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    SubJobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSubJobs", x => new { x.JobID, x.SubJobID });
                    table.ForeignKey(
                        name: "FK_JobSubJobs_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubJobTypes_JobSubJobJobID_JobSubJobSubJobID",
                table: "SubJobTypes",
                columns: new[] { "JobSubJobJobID", "JobSubJobSubJobID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubJobTypes_JobSubJobs_JobSubJobJobID_JobSubJobSubJobID",
                table: "SubJobTypes",
                columns: new[] { "JobSubJobJobID", "JobSubJobSubJobID" },
                principalTable: "JobSubJobs",
                principalColumns: new[] { "JobID", "SubJobID" });
        }
    }
}
