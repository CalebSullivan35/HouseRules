using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRules.Migrations
{
    public partial class redo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                column: "ConcurrencyStamp",
                value: "3d9af9c9-0e40-4a2c-a3a8-9358b15e23ae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6430cfe8-7b86-452d-bd45-919b0e0fc666", "AQAAAAEAACcQAAAAEEsPo5F/NpQdErurrr4jKK/HUa/6eX9HKKguKV1q64rfEulbRoLTux9ek/heNeOpGA==", "f7fb9271-3345-433a-9a06-d87808c5620a" });

            migrationBuilder.UpdateData(
                table: "ChoreCompletion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChoreId", "CompletedOn" },
                values: new object[] { 4, new DateTime(2023, 9, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ChoreCompletion",
                columns: new[] { "Id", "ChoreId", "CompletedOn", "UserProfileId" },
                values: new object[,]
                {
                    { 2, 3, new DateTime(2023, 9, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 5, new DateTime(2023, 9, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChoreCompletion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChoreCompletion",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.UpdateData(
                table: "ChoreCompletion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ChoreId", "CompletedOn" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
