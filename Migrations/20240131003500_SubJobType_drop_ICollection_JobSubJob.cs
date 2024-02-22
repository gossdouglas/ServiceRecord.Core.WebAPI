using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class SubJobType_drop_ICollection_JobSubJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSubJobs_SubJobTypes_SubJobTypesubJobID",
                table: "JobSubJobs");

            migrationBuilder.DropIndex(
                name: "IX_JobSubJobs_SubJobTypesubJobID",
                table: "JobSubJobs");

            migrationBuilder.DropColumn(
                name: "SubJobTypesubJobID",
                table: "JobSubJobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubJobTypesubJobID",
                table: "JobSubJobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSubJobs_SubJobTypesubJobID",
                table: "JobSubJobs",
                column: "SubJobTypesubJobID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSubJobs_SubJobTypes_SubJobTypesubJobID",
                table: "JobSubJobs",
                column: "SubJobTypesubJobID",
                principalTable: "SubJobTypes",
                principalColumn: "subJobID");
        }
    }
}
