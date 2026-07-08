using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hogwards.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "EntryYear",
            //    table: "Wizards",
            //    type: "int",
            //    nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryYear",
                table: "Wizards");
        }
    }
}
