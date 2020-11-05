using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Data.Migrations
{
    public partial class madeSpotIDonContractornullable : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "SpotID",
                table: "Contractors",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99bdf0cb-b893-434a-883d-f612c7085838", "d28d6c5f-e9b3-4045-bd36-5205e0ed9da5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e46ae2b0-c671-4bb6-9d5a-344ff24b040c", "08606ded-6dd9-4272-84a1-075c0149f318", "Contractor", "CONTRACTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99bdf0cb-b893-434a-883d-f612c7085838");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e46ae2b0-c671-4bb6-9d5a-344ff24b040c");

            migrationBuilder.AlterColumn<int>(
                name: "SpotID",
                table: "Contractors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
