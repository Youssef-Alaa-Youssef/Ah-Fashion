using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddandAlerModelSectionsandContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "SettingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SettingGroupId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 24, 18, 24, 11, 304, DateTimeKind.Utc).AddTicks(8980));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 24, 18, 24, 11, 304, DateTimeKind.Utc).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 24, 18, 24, 11, 304, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Permission" },
                values: new object[] { new DateTime(2024, 6, 24, 21, 24, 11, 328, DateTimeKind.Local).AddTicks(2769), "Admin" });

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Permission" },
                values: new object[] { new DateTime(2024, 6, 24, 21, 24, 11, 328, DateTimeKind.Local).AddTicks(2844), "User" });

            migrationBuilder.UpdateData(
                table: "Websites",
                keyColumn: "Id",
                keyValue: 1,
                column: "Now",
                value: new DateTime(2024, 6, 24, 18, 24, 11, 330, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SettingGroupId",
                table: "Sections",
                column: "SettingGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_SettingGroups_SettingGroupId",
                table: "Sections",
                column: "SettingGroupId",
                principalTable: "SettingGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_SettingGroups_SettingGroupId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_SettingGroupId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "SettingGroups");

            migrationBuilder.DropColumn(
                name: "SettingGroupId",
                table: "Sections");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 22, 17, 56, 51, 140, DateTimeKind.Utc).AddTicks(7752));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 22, 17, 56, 51, 140, DateTimeKind.Utc).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 22, 17, 56, 51, 140, DateTimeKind.Utc).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 22, 20, 56, 51, 164, DateTimeKind.Local).AddTicks(856));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 22, 20, 56, 51, 164, DateTimeKind.Local).AddTicks(936));

            migrationBuilder.UpdateData(
                table: "Websites",
                keyColumn: "Id",
                keyValue: 1,
                column: "Now",
                value: new DateTime(2024, 6, 22, 17, 56, 51, 167, DateTimeKind.Utc).AddTicks(9019));
        }
    }
}
