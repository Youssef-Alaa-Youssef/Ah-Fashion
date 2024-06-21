using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWebsiteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Now = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 18, 17, 34, 932, DateTimeKind.Utc).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 18, 17, 34, 932, DateTimeKind.Utc).AddTicks(8743));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 18, 17, 34, 932, DateTimeKind.Utc).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 21, 21, 17, 34, 951, DateTimeKind.Local).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 21, 21, 17, 34, 951, DateTimeKind.Local).AddTicks(2775));

            migrationBuilder.InsertData(
                table: "Websites",
                columns: new[] { "Id", "CompanyName", "Domain", "IsVisible", "Name", "Now" },
                values: new object[] { 1, "Ah Fashion", "http://ah-fashion.runasp.net/", true, "Ah Fashion", new DateTime(2024, 6, 21, 18, 17, 34, 953, DateTimeKind.Utc).AddTicks(8378) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "ProductCategories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Websites");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "CategoryID");
        }
    }
}
