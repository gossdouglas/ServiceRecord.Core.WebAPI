using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class JobJobCspdts_fk_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobID",
                table: "JobCorrespondents",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobCorrespondents_JobID",
                table: "JobCorrespondents",
                column: "JobID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCorrespondents_Jobs_JobID",
                table: "JobCorrespondents",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCorrespondents_Jobs_JobID",
                table: "JobCorrespondents");

            migrationBuilder.DropIndex(
                name: "IX_JobCorrespondents_JobID",
                table: "JobCorrespondents");

            migrationBuilder.AlterColumn<string>(
                name: "JobID",
                table: "JobCorrespondents",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);
        }
    }
}
