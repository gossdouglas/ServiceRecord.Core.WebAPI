using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class JobSubJob_drop_SubJobID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSubJobs_Jobs_JobID",
                table: "JobSubJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSubJobs",
                table: "JobSubJobs");

            migrationBuilder.DropIndex(
                name: "IX_JobSubJobs_JobID",
                table: "JobSubJobs");

            migrationBuilder.DropColumn(
                name: "SubJobID",
                table: "JobSubJobs");

            migrationBuilder.AlterColumn<string>(
                name: "JobID",
                table: "JobSubJobs",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubJobTypesubJobID",
                table: "JobSubJobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSubJobs",
                table: "JobSubJobs",
                column: "JobID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSubJobs_SubJobTypes_SubJobTypesubJobID",
                table: "JobSubJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSubJobs",
                table: "JobSubJobs");

            migrationBuilder.DropIndex(
                name: "IX_JobSubJobs_SubJobTypesubJobID",
                table: "JobSubJobs");

            migrationBuilder.DropColumn(
                name: "SubJobTypesubJobID",
                table: "JobSubJobs");

            migrationBuilder.AlterColumn<string>(
                name: "JobID",
                table: "JobSubJobs",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<int>(
                name: "SubJobID",
                table: "JobSubJobs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("Relational:ColumnOrder", 1)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSubJobs",
                table: "JobSubJobs",
                column: "SubJobID");

            migrationBuilder.CreateIndex(
                name: "IX_JobSubJobs_JobID",
                table: "JobSubJobs",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobSubJobs_Jobs_JobID",
                table: "JobSubJobs",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID");
        }
    }
}
