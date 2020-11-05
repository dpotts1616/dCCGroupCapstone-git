using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "859abd84-257f-49ff-88cb-8542a82cb97f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7e64a43-a7e0-4b55-8418-cb4c16bbe2e4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6222a04-d8ac-4d10-ba7a-254aff0ab189", "7e01f38c-2847-4221-a798-0bcf509e6a7b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e68d81b-653c-49f3-8a82-ca797d34edd9", "ad4fd6dc-d42a-46fd-a02c-018a83ab6b1a", "Contractor", "CONTRACTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e68d81b-653c-49f3-8a82-ca797d34edd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6222a04-d8ac-4d10-ba7a-254aff0ab189");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "859abd84-257f-49ff-88cb-8542a82cb97f", "89ff6524-c8ba-4da9-b6a4-7b5592ad2fef", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7e64a43-a7e0-4b55-8418-cb4c16bbe2e4", "7852d0c3-c71e-45b1-8a7d-50ab6df81fe9", "Contractor", "CONTRACTOR" });
        }
    }
}
