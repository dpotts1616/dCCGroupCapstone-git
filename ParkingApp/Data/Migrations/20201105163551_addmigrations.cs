using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Data.Migrations
{
    public partial class addmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cars_CarID",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99bdf0cb-b893-434a-883d-f612c7085838");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e46ae2b0-c671-4bb6-9d5a-344ff24b040c");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ParkingSpots");

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "859abd84-257f-49ff-88cb-8542a82cb97f", "89ff6524-c8ba-4da9-b6a4-7b5592ad2fef", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7e64a43-a7e0-4b55-8418-cb4c16bbe2e4", "7852d0c3-c71e-45b1-8a7d-50ab6df81fe9", "Contractor", "CONTRACTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cars_CarID",
                table: "Customers",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cars_CarID",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "859abd84-257f-49ff-88cb-8542a82cb97f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7e64a43-a7e0-4b55-8418-cb4c16bbe2e4");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ParkingSpots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ParkingSpots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarID",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99bdf0cb-b893-434a-883d-f612c7085838", "d28d6c5f-e9b3-4045-bd36-5205e0ed9da5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e46ae2b0-c671-4bb6-9d5a-344ff24b040c", "08606ded-6dd9-4272-84a1-075c0149f318", "Contractor", "CONTRACTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cars_CarID",
                table: "Customers",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
