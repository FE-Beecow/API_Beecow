using Microsoft.EntityFrameworkCore.Migrations;

namespace Beecow.Migrations
{
    public partial class updateuser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_BusinessId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_BusinessId",
                table: "User",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_BusinessId",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_BusinessId",
                table: "User",
                column: "BusinessId",
                unique: true);
        }
    }
}
