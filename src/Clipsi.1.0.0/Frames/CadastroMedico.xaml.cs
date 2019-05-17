using Banco_de_Dados.Classes;
using Banco_de_Dados.Dados;
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

namespace Teste.Frams
{
    /// <summary>
    /// Interação lógica para CadastroMedico.xam
    /// </summary>
    public partial class CadastroMedico : Page
    {
        private string operacao;
        public CadastroMedico()
        {
            InitializeComponent();
        }

        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            this.operacao = "cadastrar";
            AlteraBotoes(2);
            textBoxCrm.IsEnabled = true;
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
            Medico m = new Medico();
            m.crm = Convert.ToInt32(textBoxCrm.Text);
            m.especialidade = textBoxEspecialidade.Text;
            m.nome = textBoxNome.Text;
            m.telefone = textBoxTelefone.Text;

            if (operacao == "cadastrar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    ctx.Medicos.Add(m);
                    ctx.SaveChanges();
                }
            }
            if (operacao == "alterar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    m = ctx.Medicos.Find(Convert.ToInt32(textBoxCrm.Text));
                    if (m != null)
                    {
                        m.crm = Convert.ToInt32(textBoxCrm.Text);
                        m.especialidade = textBoxEspecialidade.Text;
                        m.nome = textBoxNome.Text;
                        m.telefone = textBoxTelefone.Text;
                        ctx.SaveChanges();
                    }

                }

            }
            if (operacao == "excluir")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    m = ctx.Medicos.Find(Convert.ToInt32(textBoxCrm.Text));
                    ctx.Medicos.Remove(m);
                    ctx.SaveChanges();

                }
            }
            AlteraBotoes(1);
            LimparCampos();
            ListarMedicos();
            
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "";
            AlteraCampos(1);
            AlteraBotoes(1);
            LimparCampos();
        }
        private void LimparCampos()
        {
            textBoxCrm.Text = "";
            textBoxEspecialidade.Text = "";
            textBoxNome.Text = "";
            textBoxTelefone.Text = "";
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

        private void AlteraCampos(int op)
        {
            textBoxCrm.IsEnabled = false;
            textBoxEspecialidade.IsEnabled = false;
            textBoxNome.IsEnabled = false;
            textBoxTelefone.IsEnabled = false;
           
            if (op == 1)
            {
                textBoxEspecialidade.IsEnabled = true;
                textBoxNome.IsEnabled = true;
                textBoxTelefone.IsEnabled = true;
            }
        }
        private void ListarMedicos()
        {
            using (DbContexto ctx = new DbContexto())
            {
                int a = ctx.Medicos.Count();
                conta.Content = a;
                var consulta = ctx.Medicos;
                dataGridConsulta.ItemsSource = consulta.ToList();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AlteraBotoes(1);
            ListarMedicos();
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DbContexto ctx = new DbContexto())
                {
                    var consulta = from c in ctx.Medicos where c.nome.Contains(textBoxBuscar.Text) select c;
                    dataGridConsulta.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }

        private void DataGridConsulta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridConsulta.SelectedIndex >= 0)
            {
                Medico m = (Medico)dataGridConsulta.Items[dataGridConsulta.SelectedIndex];
                textBoxCrm.Text = m.crm.ToString();
                textBoxEspecialidade.Text = m.especialidade;
                textBoxNome.Text = m.nome;
                textBoxTelefone.Text = m.telefone;
                AlteraBotoes(3);
                AlteraCampos(1);
                textBoxCrm.IsEnabled = false;
            }
        }
    }
}
