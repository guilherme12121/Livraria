using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class vaidarcertoessapora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_livros",
                table: "livros");

            migrationBuilder.RenameTable(
                name: "livros",
                newName: "Livros");

            migrationBuilder.RenameColumn(
                name: "autor",
                table: "Livros",
                newName: "Autor");

            migrationBuilder.RenameColumn(
                name: "LivroName",
                table: "Livros",
                newName: "LivroNome");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livros",
                table: "Livros",
                column: "LivroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Livros",
                table: "Livros");

            migrationBuilder.RenameTable(
                name: "Livros",
                newName: "livros");

            migrationBuilder.RenameColumn(
                name: "Autor",
                table: "livros",
                newName: "autor");

            migrationBuilder.RenameColumn(
                name: "LivroNome",
                table: "livros",
                newName: "LivroName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_livros",
                table: "livros",
                column: "LivroId");
        }
    }
}
