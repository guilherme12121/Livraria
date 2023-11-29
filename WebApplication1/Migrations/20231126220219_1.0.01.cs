using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class _1001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "livros",
                columns: table => new
                {
                    LivroId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LivroName = table.Column<string>(type: "text", nullable: false),
                    Anodaedição = table.Column<string>(type: "text", nullable: false),
                    autor = table.Column<string>(type: "text", nullable: false),
                    Editora = table.Column<string>(type: "text", nullable: false),
                    Idioma = table.Column<string>(type: "text", nullable: false),
                    Numerodepagina = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livros", x => x.LivroId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "livros");
        }
    }
}
