using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouriceDatabases.Migrations
{
    public partial class testRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusDrivers_tblUser_AdminUserId",
                table: "BusDrivers");

            migrationBuilder.RenameColumn(
                name: "AdminUserId",
                table: "BusDrivers",
                newName: "tblUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BusDrivers_AdminUserId",
                table: "BusDrivers",
                newName: "IX_BusDrivers_tblUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusDrivers_tblUser_tblUserUserId",
                table: "BusDrivers",
                column: "tblUserUserId",
                principalTable: "tblUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusDrivers_tblUser_tblUserUserId",
                table: "BusDrivers");

            migrationBuilder.RenameColumn(
                name: "tblUserUserId",
                table: "BusDrivers",
                newName: "AdminUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BusDrivers_tblUserUserId",
                table: "BusDrivers",
                newName: "IX_BusDrivers_AdminUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusDrivers_tblUser_AdminUserId",
                table: "BusDrivers",
                column: "AdminUserId",
                principalTable: "tblUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
