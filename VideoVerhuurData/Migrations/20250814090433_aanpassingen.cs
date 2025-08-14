using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoVerhuurData.Migrations
{
    /// <inheritdoc />
    public partial class aanpassingen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Verhuringen_FilmId",
                table: "Verhuringen",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Verhuringen_KlantId",
                table: "Verhuringen",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreId",
                table: "Films",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Genres_GenreId",
                table: "Films",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verhuringen_Films_FilmId",
                table: "Verhuringen",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Verhuringen_Klanten_KlantId",
                table: "Verhuringen",
                column: "KlantId",
                principalTable: "Klanten",
                principalColumn: "KlantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Genres_GenreId",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Verhuringen_Films_FilmId",
                table: "Verhuringen");

            migrationBuilder.DropForeignKey(
                name: "FK_Verhuringen_Klanten_KlantId",
                table: "Verhuringen");

            migrationBuilder.DropIndex(
                name: "IX_Verhuringen_FilmId",
                table: "Verhuringen");

            migrationBuilder.DropIndex(
                name: "IX_Verhuringen_KlantId",
                table: "Verhuringen");

            migrationBuilder.DropIndex(
                name: "IX_Films_GenreId",
                table: "Films");
        }
    }
}
