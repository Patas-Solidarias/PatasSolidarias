using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatasSolidaras.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CriadoDataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioTipoId = table.Column<int>(type: "INTEGER", maxLength: 15, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_UsuarioTipo_UsuarioTipoId",
                        column: x => x.UsuarioTipoId,
                        principalTable: "UsuarioTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "UsuarioTipo",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 0, "Doador" },
                    { 1, "Ajudante" },
                    { 2, "ONG" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioTipoId",
                table: "Usuario",
                column: "UsuarioTipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "UsuarioTipo");
        }
    }
}
