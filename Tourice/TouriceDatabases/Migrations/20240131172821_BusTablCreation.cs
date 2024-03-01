using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouriceDatabases.Migrations
{
    public partial class BusTablCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusDrivers",
                columns: table => new
                {
                    BusDriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusDriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DLNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusDrivers", x => x.BusDriverId);
                    table.ForeignKey(
                        name: "FK_BusDrivers_tblUser_AdminUserId",
                        column: x => x.AdminUserId,
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusDrivers_AdminUserId",
                table: "BusDrivers",
                column: "AdminUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusDrivers");
        }
    }
}
