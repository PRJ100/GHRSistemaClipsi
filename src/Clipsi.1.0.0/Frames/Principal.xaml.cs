using Clipsi._1._0._0.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Teste.Frams
{
    /// <summary>
    /// Lógica interna para Prinipal.xaml
    /// </summary>
    public partial class Prinipal : Window
    {
        public Prinipal(string Usuario, string nivel)
        {   
            InitializeComponent();
            FramePaginas.Content = new Home();
            this.textBlockUsuario.Text = Usuario;
            if(nivel.Equals("0"))
            {
                MenuCadastros.IsEnabled = false;
                MenuFaturamento.IsEnabled = false;
                MenuConfiguracao.IsEnabled = false;
            }
        }

        private void BtFechaJanela_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuHome_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new Home();
        }

        private void BtMinimizarJanela_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MenuCadastros_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new Cadastro();
        }

        private void MenuCadastroMedico_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new CadastroMedico();
        }

        private void MenuAgendamentoConsultas_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new AgendamentoConsultas();
        }

        private void Menu_ToggleCheckedContentClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuCadastroUsuario_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new CadastroUsuario();
        }

        private void MenuCadastroPlanos_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new CadastroPlano();
        }

        private void MenuRelatorioMensal_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new RelatorioMensal();
        }

        private void MenuLancamentos_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new Lancamentos();
        }

        private void MenuControleDeGastos_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new ControleDeGastos();
        }

        private void MenuCadastroReceituario_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void MenuCadastroAnaminase_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void MenuCadastroAtendimento_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonNovoAgendamento_Click(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new AgendamentoConsultas();
        }

        private void ButtonNovoCadastro_Click(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new Cadastro();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void MenuCadastroMedicamentos_Selected(object sender, RoutedEventArgs e)
        {
            FramePaginas.Content = new Medicamento();
        }
    }
}
