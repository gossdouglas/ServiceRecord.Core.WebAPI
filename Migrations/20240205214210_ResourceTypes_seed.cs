using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class ResourceTypes_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResourceTypes",
                columns: new[] { "ResourceTypeID", "Description", "Rate", "ResourceDescShort" },
                values: new object[,]
                {
                    { 1, "CONTROL ENGINEER", 250m, "CE" },
                    { 2, "MECHANICAL ENGINEER", 110m, "ME" },
                    { 3, "ELECTRICAL ENGINEER", 115m, "EE" },
                    { 4, "GENERAL TECHNICIAN", 120m, "GT" },
                    { 5, "MECHANICAL TECHNICIAN", 125m, "MT" },
                    { 6, "ELECTRICAL TECHNICIAN", 130m, "ET" },
                    { 7, "STRUCTURAL ENGINEER", 135m, "SE" },
                    { 8, "STRUCTUAL TECHNICIAN", 140m, "ST" },
                    { 9, "FABRICATION TECHNICIAN", 145m, "FT" },
                    { 10, "WELDER", 150m, "WD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ResourceTypes",
                keyColumn: "ResourceTypeID",
                keyValue: 10);
        }
    }
}
