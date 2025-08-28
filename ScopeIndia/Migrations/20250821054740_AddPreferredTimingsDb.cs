using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScopeIndia.Migrations
{
    /// <inheritdoc />
    public partial class AddPreferredTimingsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredTimings",
                table: "Students",
                newName: "PreferredTimingsDb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreferredTimingsDb",
                table: "Students",
                newName: "PreferredTimings");
        }
    }
}
