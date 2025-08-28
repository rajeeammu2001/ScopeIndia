using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScopeIndia.Migrations
{
    /// <inheritdoc />
    public partial class SeedContactLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactLocations",
                columns: new[] { "Id", "Address", "Email", "Phone", "RouteLink", "Title" },
                values: new object[,]
                {
                    { 1, "TC 25/1403/3, Athens Plaza, KS Kovil Road, Thampanoor, Trivandrum, Kerala 695001", "info@scopeindia.org", "9745936073", "Location Route Map", "SCOPE INDIA Trivandrum, Kerala" },
                    { 2, "Phase 1, Main Gate, Diamond Arcade, Near Technopark, Trivandrum", "technopark@scopeindia.org", "9745936073", "Location Route Map", "SCOPE INDIA Technopark, Kerala" },
                    { 3, "Vasanth Nagar Rd, near JLN Metro Station, Kaloor, Kochi, Kerala 682025", "kochi@scopeindia.org", "7592939481", "Location Route Map", "SCOPE INDIA Kochi, Kerala" },
                    { 4, "Near WCC College, Palace Road, Nagercoil, Tamil Nadu 629001", "ngl@scopeindia.org", "8075536185", "Location Route Map", "SCOPE INDIA Nagercoil 1, Tamil Nadu" },
                    { 5, "Pharma Street, 5/2 Ward 28, Distillery Road, WCC Jn, Nagercoil", "ngl@scopeindia.org", "8075536185", "Location Route Map", "SCOPE INDIA Nagercoil 2, Tamil Nadu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactLocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactLocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactLocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContactLocations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContactLocations",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
