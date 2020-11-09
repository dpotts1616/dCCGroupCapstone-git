using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Migrations
{
    public partial class backtodateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "a7d87012-dab4-4516-8d2c-431b287b9420");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "e18e6e85-27b9-4ac9-a53a-a9473b2c4923");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Reservations",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Reservations",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "a7429f16-c507-4df2-9e92-6c0c71c96081");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "78a05678-6914-433b-bef8-d2c62f143b50");
        }
    }
}
