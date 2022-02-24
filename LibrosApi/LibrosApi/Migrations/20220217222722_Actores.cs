using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibrosApi.Migrations
{
    public partial class Actores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Categorias",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categorias",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Categorias",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    FechadeNacimiento = table.Column<DateTime>(nullable: false),
                    Foto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Categorias",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categorias",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Categorias",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
