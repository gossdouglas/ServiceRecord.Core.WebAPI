using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class JobSubJobResourceType_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_JobResourceTypes_Jobs_JobID",
                table: "JobResourceTypes",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSubJobs_Jobs_JobID",
                table: "JobSubJobs",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobResourceTypes_Jobs_JobID",
                table: "JobResourceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSubJobs_Jobs_JobID",
                table: "JobSubJobs");
        }
    }
}
