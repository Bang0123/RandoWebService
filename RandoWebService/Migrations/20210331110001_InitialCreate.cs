using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandoWebService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EliteRefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    SomeInt = table.Column<int>(type: "INTEGER", nullable: false),
                    SomeDouble = table.Column<double>(type: "REAL", nullable: false),
                    SomeDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EliteRefId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EliteRefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EliteRefs_EliteRefs_EliteRefId",
                        column: x => x.EliteRefId,
                        principalTable: "EliteRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EliteDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    SomeInt = table.Column<int>(type: "INTEGER", nullable: false),
                    SomeDouble = table.Column<double>(type: "REAL", nullable: false),
                    SomeDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SomeRefId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EliteDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EliteDatas_EliteRefs_SomeRefId",
                        column: x => x.SomeRefId,
                        principalTable: "EliteRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EliteDatas_SomeRefId",
                table: "EliteDatas",
                column: "SomeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_EliteRefs_EliteRefId",
                table: "EliteRefs",
                column: "EliteRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EliteDatas");

            migrationBuilder.DropTable(
                name: "EliteRefs");
        }
    }
}
