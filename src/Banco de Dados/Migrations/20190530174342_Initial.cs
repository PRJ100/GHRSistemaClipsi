using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_de_Dados.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agendamentos",
                columns: table => new
                {
                    codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    medico = table.Column<int>(nullable: true),
                    tipo = table.Column<string>(maxLength: 50, nullable: true),
                    data = table.Column<string>(maxLength: 10, nullable: true),
                    horario = table.Column<string>(maxLength: 7, nullable: true),
                    paciente = table.Column<string>(maxLength: 10, nullable: true),
                    convenio = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamentos", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 100, nullable: false),
                    cpf = table.Column<string>(maxLength: 16, nullable: false),
                    rg = table.Column<string>(maxLength: 16, nullable: true),
                    telefone = table.Column<string>(maxLength: 20, nullable: true),
                    sexo = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    nascimento = table.Column<string>(maxLength: 50, nullable: false),
                    bairro = table.Column<string>(maxLength: 100, nullable: true),
                    endereco = table.Column<string>(maxLength: 100, nullable: true),
                    numero = table.Column<string>(maxLength: 50, nullable: true),
                    cidade = table.Column<string>(maxLength: 100, nullable: true),
                    cep = table.Column<string>(maxLength: 50, nullable: true),
                    estado = table.Column<string>(maxLength: 50, nullable: true),
                    ativo = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "lancamentos",
                columns: table => new
                {
                    codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipo = table.Column<string>(nullable: true),
                    data = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    forma_pagamento = table.Column<string>(nullable: true),
                    valor = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamentos", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "medico",
                columns: table => new
                {
                    crm = table.Column<int>(nullable: false),
                    especialidade = table.Column<string>(maxLength: 100, nullable: true),
                    nome = table.Column<string>(maxLength: 100, nullable: true),
                    telefone = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.crm);
                });

            migrationBuilder.CreateTable(
                name: "planos",
                columns: table => new
                {
                    codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(maxLength: 100, nullable: true),
                    razao_social = table.Column<string>(maxLength: 100, nullable: true),
                    cnpj = table.Column<string>(maxLength: 50, nullable: true),
                    registro_ans = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planos", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    usuario = table.Column<string>(maxLength: 50, nullable: true),
                    senha = table.Column<string>(maxLength: 40, nullable: true),
                    nivel_acesso = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamentos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "lancamentos");

            migrationBuilder.DropTable(
                name: "medico");

            migrationBuilder.DropTable(
                name: "planos");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
