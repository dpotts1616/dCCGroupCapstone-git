using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Data.Migrations
{
    public partial class addedlatitudeandlongitudetoparkingspotclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6b645c1-c725-45f5-98b2-90afdb16f72b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfdd32ce-effc-4286-9867-ccdac3e0250b");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "ParkingSpots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "ParkingSpots",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4b7c37e-d08c-4353-8cf9-d38180302ea7", "7c31527f-c382-4a7e-86d0-7607cf240ca1", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1933d53-37ca-43be-a42f-2808ca361e94", "3af6c920-b6c8-43bb-a6a9-74bf6a04d1be", "Contractor", "CONTRACTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1933d53-37ca-43be-a42f-2808ca361e94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b7c37e-d08c-4353-8cf9-d38180302ea7");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ParkingSpots");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfdd32ce-effc-4286-9867-ccdac3e0250b", "f974673e-5ab6-44ac-b5d6-4356d89de6f6", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6b645c1-c725-45f5-98b2-90afdb16f72b", "0e433bea-9e61-4aa3-a298-4f650f4fed73", "Contractor", "Contractor" });
        }
    }
}
