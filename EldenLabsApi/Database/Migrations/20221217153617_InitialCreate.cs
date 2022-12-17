using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EldenLabsApi.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    ConnectionDeviceId = table.Column<string>(type: "text", nullable: false),
                    EventProcessedUtcTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HefestoId = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VarName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    Plugin = table.Column<string>(type: "text", nullable: false),
                    Request = table.Column<string>(type: "text", nullable: false),
                    VarName1 = table.Column<string>(type: "text", nullable: false),
                    Device = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Password" },
                values: new object[] { "eldenlabs@celsia.com", "$2a$11$dR9yhOlLH8Z0bEPDYnRz4Ou6bBR2rAp0nWNyAfo9u5sCsjUWIkMD." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
