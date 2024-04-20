using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrosApi.Migrations
{
    public partial class integracionLibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibrosAutores",
                columns: table => new
                {
                    LibroId = table.Column<int>(nullable: false),
                    AutorId = table.Column<int>(nullable: false),
                    Personaje = table.Column<string>(maxLength: 100, nullable: true),
                    Orden = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosAutores", x => new { x.LibroId, x.AutorId });
                    table.ForeignKey(
                        name: "FK_LibrosAutores_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrosAutores_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibrosCategorias",
                columns: table => new
                {
                    LibroId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    CategoriasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosCategorias", x => new { x.LibroId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_LibrosCategorias_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibrosCategorias_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibrosLibrerias",
                columns: table => new
                {
                    LibroId = table.Column<int>(nullable: false),
                    LibreriaId = table.Column<int>(nullable: false),
                    LibreriasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosLibrerias", x => new { x.LibroId, x.LibreriaId });
                    table.ForeignKey(
                        name: "FK_LibrosLibrerias_Librerias_LibreriasId",
                        column: x => x.LibreriasId,
                        principalTable: "Librerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibrosLibrerias_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibrosAutores_AutorId",
                table: "LibrosAutores",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosCategorias_CategoriasId",
                table: "LibrosCategorias",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_LibrosLibrerias_LibreriasId",
                table: "LibrosLibrerias",
                column: "LibreriasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosAutores");

            migrationBuilder.DropTable(
                name: "LibrosCategorias");

            migrationBuilder.DropTable(
                name: "LibrosLibrerias");
        }
    }
}
