using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_de_Dados.Migrations
{
    public partial class InitialAgendamento : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamentos");
        }
    }
}
