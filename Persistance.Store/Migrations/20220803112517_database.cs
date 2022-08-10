using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Persistance.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 8, 3, 15, 55, 16, 164, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 8, 3, 15, 55, 16, 175, DateTimeKind.Local).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 8, 3, 15, 55, 16, 175, DateTimeKind.Local).AddTicks(4722));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 5, 14, 12, 51, 46, 943, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 5, 14, 12, 51, 46, 950, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 5, 14, 12, 51, 46, 950, DateTimeKind.Local).AddTicks(5457));
        }
    }
}
