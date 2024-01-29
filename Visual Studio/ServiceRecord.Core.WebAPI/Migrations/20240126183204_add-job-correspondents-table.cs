using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class addjobcorrespondentstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCorrespondents",
                columns: table => new
                {
                    JobCorrespondentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobID = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCorrespondents", x => x.JobCorrespondentID);
                    table.ForeignKey(
                        name: "FK_JobCorrespondents_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobCorrespondents_JobID",
                table: "JobCorrespondents",
                column: "JobID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCorrespondents");
        }
    }
}
