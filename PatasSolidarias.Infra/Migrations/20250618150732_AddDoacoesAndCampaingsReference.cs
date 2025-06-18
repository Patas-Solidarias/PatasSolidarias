using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatasSolidaras.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddDoacoesAndCampaingsReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campanhas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataProgressao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MetaArrecadacao = table.Column<decimal>(type: "TEXT", nullable: false),
                    Progresso = table.Column<decimal>(type: "TEXT", nullable: false),
                    IdOng = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campanhas", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doação_IdCampanha",
                table: "Doação",
                column: "IdCampanha");

            migrationBuilder.AddForeignKey(
                name: "FK_Doação_Campanhas_IdCampanha",
                table: "Doação",
                column: "IdCampanha",
                principalTable: "Campanhas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doação_Campanhas_IdCampanha",
                table: "Doação");

            migrationBuilder.DropTable(
                name: "Campanhas");

            migrationBuilder.DropIndex(
                name: "IX_Doação_IdCampanha",
                table: "Doação");
        }
    }
}
