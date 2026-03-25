using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebClinic.Migrations
{
    /// <inheritdoc />
    public partial class AdaugatColoanaRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Pacients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Pacients");
        }
    }
}
