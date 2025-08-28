using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScopeIndia.Migrations
{
    /// <inheritdoc />
    public partial class SeedAboutUsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AboutUsSections",
                columns: new[] { "Id", "Content", "ImageUrl", "Position", "SectionName", "Title" },
                values: new object[,]
                {
                    { 1, "One of India's best Training destinations...", "images/aboutus/google-rating.png", "center", "Intro", "SCOPE INDIA, your career partner!" },
                    { 2, "With over two decades of experience...", "images/aboutus/team-animation.gif", "right", "Story", "Founded in 2007" },
                    { 3, "SCOPE INDIA was launched in 2015...", "", "left", "Evolution", "Evolution" },
                    { 4, "SCOPE INDIA began its journey...", "", "left", "Growth", "Growth" },
                    { 5, "SCOPE INDIA has helped 15,000+ students...", "", "right", "Present Day Impact", "Present Day Impact" },
                    { 6, "SCOPE INDIA seeks to close the knowledge gap...", "", "left", "Mission", "Our Mission" },
                    { 7, "We aspire to become the most respected...", "", "right", "Vision", "Our Vision" }
                });

            migrationBuilder.InsertData(
                table: "AboutUsStats",
                columns: new[] { "Id", "Label", "Value" },
                values: new object[,]
                {
                    { 1, "Students are Placed", "15000+" },
                    { 2, "Partner Companies", "500+" },
                    { 3, "Placement Assistance", "100%" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutUsSections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AboutUsSections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AboutUsSections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AboutUsSections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AboutUsSections",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AboutUsSections",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AboutUsSections",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AboutUsStats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AboutUsStats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AboutUsStats",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
