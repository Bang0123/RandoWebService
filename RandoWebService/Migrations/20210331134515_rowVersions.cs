using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandoWebService.Migrations
{
    public partial class rowVersions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EliteRefs",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EliteDatas",
                type: "BLOB",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EliteRefs");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EliteDatas");
        }
    }
}
