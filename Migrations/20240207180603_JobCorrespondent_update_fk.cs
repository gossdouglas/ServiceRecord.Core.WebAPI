using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class JobCorrespondent_update_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCorrespondents",
                table: "JobCorrespondents");

            migrationBuilder.DropIndex(
                name: "IX_JobCorrespondents_JobID",
                table: "JobCorrespondents");

            migrationBuilder.DropColumn(
                name: "JobCorrespondentID",
                table: "JobCorrespondents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCorrespondents",
                table: "JobCorrespondents",
                columns: new[] { "JobID", "Email" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCorrespondents",
                table: "JobCorrespondents");

            migrationBuilder.AddColumn<int>(
                name: "JobCorrespondentID",
                table: "JobCorrespondents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCorrespondents",
                table: "JobCorrespondents",
                column: "JobCorrespondentID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCorrespondents_JobID",
                table: "JobCorrespondents",
                column: "JobID");
        }
    }
}
