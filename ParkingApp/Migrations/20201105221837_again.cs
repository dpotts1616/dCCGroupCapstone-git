using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Migrations
{
    public partial class again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "3c164f60-f504-4af3-98b8-80a35860ec0c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "5e416499-839c-4bd7-8416-d7a4a88a9302");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "ebd16298-bd3b-4955-b62d-2598d17b2606");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "9611ecd2-9a2a-4e7c-8257-627ee389a49f");
        }
    }
}
