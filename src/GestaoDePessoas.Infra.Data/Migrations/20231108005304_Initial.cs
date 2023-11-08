using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoDePessoa.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    data_cadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    nomecompleto = table.Column<string>(type: "varchar(250)", nullable: false),
                    cnpj_cpf = table.Column<string>(type: "varchar(18)", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(12)", nullable: false),
                    cep = table.Column<string>(type: "varchar(9)", nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    bairro = table.Column<string>(type: "varchar(150)", nullable: false),
                    numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
