using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScopeIndia.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToStudentLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StudentLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "StudentLogins");
        }
    }
}
