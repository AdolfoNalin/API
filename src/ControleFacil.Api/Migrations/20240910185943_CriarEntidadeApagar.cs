using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFacil.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeApagar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apagar",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdNL = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "varchar", nullable: false),
                    Obs = table.Column<string>(type: "varchar", nullable: false),
                    ValorOriginal = table.Column<double>(type: "double precision", nullable: false),
                    ValorPago = table.Column<double>(type: "double precision", nullable: false),
                    DataCadastro = table.Column<string>(type: "varchar", nullable: false),
                    DataVencimento = table.Column<string>(type: "varchar", nullable: false),
                    DataInativacao = table.Column<string>(type: "varchar", nullable: false),
                    DataRefencia = table.Column<string>(type: "varchar", nullable: false),
                    DataPagamento = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apagar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Apagar_naturezalancamento_IdNL",
                        column: x => x.IdNL,
                        principalTable: "naturezalancamento",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apagar_usuario_IdUser",
                        column: x => x.IdUser,
                        principalTable: "usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apagar_IdNL",
                table: "Apagar",
                column: "IdNL");

            migrationBuilder.CreateIndex(
                name: "IX_Apagar_IdUser",
                table: "Apagar",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apagar");
        }
    }
}
