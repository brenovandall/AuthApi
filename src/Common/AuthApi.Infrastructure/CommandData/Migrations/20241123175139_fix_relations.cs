using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthApi.Infrastructure.CommandData.Migrations
{
    /// <inheritdoc />
    public partial class fix_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionsId",
                table: "MemberRoles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MemberRoles_PermissionsId",
                table: "MemberRoles",
                column: "PermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberRoles_Permissions_PermissionsId",
                table: "MemberRoles",
                column: "PermissionsId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberRoles_Permissions_PermissionsId",
                table: "MemberRoles");

            migrationBuilder.DropIndex(
                name: "IX_MemberRoles_PermissionsId",
                table: "MemberRoles");

            migrationBuilder.DropColumn(
                name: "PermissionsId",
                table: "MemberRoles");
        }
    }
}
