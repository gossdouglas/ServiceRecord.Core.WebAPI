using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class JobResourceType_remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobResourceTypes");

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    ResourceTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resourceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.ResourceTypeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceTypes");

            migrationBuilder.CreateTable(
                name: "JobResourceTypes",
                columns: table => new
                {
                    JobID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ResourceTypeID = table.Column<byte>(type: "tinyint", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobResourceTypes", x => new { x.JobID, x.ResourceTypeID });
                    table.ForeignKey(
                        name: "FK_JobResourceTypes_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
