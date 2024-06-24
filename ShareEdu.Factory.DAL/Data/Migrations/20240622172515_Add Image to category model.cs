using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImagetocategorymodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 22, 17, 25, 9, 697, DateTimeKind.Utc).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 22, 17, 25, 9, 697, DateTimeKind.Utc).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 22, 17, 25, 9, 697, DateTimeKind.Utc).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 22, 20, 25, 9, 733, DateTimeKind.Local).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 22, 20, 25, 9, 733, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "Websites",
                keyColumn: "Id",
                keyValue: 1,
                column: "Now",
                value: new DateTime(2024, 6, 22, 17, 25, 9, 737, DateTimeKind.Utc).AddTicks(4968));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ProductCategories");

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

            migrationBuilder.UpdateData(
                table: "Websites",
                keyColumn: "Id",
                keyValue: 1,
                column: "Now",
                value: new DateTime(2024, 6, 21, 18, 17, 34, 953, DateTimeKind.Utc).AddTicks(8378));
        }
    }
}
