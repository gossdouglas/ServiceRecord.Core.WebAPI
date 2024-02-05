using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class SubJobType_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubJobTypes",
                columns: new[] { "SubJobID", "Description" },
                values: new object[,]
                {
                    { 1, "Commissioning" },
                    { 2, "Shutdown" },
                    { 3, "SAT" },
                    { 4, "General Support" },
                    { 5, "Mechanical Install" },
                    { 6, "Electrical Install" },
                    { 7, "Startup/Commissioning" },
                    { 8, "Engineering Discovery" },
                    { 9, "Training Service" },
                    { 10, "Audit/PM Service" },
                    { 11, "Drawing Updates" },
                    { 12, "Welding" },
                    { 13, "Production Support" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubJobTypes",
                keyColumn: "SubJobID",
                keyValue: 13);
        }
    }
}
