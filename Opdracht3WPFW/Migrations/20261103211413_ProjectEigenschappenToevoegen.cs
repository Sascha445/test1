using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opdracht3WPFW.Migrations
{
    /// <inheritdoc />
    public partial class ProjectEigenschappenToevoegen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GitHubUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GitHubUrl",
                table: "Projects");
        }
    }
}
