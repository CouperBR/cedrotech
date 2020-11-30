using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cep = table.Column<string>(nullable: true),
                    logradouro = table.Column<string>(nullable: true),
                    complemento = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    localidade = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "restaurante",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    enderecoId = table.Column<int>(nullable: false),
                    total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_endereco_enderecoId",
                        column: x => x.enderecoId,
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prato",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    preco = table.Column<decimal>(nullable: false),
                    restauranteId = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(nullable: false),
                    pedidoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prato", x => x.id);
                    table.ForeignKey(
                        name: "FK_prato_pedido_pedidoid",
                        column: x => x.pedidoid,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prato_restaurante_restauranteId",
                        column: x => x.restauranteId,
                        principalTable: "restaurante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prato_pedido",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    id_prato = table.Column<int>(nullable: false),
                    id_pedido = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prato_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_prato_pedido_pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prato_pedido_prato_id_prato",
                        column: x => x.id_prato,
                        principalTable: "prato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedido_enderecoId",
                table: "pedido",
                column: "enderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_prato_pedidoid",
                table: "prato",
                column: "pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_prato_restauranteId",
                table: "prato",
                column: "restauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_prato_pedido_id_pedido",
                table: "prato_pedido",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_prato_pedido_id_prato",
                table: "prato_pedido",
                column: "id_prato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prato_pedido");

            migrationBuilder.DropTable(
                name: "prato");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "restaurante");

            migrationBuilder.DropTable(
                name: "endereco");
        }
    }
}
