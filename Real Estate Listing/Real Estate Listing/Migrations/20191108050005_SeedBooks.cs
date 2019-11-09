using Microsoft.EntityFrameworkCore.Migrations;

namespace Real_Estate_Listing.Migrations
{
    public partial class SeedBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "Id", "Address", "Name", "SoldDate", "SoldTo" },
                values: new object[,]
                {
                    { 1, "222 senator", "Greenfield apartments", null, null },
                    { 2, "222 senator", "Senator apartments", null, null },
                    { 3, "222 senator", "Jefferson apartments", null, null },
                    { 4, "222 senator", "lowell apartments", null, null },
                    { 5, "222 senator", "Forum apartments", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
