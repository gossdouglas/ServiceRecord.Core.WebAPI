using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class SubJobTypesJobSubJob_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSubJobs",
                table: "JobSubJobs");

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

            migrationBuilder.AddColumn<int>(
                name: "SubJobID",
                table: "JobSubJobs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSubJobs",
                table: "JobSubJobs",
                columns: new[] { "JobID", "SubJobID" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubJobTypes_JobSubJobs_JobSubJobJobID_JobSubJobSubJobID",
                table: "SubJobTypes");

            migrationBuilder.DropIndex(
                name: "IX_SubJobTypes_JobSubJobJobID_JobSubJobSubJobID",
                table: "SubJobTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSubJobs",
                table: "JobSubJobs");

            migrationBuilder.DropColumn(
                name: "JobSubJobJobID",
                table: "SubJobTypes");

            migrationBuilder.DropColumn(
                name: "JobSubJobSubJobID",
                table: "SubJobTypes");

            migrationBuilder.DropColumn(
                name: "SubJobID",
                table: "JobSubJobs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSubJobs",
                table: "JobSubJobs",
                column: "JobID");
        }
    }
}
