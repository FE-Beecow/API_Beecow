using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beecow.Migrations
{
    public partial class updateuser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_CustomerFullname",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerFullname",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerFullname",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId1",
                table: "Order",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId1",
                table: "Order",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_CustomerId1",
                table: "Order",
                column: "CustomerId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_CustomerId1",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerFullname",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Fullname");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerFullname",
                table: "Order",
                column: "CustomerFullname");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_CustomerFullname",
                table: "Order",
                column: "CustomerFullname",
                principalTable: "User",
                principalColumn: "Fullname",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
