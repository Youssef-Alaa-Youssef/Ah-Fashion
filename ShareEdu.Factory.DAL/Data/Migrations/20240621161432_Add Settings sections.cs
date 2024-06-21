using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSettingssections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Visable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 15, 23, 5, 31, DateTimeKind.Utc).AddTicks(4137));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 15, 23, 5, 31, DateTimeKind.Utc).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 21, 15, 23, 5, 31, DateTimeKind.Utc).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 21, 18, 23, 5, 37, DateTimeKind.Local).AddTicks(37));

            migrationBuilder.UpdateData(
                table: "SettingGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 21, 18, 23, 5, 37, DateTimeKind.Local).AddTicks(104));
        }
    }
}
