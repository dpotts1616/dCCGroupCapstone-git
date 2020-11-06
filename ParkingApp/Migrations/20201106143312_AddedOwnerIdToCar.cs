using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Migrations
{
    public partial class AddedOwnerIdToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_Reservations_ReservationId",
                table: "ParkingSpots");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ParkingSpots",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "ParkingSpots",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentID",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Cars",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "1112ef49-c522-4f18-b5ae-3e1c38b649d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "02cbfe5c-7cb3-41c6-af1b-cdaf45404a4b");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_Reservations_ReservationId",
                table: "ParkingSpots",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_Reservations_ReservationId",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ParkingSpots",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentID",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd87b74-3b02-4126-98e3-b9acb0767fc6",
                column: "ConcurrencyStamp",
                value: "f1f0a967-b0df-4748-bf4e-244866353c0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77e60802-3e18-40cf-8999-79aa642defb1",
                column: "ConcurrencyStamp",
                value: "87f5077d-ffb9-46cc-acf7-310fe4c5e521");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_Reservations_ReservationId",
                table: "ParkingSpots",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
