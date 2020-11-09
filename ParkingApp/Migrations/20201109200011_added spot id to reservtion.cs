using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Migrations
{
    public partial class addedspotidtoreservtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParkingSpots_ReservationId",
                table: "ParkingSpots");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "d64071ec-a650-4f69-9573-92b09388dc87");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "d99bf75f-52c0-4416-ad87-3d7bdf8b449f");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ReservationId",
                table: "ParkingSpots",
                column: "ReservationId",
                unique: true,
                filter: "[ReservationId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParkingSpots_ReservationId",
                table: "ParkingSpots");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "e8d302d5-4621-4833-96c1-51aff6b9fe31");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "b8ea1e6b-42a5-4b38-bb77-47bdfbcfbca9");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ReservationId",
                table: "ParkingSpots",
                column: "ReservationId");
        }
    }
}
