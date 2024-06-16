using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInputDataTypeschangesomethingintwomodelsInputTypeandDynamicTypeanother : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicInputs_InputType_InputTypeId",
                table: "DynamicInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_DynamicInputs_InputType_InputTypeId1",
                table: "DynamicInputs");

            migrationBuilder.DropIndex(
                name: "IX_DynamicInputs_InputTypeId1",
                table: "DynamicInputs");

            migrationBuilder.DropColumn(
                name: "InputTypeId1",
                table: "DynamicInputs");

            migrationBuilder.AlterColumn<int>(
                name: "InputTypeId",
                table: "DynamicInputs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 18, 27, 30, 84, DateTimeKind.Utc).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 18, 27, 30, 84, DateTimeKind.Utc).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 18, 27, 30, 84, DateTimeKind.Utc).AddTicks(8558));

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicInputs_InputType_InputTypeId",
                table: "DynamicInputs",
                column: "InputTypeId",
                principalTable: "InputType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicInputs_InputType_InputTypeId",
                table: "DynamicInputs");

            migrationBuilder.AlterColumn<int>(
                name: "InputTypeId",
                table: "DynamicInputs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InputTypeId1",
                table: "DynamicInputs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 17, 43, 21, 21, DateTimeKind.Utc).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 17, 43, 21, 21, DateTimeKind.Utc).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 17, 43, 21, 21, DateTimeKind.Utc).AddTicks(8185));

            migrationBuilder.CreateIndex(
                name: "IX_DynamicInputs_InputTypeId1",
                table: "DynamicInputs",
                column: "InputTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicInputs_InputType_InputTypeId",
                table: "DynamicInputs",
                column: "InputTypeId",
                principalTable: "InputType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicInputs_InputType_InputTypeId1",
                table: "DynamicInputs",
                column: "InputTypeId1",
                principalTable: "InputType",
                principalColumn: "Id");
        }
    }
}
