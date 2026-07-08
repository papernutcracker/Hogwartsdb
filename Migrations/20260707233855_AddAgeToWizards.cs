using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hogwards.Migrations
{
    /// <inheritdoc />
    public partial class AddAgeToWizards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Wizards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Wizards");
        }
    }
}
