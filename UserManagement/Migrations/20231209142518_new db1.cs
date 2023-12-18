using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OA.API.Migrations
{
    /// <inheritdoc />
    public partial class newdb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel");

            migrationBuilder.RenameTable(
                name: "UserModel",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserModel",
                table: "UserModel",
                column: "ID");
        }
    }
}
