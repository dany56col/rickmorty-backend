using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RickMorty.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEpisodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Episodes",
                table: "Characters",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Episodes",
                table: "Characters");
        }
    }
}
