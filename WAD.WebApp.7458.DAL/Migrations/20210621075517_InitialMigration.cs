using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WAD.WebApp._7458.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Bike",
                columns: table => new
                {
                    BikeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeName = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    ModelYear = table.Column<int>(maxLength: 4, nullable: false),
                    Price = table.Column<int>(nullable: false),
                    BinaryPhoto = table.Column<byte[]>(nullable: true),
                    ArrivedDate = table.Column<DateTime>(nullable: false),
                    IsReturnable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bike", x => x.BikeId);
                    table.ForeignKey(
                        name: "FK_Bike_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bike_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bike_BrandId",
                table: "Bike",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Bike_CategoryId",
                table: "Bike",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bike");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
