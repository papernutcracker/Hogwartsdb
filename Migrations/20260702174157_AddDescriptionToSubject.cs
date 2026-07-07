using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hogwards.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogMessage = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateTrigerred = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AuditLog__3214EC077B5BB6DE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaraudersMapLogs",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WizardName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MovementTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Marauder__7A74F8E0251A6D6E", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Teacher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects__3214EC070009E3CD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wizards",
                columns: table => new
                {
                    WizardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    House = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BloodStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, defaultValue: "Unknown")
                        .Annotation("Relational:DefaultConstraintName", "DF_Wizard_BloodStatus")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Wizards__EB46AA85423A4160", x => x.WizardId);
                });

            migrationBuilder.CreateTable(
                name: "HousePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WizardId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    DateRecorded = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HousePoi__3214EC07085F3163", x => x.Id);
                    table.ForeignKey(
                        name: "FK__HousePoin__Subje__0B91BA14",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__HousePoin__Wizar__0A9D95DB",
                        column: x => x.WizardId,
                        principalTable: "Wizards",
                        principalColumn: "WizardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WANDS",
                columns: table => new
                {
                    WandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoreMaterial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Length = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    WizardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WANDS__BB49E3C8E14BFDCE", x => x.WandId);
                    table.ForeignKey(
                        name: "FK_Wands_Wizards",
                        column: x => x.WizardId,
                        principalTable: "Wizards",
                        principalColumn: "WizardId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HousePoints_SubjectId",
                table: "HousePoints",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HousePoints_WizardId",
                table: "HousePoints",
                column: "WizardId");

            migrationBuilder.CreateIndex(
                name: "IX_MaraudersMapLogs_MovementTime",
                table: "MaraudersMapLogs",
                column: "MovementTime");

            migrationBuilder.CreateIndex(
                name: "UQ_Wands_WizardId",
                table: "WANDS",
                column: "WizardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wizards_Name",
                table: "Wizards",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "HousePoints");

            migrationBuilder.DropTable(
                name: "MaraudersMapLogs");

            migrationBuilder.DropTable(
                name: "WANDS");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Wizards");
        }
    }
}
