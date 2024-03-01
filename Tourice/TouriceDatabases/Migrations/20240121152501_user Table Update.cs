using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouriceDatabases.Migrations
{
    public partial class userTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLoginTable",
                table: "UserLoginTable");

            migrationBuilder.RenameTable(
                name: "UserLoginTable",
                newName: "tblUser");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "tblUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "tblUser");

            migrationBuilder.RenameTable(
                name: "tblUser",
                newName: "UserLoginTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLoginTable",
                table: "UserLoginTable",
                column: "UserId");
        }
    }
}
