using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_de_Dados.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "valor",
                table: "lancamentos",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "valor",
                table: "lancamentos",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
