using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareEdu.Factory.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddInputDataTypeschangesomethingintwomodelsInputTypeandDynamicTypeandaddoptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DynamicInputId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_DynamicInputs_DynamicInputId",
                        column: x => x.DynamicInputId,
                        principalTable: "DynamicInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Option_DynamicInputId",
                table: "Option",
                column: "DynamicInputId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicInputs_InputType_InputTypeId",
                table: "DynamicInputs",
                column: "InputTypeId",
                principalTable: "InputType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicInputs_InputType_InputTypeId",
                table: "DynamicInputs");

            migrationBuilder.DropTable(
                name: "Option");

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
    }
}
