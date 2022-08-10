using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Persistance.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 20, 16, 29, 28, 725, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 20, 16, 29, 28, 731, DateTimeKind.Local).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 20, 16, 29, 28, 731, DateTimeKind.Local).AddTicks(6899));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 19, 16, 21, 31, 873, DateTimeKind.Local).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 19, 16, 21, 31, 879, DateTimeKind.Local).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2022, 4, 19, 16, 21, 31, 880, DateTimeKind.Local).AddTicks(148));
        }
    }
}
