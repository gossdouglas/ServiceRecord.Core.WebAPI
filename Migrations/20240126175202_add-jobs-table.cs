using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceRecord.Core.WebAPI.Migrations
{
    public partial class addjobstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CustomerContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NrmlHoursStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrmlHoursEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrmlHoursDaily = table.Column<int>(type: "int", nullable: false),
                    DblTimeHours = table.Column<bool>(type: "bit", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Jobs_Customers_CustomerCode",
                        column: x => x.CustomerCode,
                        principalTable: "Customers",
                        principalColumn: "CustomerCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CustomerCode",
                table: "Jobs",
                column: "CustomerCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");
        }
    }
}
