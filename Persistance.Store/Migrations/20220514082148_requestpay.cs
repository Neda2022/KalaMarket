using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Persistance.Migrations
{
    public partial class requestpay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
