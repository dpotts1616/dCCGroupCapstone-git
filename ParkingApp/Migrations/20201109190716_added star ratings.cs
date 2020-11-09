using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingApp.Migrations
{
    public partial class addedstarratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Customers",
                maxLength: 5,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_Ratings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Ratings_CustomerId",
                table: "Ratings",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Customers");

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
    }
}
