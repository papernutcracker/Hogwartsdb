using Hogwards.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hogwards.Migrations
{
    /// <inheritdoc />
    public partial class _003_AddActiveWizardsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW vw_ActiveWizards
                                    AS
                                    SELECT w.WizardId, w.[Name], w.House, w.BloodStatus
                                    FROM Wizards w
                                    WHERE IsActive = 1;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS vw_ActiveWizards;");
        }
    }
}
