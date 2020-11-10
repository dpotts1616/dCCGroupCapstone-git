using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "1267f639-b029-4192-9787-a515267bce2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "a45db918-2b68-4fe6-964d-609b9f5767f0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "392405ec-56e2-41cf-a944-90d19c8fc0e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "563ecab4-f6cf-4651-9f0c-499913f031f6");
        }
    }
}
