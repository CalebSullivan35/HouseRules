using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRules.Migrations
{
    public partial class tweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedOn",
                table: "ChoreCompletion",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                column: "ConcurrencyStamp",
                value: "698ec99e-e414-4fc7-a1f1-c897eb1d4619");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36c71eaf-2073-4a70-ad29-12d16acdb9e8", "AQAAAAEAACcQAAAAEBoG4VlxyUCke3uw6VeNMYB4OVoZRLIcQdKOuOE1J0pVsaCqpBgeaIvpFw83gXwqsQ==", "5ab21bc3-44b5-46b4-9e28-698b30d9091f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedOn",
                table: "ChoreCompletion");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                column: "ConcurrencyStamp",
                value: "0cf7ed5c-de75-4cb6-9c93-1fa3bc1b6f79");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "93d4b8e0-3a67-498d-b807-e449fb25eaee", "AQAAAAEAACcQAAAAEO5cAHm71Yssrfh9XD53Wai1Xm/jwJ1xWHCrrt0k5zkym5nAuwnrTGICsxNFlfllBA==", "89d99732-aa2a-442e-859e-e61d284d94e3" });
        }
    }
}
