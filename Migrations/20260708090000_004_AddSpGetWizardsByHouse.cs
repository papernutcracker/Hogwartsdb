using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hogwards.Migrations
{
    public partial class _004_AddSpGetWizardsByHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE sp_GetWizardsByHouse
    @House NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT WizardId, [Name], House, EntryYear, BloodStatus, IsActive, Age
    FROM Wizards
    WHERE House = @House;
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS sp_GetWizardsByHouse;");
        }
    }
}
