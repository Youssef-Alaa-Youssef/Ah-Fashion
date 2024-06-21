using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SettingGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LinkNameEn = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LinkNameAr = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Visable = table.Column<bool>(type: "bit", nullable: false),
                    ranking = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    place = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingGroups", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "SettingGroups",
                columns: new[] { "Id", "Action", "Controller", "CreatedAt", "LinkNameAr", "LinkNameEn", "Name", "Visable", "place", "ranking" },
                values: new object[,]
                {
                    { 1, "Index", "Home", new DateTime(2024, 6, 21, 18, 23, 5, 37, DateTimeKind.Local).AddTicks(37), "العامة", "General", "General Settings", true, "1", "1" },
                    { 2, "AboutUs", "Home", new DateTime(2024, 6, 21, 18, 23, 5, 37, DateTimeKind.Local).AddTicks(104), "نبذا عنا", "About Us", "About Settings", true, "2", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingGroups");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 19, 13, 7, 52, 113, DateTimeKind.Utc).AddTicks(9166));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 19, 13, 7, 52, 113, DateTimeKind.Utc).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 19, 13, 7, 52, 113, DateTimeKind.Utc).AddTicks(9184));
        }
    }
}
