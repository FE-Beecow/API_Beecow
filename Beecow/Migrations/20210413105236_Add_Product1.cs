using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beecow.Migrations
{
    public partial class Add_Product1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_id = table.Column<Guid>(nullable: false),
                    User_id = table.Column<string>(nullable: false),
                    Product_title = table.Column<string>(nullable: false),
                    Product_short_description = table.Column<string>(nullable: false),
                    Product_full_description = table.Column<string>(nullable: false),
                    Product_price = table.Column<float>(nullable: true),
                    Product_price_currency = table.Column<string>(nullable: false),
                    Product_price_discount_value = table.Column<float>(nullable: true),
                    Product_price_discount_percentage = table.Column<decimal>(nullable: true),
                    Product_unit = table.Column<string>(nullable: false),
                    Product_category = table.Column<string>(nullable: false),
                    Product_size = table.Column<string>(nullable: false),
                    Product_weight = table.Column<float>(nullable: true),
                    Product_weight_unit = table.Column<string>(nullable: false),
                    Product_inventory_amount = table.Column<float>(nullable: true),
                    Product_inventory_adjustment = table.Column<float>(nullable: true),
                    Product_status = table.Column<bool>(nullable: true),
                    LastSavedTime = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastSavedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesProduct",
                columns: table => new
                {
                    Images_id = table.Column<Guid>(nullable: false),
                    Product_images = table.Column<byte[]>(nullable: true),
                    Product_id = table.Column<Guid>(nullable: true),
                    LastSavedTime = table.Column<DateTime>(nullable: false),
                    CreatedUser = table.Column<string>(nullable: true),
                    LastSavedUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesProduct", x => x.Images_id);
                    table.ForeignKey(
                        name: "FK_Images_Products_Productid",
                        column: x => x.Product_id,
                        principalTable: "Product",
                        principalColumn: "Images_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "ImagesProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesProduct");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
