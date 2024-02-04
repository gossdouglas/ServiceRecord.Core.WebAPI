using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class Jobfield_names_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NrmlHoursStart",
                table: "Jobs",
                newName: "NormalHoursStart");

            migrationBuilder.RenameColumn(
                name: "NrmlHoursEnd",
                table: "Jobs",
                newName: "NormalHoursEnd");

            migrationBuilder.RenameColumn(
                name: "NrmlHoursDaily",
                table: "Jobs",
                newName: "NormalHoursDaily");

            migrationBuilder.RenameColumn(
                name: "DblTimeHours",
                table: "Jobs",
                newName: "DoubleTimeHours");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NormalHoursStart",
                table: "Jobs",
                newName: "NrmlHoursStart");

            migrationBuilder.RenameColumn(
                name: "NormalHoursEnd",
                table: "Jobs",
                newName: "NrmlHoursEnd");

            migrationBuilder.RenameColumn(
                name: "NormalHoursDaily",
                table: "Jobs",
                newName: "NrmlHoursDaily");

            migrationBuilder.RenameColumn(
                name: "DoubleTimeHours",
                table: "Jobs",
                newName: "DblTimeHours");
        }
    }
}
