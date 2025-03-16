using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveToBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Quizzes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999991"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999992"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999993"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999994"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999995"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999996"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999997"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999998"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-9999999999a0"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-9999999999a1"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-9999999999a2"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777778"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777779"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888889"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555556"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555557"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666667"),
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Answers");
        }
    }
}
