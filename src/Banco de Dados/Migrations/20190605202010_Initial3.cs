using Microsoft.EntityFrameworkCore.Migrations;

namespace Banco_de_Dados.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "valor",
                table: "lancamentos",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "valor",
                table: "lancamentos",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
