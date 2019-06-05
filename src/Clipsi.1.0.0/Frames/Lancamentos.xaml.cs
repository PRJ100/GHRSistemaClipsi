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
    /// Interação lógica para Lancamentos.xam
    /// </summary>
    public partial class Lancamentos : Page
    {
        private string operacao;
        public Lancamentos()
        {
            InitializeComponent();
        }

        private void ButtonNovo_Click(object sender, RoutedEventArgs e)
        {
            this.operacao = "cadastrar";
            AlteraBotoes(2);
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            Lancamento l = new Lancamento();
            l.tipo = comboBoxTipo.Text;
            l.data = comboBoxData.Text;
            l.descricao = TextBoxDescricao.Text;
            l.forma_pagamento = comboBoxFormaPagamento.Text;
            l.valor = Convert.ToDecimal(TextBoxValor.Text);

            if (operacao == "cadastrar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    ctx.Lancamentos.Add(l);
                    ctx.SaveChanges();
                }
            }
            if (operacao == "alterar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    l = ctx.Lancamentos.Find(Convert.ToInt32(textBoxCodigo.Text));
                    if (l != null)
                    {
                        l.tipo = comboBoxTipo.Text;
                        l.data = comboBoxData.Text;
                        l.descricao = TextBoxDescricao.Text;
                        l.forma_pagamento = comboBoxFormaPagamento.Text;
                        l.valor = Convert.ToDecimal(TextBoxValor.Text);
                        ctx.SaveChanges();
                    }

                }

            }
            if (operacao == "excluir")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    l = ctx.Lancamentos.Find(Convert.ToInt32(textBoxCodigo.Text));
                    ctx.Lancamentos.Remove(l);
                    ctx.SaveChanges();

                }
            }
            AlteraBotoes(1);
            LimparCampos();
            ListarLancamentos();
        }

        private void ButtonEditar_Click(object sender, RoutedEventArgs e)
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

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "";
            AlteraCampos(1);
            AlteraBotoes(1);
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxCodigo.Text = "";
            comboBoxTipo.Text = "";
            comboBoxData.Text = "";
            comboBoxMes.Text = "";
            TextBoxDescricao.Text = "";
            comboBoxFormaPagamento.Text = "";
            TextBoxValor.Text = "";
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
            comboBoxTipo.IsEnabled = false;
            comboBoxData.IsEnabled = false;
            comboBoxMes.IsEnabled = false;
            TextBoxDescricao.IsEnabled = false;
            comboBoxFormaPagamento.IsEnabled = false;
            TextBoxValor.IsEnabled = false;
            if (op == 1)
            {
                comboBoxTipo.IsEnabled = true;
                comboBoxData.IsEnabled = true;
                comboBoxMes.IsEnabled = true;
                TextBoxDescricao.IsEnabled = true;
                comboBoxFormaPagamento.IsEnabled = true;
                TextBoxValor.IsEnabled = true;
            }
        }

        private void DataGridConsulta_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (dataGridConsulta.SelectedIndex >= 0)
            {
                Lancamento l = (Lancamento)dataGridConsulta.Items[dataGridConsulta.SelectedIndex];
                textBoxCodigo.Text = l.codigo.ToString();
                comboBoxTipo.Text = l.tipo;
                comboBoxData.Text = l.data;
                TextBoxDescricao.Text = l.descricao;
                comboBoxFormaPagamento.Text = l.forma_pagamento;
                TextBoxValor.Text = l.valor.ToString();
                
                AlteraBotoes(3);
                AlteraCampos(1);
            }
        }
        private void ListarLancamentos()
        {
            using (DbContexto ctx = new DbContexto())
            {
                int a = ctx.Lancamentos.Count();
                conta.Content = a;
                var consulta = ctx.Lancamentos;
                dataGridConsulta.ItemsSource = consulta.ToList();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AlteraBotoes(1);
            ListarLancamentos();
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DbContexto ctx = new DbContexto())
                {
                    var consulta = from c in ctx.Lancamentos where c.data.Contains(textBoxBuscar.Text) || c.descricao.Contains(textBoxBuscar.Text) select c;
                    dataGridConsulta.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }
    }
}
