using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDePessoas.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RAZAO = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CNPJ_CPF = table.Column<string>(type: "varchar(14)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FORMAPAGAMENTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TAXA = table.Column<float>(type: "float", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMAPAGAMENTO", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MARCA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCA", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PEDIDOSTATUS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    CANCELADO = table.Column<ulong>(type: "bit", nullable: false),
                    FINALIZADO = table.Column<ulong>(type: "bit", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOSTATUS", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CONTATO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TIPOCONTATO = table.Column<float>(type: "float", nullable: false),
                    VALORCONTATO = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClienteID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTATO_CLIENTE_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "CLIENTE",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    RUA = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CEP = table.Column<string>(type: "varchar(9)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ESTADO = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CIDADE = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BAIRRO = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    clienteID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NUMERO = table.Column<float>(type: "float", nullable: true),
                    CODIGOPOSTAL = table.Column<float>(type: "float", nullable: true),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ENDERECO_CLIENTE_clienteID",
                        column: x => x.clienteID,
                        principalTable: "CLIENTE",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    NOME = table.Column<string>(type: "varchar(250)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarcaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CBARRA = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UNIDADE = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PRECOUNITARIO = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTO_CATEGORIA_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PRODUTO_MARCA_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "MARCA",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PEDIDO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    ClienteID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DESCONTO = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    VALORTOTAL = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    VALORFINAL = table.Column<decimal>(type: "decimal(15,5)", nullable: false),
                    NUMEROPEDIDO = table.Column<int>(type: "int", nullable: false),
                    PedidoStatusID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FormaPagamentoID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false),
                    QUANTIDADEITENS = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEDIDO_CLIENTE_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "CLIENTE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PEDIDO_FORMAPAGAMENTO_FormaPagamentoID",
                        column: x => x.FormaPagamentoID,
                        principalTable: "FORMAPAGAMENTO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PEDIDO_PEDIDOSTATUS_PedidoStatusID",
                        column: x => x.PedidoStatusID,
                        principalTable: "PEDIDOSTATUS",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PEDIDOITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ATIVO = table.Column<ulong>(type: "bit", nullable: false),
                    PedidoID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProdutoID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    DATAHORACADASTRO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEDIDOITEM_PEDIDO_PedidoID",
                        column: x => x.PedidoID,
                        principalTable: "PEDIDO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PEDIDOITEM_PRODUTO_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "PRODUTO",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_ClienteID",
                table: "CONTATO",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_clienteID",
                table: "ENDERECO",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_ClienteID",
                table: "PEDIDO",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_FormaPagamentoID",
                table: "PEDIDO",
                column: "FormaPagamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_PedidoStatusID",
                table: "PEDIDO",
                column: "PedidoStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOITEM_PedidoID",
                table: "PEDIDOITEM",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOITEM_ProdutoID",
                table: "PEDIDOITEM",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_CategoriaID",
                table: "PRODUTO",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_MarcaID",
                table: "PRODUTO",
                column: "MarcaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTATO");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "PEDIDOITEM");

            migrationBuilder.DropTable(
                name: "PEDIDO");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "FORMAPAGAMENTO");

            migrationBuilder.DropTable(
                name: "PEDIDOSTATUS");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "MARCA");
        }
    }
}
