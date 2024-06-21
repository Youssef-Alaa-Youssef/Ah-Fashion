using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductandproductcategoryandsidemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expire = table.Column<DateOnly>(type: "date", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK_Products_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 16, 53, 19, 67, DateTimeKind.Utc).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 16, 53, 19, 67, DateTimeKind.Utc).AddTicks(1827));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 16, 53, 19, 67, DateTimeKind.Utc).AddTicks(1829));

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryID", "Description", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, "Products for Men", "رجالي", "Men" },
                    { 2, "Products for Women", "نسائي", "Women" },
                    { 3, "Products for Kids", "أطفال", "Kids" }
                });

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 21, 19, 53, 19, 85, DateTimeKind.Local).AddTicks(6617));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 21, 19, 53, 19, 85, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeID",
                table: "Products",
                column: "SizeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 16, 14, 30, 716, DateTimeKind.Utc).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 16, 14, 30, 716, DateTimeKind.Utc).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 16, 14, 30, 716, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 21, 19, 14, 30, 723, DateTimeKind.Local).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 21, 19, 14, 30, 723, DateTimeKind.Local).AddTicks(3554));
        }
    }
}
