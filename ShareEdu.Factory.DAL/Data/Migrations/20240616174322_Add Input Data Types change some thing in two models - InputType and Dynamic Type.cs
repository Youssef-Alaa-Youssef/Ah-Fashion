using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInputDataTypeschangesomethingintwomodelsInputTypeandDynamicType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "InputType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DynamicInputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InputTypeId = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    InputTypeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicInputs_InputType_InputTypeId",
                        column: x => x.InputTypeId,
                        principalTable: "InputType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DynamicInputs_InputType_InputTypeId1",
                        column: x => x.InputTypeId1,
                        principalTable: "InputType",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "InputType",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "InputType",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "InputType",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "InputType",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "InputType",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "InputType",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsVisible",
                value: false);

            migrationBuilder.UpdateData(
                table: "InputType",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsVisible",
                value: false);

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
                name: "IX_DynamicInputs_InputTypeId",
                table: "DynamicInputs",
                column: "InputTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicInputs_InputTypeId1",
                table: "DynamicInputs",
                column: "InputTypeId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicInputs");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "InputType");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 17, 25, 30, 988, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 17, 25, 30, 988, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "AddTime",
                value: new DateTime(2024, 6, 16, 17, 25, 30, 988, DateTimeKind.Utc).AddTicks(4527));
        }
    }
}
