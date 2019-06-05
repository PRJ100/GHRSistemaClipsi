using Banco_de_Dados.Classes;
using Microsoft.EntityFrameworkCore;

namespace Banco_de_Dados.Dados
{
    public class DbContexto : DbContext
    {
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DEAN\SQLEXPRESS;Database=SISTEMACLIPSI;Trusted_Connection=True;");

        }
    }
}
