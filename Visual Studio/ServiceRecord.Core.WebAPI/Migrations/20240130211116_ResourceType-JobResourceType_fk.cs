using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class ResourceTypeJobResourceType_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobResourceTypes_ResourceTypeID",
                table: "JobResourceTypes",
                column: "ResourceTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobResourceTypes_ResourceTypes_ResourceTypeID",
                table: "JobResourceTypes",
                column: "ResourceTypeID",
                principalTable: "ResourceTypes",
                principalColumn: "ResourceTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobResourceTypes_ResourceTypes_ResourceTypeID",
                table: "JobResourceTypes");

            migrationBuilder.DropIndex(
                name: "IX_JobResourceTypes_ResourceTypeID",
                table: "JobResourceTypes");
        }
    }
}
