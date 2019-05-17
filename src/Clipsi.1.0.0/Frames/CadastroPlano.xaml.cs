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
    /// Interação lógica para CadastroPlano.xam
    /// </summary>
    public partial class CadastroPlano : Page
    {
        private string operacao;
        public CadastroPlano()
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
            Plano p = new Plano();
            p.nome = textBoxNomePlano.Text;
            p.razao_social = textBoxRazaoSocial.Text;
            p.cnpj = textBoxCNPJ.Text;
            p.registro_ans = textBoxANS.Text;

            if (operacao == "cadastrar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    ctx.Planos.Add(p);
                    ctx.SaveChanges();
                }
            }
            if (operacao == "alterar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    p = ctx.Planos.Find(Convert.ToInt32(textBoxCodigo.Text));
                    if (p != null)
                    {
                        p.nome = textBoxNomePlano.Text;
                        p.razao_social = textBoxRazaoSocial.Text;
                        p.cnpj = textBoxCNPJ.Text;
                        p.registro_ans = textBoxANS.Text;
                        ctx.SaveChanges();
                    }

                }

            }
            if (operacao == "excluir")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    p = ctx.Planos.Find(Convert.ToInt32(textBoxCodigo.Text));
                    ctx.Planos.Remove(p);
                    ctx.SaveChanges();

                }
            }
            AlteraBotoes(1);
            LimparCampos();
            ListarPlanos();
        }

       

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DbContexto ctx = new DbContexto())
                {
                    var consulta = from c in ctx.Planos where c.nome.Contains(textBoxBuscar.Text) select c;
                    dataGridConsulta.ItemsSource = consulta.ToList();
                }
            }
            catch { }

        }

        private void DataGridConsulta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridConsulta.SelectedIndex >= 0)
            {
                Plano p = (Plano)dataGridConsulta.Items[dataGridConsulta.SelectedIndex];
                textBoxCodigo.Text = p.codigo.ToString();
                textBoxNomePlano.Text = p.nome;
                textBoxRazaoSocial.Text = p.razao_social;
                textBoxCNPJ.Text = p.cnpj;
                textBoxANS.Text = p.registro_ans;
                AlteraBotoes(3);
                AlteraCampos(1);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AlteraBotoes(1);
            ListarPlanos();
            
        }
        private void LimparCampos()
        {
            textBoxCodigo.Text = "";
            textBoxNomePlano.Text = "";
            textBoxRazaoSocial.Text = "";
            textBoxCNPJ.Text = "";
            textBoxANS.Text = "";
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
            textBoxNomePlano.IsEnabled = false;
            textBoxRazaoSocial.IsEnabled = false;
            textBoxCNPJ.IsEnabled = false;
            textBoxANS.IsEnabled = false;

            if (op == 1)
            {
                textBoxNomePlano.IsEnabled = true;
                textBoxRazaoSocial.IsEnabled = true;
                textBoxCNPJ.IsEnabled = true;
                textBoxANS.IsEnabled = true;
            }
        }
        private void ListarPlanos()
        {
            using (DbContexto ctx = new DbContexto())
            {
                int a = ctx.Planos.Count();
                conta.Content = a;
                var consulta = ctx.Planos;
                dataGridConsulta.ItemsSource = consulta.ToList();
            }
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "";
            AlteraCampos(1);
            AlteraBotoes(1);
            LimparCampos();
        }


    }
}
