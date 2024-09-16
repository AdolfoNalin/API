using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFacil.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeAreceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "areceber",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ValorRecebido = table.Column<double>(type: "double precision", nullable: false),
                    DataRecebimento = table.Column<string>(type: "varchar", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdNL = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "varchar", nullable: false),
                    Obs = table.Column<string>(type: "varchar", nullable: false),
                    ValorOriginal = table.Column<double>(type: "double precision", nullable: false),
                    DataCadastro = table.Column<string>(type: "varchar", nullable: false),
                    DataVencimento = table.Column<string>(type: "varchar", nullable: false),
                    DataInativacao = table.Column<string>(type: "varchar", nullable: false),
                    DataRefencia = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areceber", x => x.ID);
                    table.ForeignKey(
                        name: "FK_areceber_naturezalancamento_IdNL",
                        column: x => x.IdNL,
                        principalTable: "naturezalancamento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_areceber_usuario_IdUser",
                        column: x => x.IdUser,
                        principalTable: "usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_areceber_IdNL",
                table: "areceber",
                column: "IdNL");

            migrationBuilder.CreateIndex(
                name: "IX_areceber_IdUser",
                table: "areceber",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "areceber");
        }
    }
}
