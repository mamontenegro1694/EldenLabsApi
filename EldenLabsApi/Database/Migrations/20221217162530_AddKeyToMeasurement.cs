using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EldenLabsApi.Database.Migrations
{
    public partial class AddKeyToMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Measurements",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "eldenlabs@celsia.com",
                column: "Password",
                value: "$2a$11$RxAO41L74srOXnBTMELpE./6soNrNUyJ6zOYadnZWQ0gP95sNPpLi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Measurements");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Email",
                keyValue: "eldenlabs@celsia.com",
                column: "Password",
                value: "$2a$11$dR9yhOlLH8Z0bEPDYnRz4Ou6bBR2rAp0nWNyAfo9u5sCsjUWIkMD.");
        }
    }
}
