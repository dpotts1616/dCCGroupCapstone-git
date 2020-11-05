using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Data.Migrations
{
    public partial class initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1933d53-37ca-43be-a42f-2808ca361e94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b7c37e-d08c-4353-8cf9-d38180302ea7");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ParkingSpots",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ParkingSpots",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "becd7aa4-8f9b-43c7-988d-8c3d4ca4e8f0", "71bd21d1-55c5-447c-a642-227ee670faaa", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09a20f90-5b35-411b-9b36-d71a63834414", "6262969e-f5bc-4be9-94da-7d390fffca27", "Contractor", "CONTRACTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09a20f90-5b35-411b-9b36-d71a63834414");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "becd7aa4-8f9b-43c7-988d-8c3d4ca4e8f0");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ParkingSpots");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4b7c37e-d08c-4353-8cf9-d38180302ea7", "7c31527f-c382-4a7e-86d0-7607cf240ca1", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1933d53-37ca-43be-a42f-2808ca361e94", "3af6c920-b6c8-43bb-a6a9-74bf6a04d1be", "Contractor", "CONTRACTOR" });
        }
    }
}
