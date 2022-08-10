using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Persistance.Migrations
{
    public partial class tabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClickCount",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Sliders",
                newName: "link");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "HomePageImages",
                newName: "link");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 23, 16, 5, 22, 137, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 23, 16, 5, 22, 143, DateTimeKind.Local).AddTicks(9759));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 23, 16, 5, 22, 144, DateTimeKind.Local).AddTicks(19));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "link",
                table: "Sliders",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "link",
                table: "HomePageImages",
                newName: "Link");

            migrationBuilder.AddColumn<int>(
                name: "ClickCount",
                table: "Sliders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 21, 15, 22, 6, 986, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 21, 15, 22, 6, 992, DateTimeKind.Local).AddTicks(1230));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 21, 15, 22, 6, 992, DateTimeKind.Local).AddTicks(1489));
        }
    }
}
