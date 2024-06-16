using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInputDataTypeschangesomethingintwomodelsInputTypeandDynamicTypeandaddoptionsdeletesomecolumnsinoptiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobCategoryId",
                table: "DynamicInputs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobId",
                table: "DynamicInputs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 20, 20, 44, 372, DateTimeKind.Utc).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 20, 20, 44, 372, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 20, 20, 44, 372, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.CreateIndex(
                name: "IX_DynamicInputs_JobCategoryId",
                table: "DynamicInputs",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicInputs_JobId",
                table: "DynamicInputs",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicInputs_JobCategories_JobCategoryId",
                table: "DynamicInputs",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicInputs_Jobs_JobId",
                table: "DynamicInputs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicInputs_JobCategories_JobCategoryId",
                table: "DynamicInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_DynamicInputs_Jobs_JobId",
                table: "DynamicInputs");

            migrationBuilder.DropIndex(
                name: "IX_DynamicInputs_JobCategoryId",
                table: "DynamicInputs");

            migrationBuilder.DropIndex(
                name: "IX_DynamicInputs_JobId",
                table: "DynamicInputs");

            migrationBuilder.DropColumn(
                name: "JobCategoryId",
                table: "DynamicInputs");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "DynamicInputs");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 19, 21, 55, 897, DateTimeKind.Utc).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 19, 21, 55, 897, DateTimeKind.Utc).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 19, 21, 55, 897, DateTimeKind.Utc).AddTicks(875));
        }
    }
}
