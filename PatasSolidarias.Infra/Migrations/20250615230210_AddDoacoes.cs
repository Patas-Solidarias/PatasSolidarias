using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatasSolidaras.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddDoacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doação",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    MetodoPagamento = table.Column<string>(type: "TEXT", nullable: false),
                    IdDoador = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCampanha = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doação", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doação_Usuario_IdDoador",
                        column: x => x.IdDoador,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doação_IdDoador",
                table: "Doação",
                column: "IdDoador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doação");
        }
    }
}
