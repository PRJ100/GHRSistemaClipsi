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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clipsi._1._0._0.Frames
{
    /// <summary>
    /// Interação lógica para Medicamento.xam
    /// </summary>
    public partial class Medicamento : Page
    {
        private string operacao;
        public Medicamento()
        {
            InitializeComponent();
        }

        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            this.operacao = "cadastrar";
            AlteraBotoes(2);
        }

        private void ButtonAlterar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "alterar";
            AlteraCampos(2);
            AlteraBotoes(2);
        }

        private void ButtonExcluir_Click(object sender, RoutedEventArgs e)
        {
            operacao = "excluir";
            AlteraCampos(2);
            AlteraBotoes(2);
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "";
            AlteraCampos(1);
            AlteraBotoes(1);
            LimparCampos();
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridConsulta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void AlteraCampos(int op)
        {
            textBoxNomeMedicamento.IsEnabled = false;
            textBoxNumeroRegistroMinisterio.IsEnabled = false;
            textBoxDescricao.IsEnabled = false;
            
            if (op == 1)
            {
                textBoxNomeMedicamento.IsEnabled = true;
                textBoxNumeroRegistroMinisterio.IsEnabled = true;
                textBoxDescricao.IsEnabled = true;
                
            }
        }
        private void AlteraBotoes(int op)
        {
            buttonCadastrar.IsEnabled = false;
            buttonAlterar.IsEnabled = false;
            buttonExcluir.IsEnabled = false;
            buttonSalvar.IsEnabled = false;
            buttonCancelar.IsEnabled = false;

            if (op == 1)
            {
                buttonCadastrar.IsEnabled = true;
                AlteraCampos(0);
            }
            if (op == 2)
            {
                buttonSalvar.IsEnabled = true;
                buttonCancelar.IsEnabled = true;
                AlteraCampos(1);
            }
            if (op == 3)
            {
                buttonAlterar.IsEnabled = true;
                buttonExcluir.IsEnabled = true;
                buttonCancelar.IsEnabled = true;
                AlteraCampos(1);
            }
        }
        private void LimparCampos()
        {
            textBoxCodigo.Text = "";
            textBoxNomeMedicamento.Text = "";
            textBoxNumeroRegistroMinisterio.Text = "";
            textBoxDescricao.Text = "";
        }
    }
}
