using Banco_de_Dados.Classes;
using Banco_de_Dados.Dados;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Teste.Frams
{
    /// <summary>
    /// Interação lógica para Home.xam
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void DataGridConsulta_Loaded(object sender, RoutedEventArgs e)
        {
            using (DbContexto ctx = new DbContexto())
            {
                var consulta = ctx.Agendamentos;
                dataGridConsulta.ItemsSource = consulta.ToList();
            }

        }


        private void Inicia_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridConsulta.SelectedIndex >= 0)
            {
                Agendamento a = (Agendamento)dataGridConsulta.Items[dataGridConsulta.SelectedIndex];
                MessageBox.Show("Codigo: " + a.codigo + "\nMédigo: " + a.medico + "\nTipo: " + a.tipo + "\nData: " + a.data + "\nHorario: " + a.horario + "\nPaciente: " + a.paciente + "\nConvenio: " + a.convenio);
            }
        }

        private void Finalizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonNovoAgendamento_Click(object sender, RoutedEventArgs e)
        {
            //this. = new Agendamento();
        }
    }
}
