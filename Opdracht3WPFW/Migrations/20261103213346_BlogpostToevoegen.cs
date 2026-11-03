using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opdracht3WPFW.Migrations
{
    /// <inheritdoc />
    public partial class BlogpostToevoegen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Publicatiedatum",
                table: "Blogposts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publicatiedatum",
                table: "Blogposts");
        }
    }
}
