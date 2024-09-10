using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFacil.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeNaturezaLancamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "naturezalancamento",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "varchar", nullable: false),
                    Obs = table.Column<string>(type: "varchar", nullable: false),
                    DataCadastro = table.Column<string>(type: "varchar", nullable: false),
                    DataInativacao = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_naturezalancamento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_naturezalancamento_usuario_IdUser",
                        column: x => x.IdUser,
                        principalTable: "usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_naturezalancamento_IdUser",
                table: "naturezalancamento",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "naturezalancamento");
        }
    }
}
