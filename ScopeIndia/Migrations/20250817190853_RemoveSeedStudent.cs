using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScopeIndia.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentLogins",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentLogins",
                columns: new[] { "Id", "Email", "IsTempPassword", "Password", "TempPassword" },
                values: new object[] { 1, "rajeeammu2001@gmail.com", true, null, "Temp1234" });
        }
    }
}
