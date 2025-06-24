using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatasSolidaras.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjustaCampanha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Campanhas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdOng",
                table: "Campanhas",
                newName: "OngUsuarioId");

            migrationBuilder.CreateTable(
                name: "ImagemEmCampanha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Imagem = table.Column<string>(type: "TEXT", nullable: false),
                    CampanhaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemEmCampanha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagemEmCampanha_Campanhas_CampanhaId",
                        column: x => x.CampanhaId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campanhas_OngUsuarioId",
                table: "Campanhas",
                column: "OngUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemEmCampanha_CampanhaId",
                table: "ImagemEmCampanha",
                column: "CampanhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campanhas_Usuario_OngUsuarioId",
                table: "Campanhas",
                column: "OngUsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campanhas_Usuario_OngUsuarioId",
                table: "Campanhas");

            migrationBuilder.DropTable(
                name: "ImagemEmCampanha");

            migrationBuilder.DropIndex(
                name: "IX_Campanhas_OngUsuarioId",
                table: "Campanhas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Campanhas",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "OngUsuarioId",
                table: "Campanhas",
                newName: "IdOng");
        }
    }
}
