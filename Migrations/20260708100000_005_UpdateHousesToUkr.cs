using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hogwards.Migrations
{
    public partial class _005_UpdateHousesToUkr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update common English house names to Ukrainian equivalents
            migrationBuilder.Sql(@"UPDATE Wizards SET House = N'Грифіндор' WHERE House LIKE '%Gryffindor%';");
            migrationBuilder.Sql(@"UPDATE Wizards SET House = N'Слизерин' WHERE House LIKE '%Slytherin%';");
            migrationBuilder.Sql(@"UPDATE Wizards SET House = N'Когтевран' WHERE House LIKE '%Ravenclaw%';");
            migrationBuilder.Sql(@"UPDATE Wizards SET House = N'Гафелпаф' WHERE House LIKE '%Hufflepuff%';");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert Ukrainian names back to English
            migrationBuilder.Sql(@"UPDATE Wizards SET House = 'Gryffindor' WHERE House = N'Грифіндор';");
            migrationBuilder.Sql(@"UPDATE Wizards SET House = 'Slytherin' WHERE House = N'Слизерин';");
            migrationBuilder.Sql(@"UPDATE Wizards SET House = 'Ravenclaw' WHERE House = N'Когтевран';");
            migrationBuilder.Sql(@"UPDATE Wizards SET House = 'Hufflepuff' WHERE House = N'Гафелпаф';");
        }
    }
}
