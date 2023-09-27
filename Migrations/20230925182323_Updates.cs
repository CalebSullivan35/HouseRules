using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRules.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoreAssignment_Chore_ChoreId",
                table: "ChoreAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoreAssignment_UserProfiles_UserProfileId",
                table: "ChoreAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoreCompletion_Chore_ChoreId",
                table: "ChoreCompletion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreAssignment",
                table: "ChoreAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chore",
                table: "Chore");

            migrationBuilder.RenameTable(
                name: "ChoreAssignment",
                newName: "ChoreAssignments");

            migrationBuilder.RenameTable(
                name: "Chore",
                newName: "Chores");

            migrationBuilder.RenameIndex(
                name: "IX_ChoreAssignment_UserProfileId",
                table: "ChoreAssignments",
                newName: "IX_ChoreAssignments_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ChoreAssignment_ChoreId",
                table: "ChoreAssignments",
                newName: "IX_ChoreAssignments_ChoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreAssignments",
                table: "ChoreAssignments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chores",
                table: "Chores",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreAssignments_Chores_ChoreId",
                table: "ChoreAssignments",
                column: "ChoreId",
                principalTable: "Chores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreAssignments_UserProfiles_UserProfileId",
                table: "ChoreAssignments",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreCompletion_Chores_ChoreId",
                table: "ChoreCompletion",
                column: "ChoreId",
                principalTable: "Chores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoreAssignments_Chores_ChoreId",
                table: "ChoreAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoreAssignments_UserProfiles_UserProfileId",
                table: "ChoreAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoreCompletion_Chores_ChoreId",
                table: "ChoreCompletion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chores",
                table: "Chores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoreAssignments",
                table: "ChoreAssignments");

            migrationBuilder.RenameTable(
                name: "Chores",
                newName: "Chore");

            migrationBuilder.RenameTable(
                name: "ChoreAssignments",
                newName: "ChoreAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_ChoreAssignments_UserProfileId",
                table: "ChoreAssignment",
                newName: "IX_ChoreAssignment_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ChoreAssignments_ChoreId",
                table: "ChoreAssignment",
                newName: "IX_ChoreAssignment_ChoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chore",
                table: "Chore",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoreAssignment",
                table: "ChoreAssignment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                column: "ConcurrencyStamp",
                value: "dfbea435-3d9c-4282-8aba-4cb4ef433592");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16bee430-7fa6-4c6f-b29b-038ce441759e", "AQAAAAEAACcQAAAAEMOri89SXPQfiqSzgmL5E96YcMp7Fw6zwjkSugdnWnMbvrTfJ/pncApQhtQ5I/I4lA==", "f4b663e5-3a77-4d40-a9b0-6f461cf52cd5" });

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreAssignment_Chore_ChoreId",
                table: "ChoreAssignment",
                column: "ChoreId",
                principalTable: "Chore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreAssignment_UserProfiles_UserProfileId",
                table: "ChoreAssignment",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreCompletion_Chore_ChoreId",
                table: "ChoreCompletion",
                column: "ChoreId",
                principalTable: "Chore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
