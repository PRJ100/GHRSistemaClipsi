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
    /// Interação lógica para Cadastro.xam
    /// </summary>
    public partial class Cadastro : Page
    {
        private string operacao;
        public Cadastro()
        {
            InitializeComponent();
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            Cliente p = new Cliente();
            p.nome = textBoxNome.Text;
            p.cpf = textBoxCpf.Text;
            p.rg = textBoxRg.Text;
            p.telefone = textBoxTelefone.Text;
            p.sexo = comboBoxSexo.Text;
            p.email = textBoxEmail.Text;
            p.nascimento = textBoxDataNascimento.Text;
            p.bairro = textBoxBairro.Text;
            p.endereco = textBoxEndereco.Text;
            p.numero = textBoxNumero.Text;
            p.cidade = textBoxCidade.Text;
            p.cep = textBoxCep.Text;
            p.estado = textBoxEstado.Text;
            p.ativo = comboBoxAtivo.Text;

            if (operacao == "cadastrar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    ctx.Clientes.Add(p);
                    ctx.SaveChanges();
                }
            }
            if (operacao == "alterar")
            {
               using(DbContexto ctx = new DbContexto())
                {
                    p = ctx.Clientes.Find(Convert.ToInt32(textBoxCodigo.Text));
                    if(p != null)
                    {
                        p.nome = textBoxNome.Text;
                        p.cpf = textBoxCpf.Text;
                        p.rg = textBoxRg.Text;
                        p.telefone = textBoxTelefone.Text;
                        p.sexo = comboBoxSexo.Text;
                        p.email = textBoxEmail.Text;
                        p.nascimento = textBoxDataNascimento.Text;
                        p.bairro = textBoxBairro.Text;
                        p.endereco = textBoxEndereco.Text;
                        p.numero = textBoxNumero.Text;
                        p.cidade = textBoxCidade.Text;
                        p.cep = textBoxCep.Text;
                        p.estado = textBoxEstado.Text;
                        p.ativo = comboBoxAtivo.Text;
                        ctx.SaveChanges();
                    }

                }

            }
            if (operacao == "excluir")
            {
                using(DbContexto ctx = new DbContexto())
                {
                    p = ctx.Clientes.Find(Convert.ToInt32(textBoxCodigo.Text));
                    ctx.Clientes.Remove(p);
                    ctx.SaveChanges();

                }
            }
            AlteraBotoes(1);
            LimparCampos();
            ListarPacientes();
        }

        private void ListarPacientes()
        {
            using(DbContexto ctx = new DbContexto())
            {
                int a = ctx.Clientes.Count();
                conta.Content = a;
                var consulta = ctx.Clientes;
                dataGridConsulta.ItemsSource = consulta.ToList();
            }
        }

        private void LimparCampos()
        {
            textBoxCodigo.Text = "";
            textBoxNome.Text = "";
            textBoxCpf.Text = "";
            textBoxRg.Text = "";
            textBoxTelefone.Text = "";
            comboBoxSexo.Text = "";
            textBoxEmail.Text = "";
            textBoxDataNascimento.Text = "";
            textBoxBairro.Text = "";
            textBoxEndereco.Text = "";
            textBoxNumero.Text = "";
            textBoxCidade.Text = "";
            textBoxCep.Text = "";
            textBoxEstado.Text = "";
            comboBoxAtivo.Text = "";
        }


        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            this.operacao = "cadastrar";
            AlteraBotoes(2);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AlteraBotoes(1);
            ListarPacientes();
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
            if(op == 2)
            {
                buttonSalvar.IsEnabled = true;
                buttonCancelar.IsEnabled = true;
                AlteraCampos(1);
            }
            if(op == 3)
            {
                buttonAlterar.IsEnabled = true;
                buttonExcluir.IsEnabled = true;
                buttonCancelar.IsEnabled = true;
                AlteraCampos(1);
            }
        }
        private void AlteraCampos(int op)
        {
            textBoxNome.IsEnabled = false;
            textBoxCpf.IsEnabled = false;
            textBoxRg.IsEnabled = false;
            textBoxTelefone.IsEnabled = false;
            comboBoxSexo.IsEnabled = false;
            textBoxEmail.IsEnabled = false;
            textBoxDataNascimento.IsEnabled = false;
            textBoxBairro.IsEnabled = false;
            textBoxEndereco.IsEnabled = false;
            textBoxNumero.IsEnabled = false;
            textBoxCidade.IsEnabled = false;
            textBoxCep.IsEnabled = false;
            textBoxEstado.IsEnabled = false;
            comboBoxAtivo.IsEnabled = false;
            if(op == 1)
            {
                textBoxNome.IsEnabled = true;
                textBoxCpf.IsEnabled = true;
                textBoxRg.IsEnabled = true;
                textBoxTelefone.IsEnabled = true;
                comboBoxSexo.IsEnabled = true;
                textBoxEmail.IsEnabled = true;
                textBoxDataNascimento.IsEnabled = true;
                textBoxBairro.IsEnabled = true;
                textBoxEndereco.IsEnabled = true;
                textBoxNumero.IsEnabled = true;
                textBoxCidade.IsEnabled = true;
                textBoxCep.IsEnabled = true;
                textBoxEstado.IsEnabled = true;
                comboBoxAtivo.IsEnabled = true;
            }
        }

        private void ButtonExcluir_Click(object sender, RoutedEventArgs e)
        {
            operacao = "excluir";
            AlteraCampos(2);
            AlteraBotoes(2);
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DbContexto ctx = new DbContexto())
                {
                    var consulta = from c in ctx.Clientes where c.nome.Contains(textBoxBuscar.Text) || c.cpf.Contains(textBoxBuscar.Text) || c.cidade.Contains(textBoxBuscar.Text) select c;
                    dataGridConsulta.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }

        private void DataGridConsulta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataGridConsulta.SelectedIndex >= 0)
            {
                Cliente p = (Cliente)dataGridConsulta.Items[dataGridConsulta.SelectedIndex];
                textBoxCodigo.Text = p.codigo.ToString();
                textBoxNome.Text = p.nome;
                textBoxCpf.Text = p.cpf;
                textBoxRg.Text = p.rg;
                textBoxTelefone.Text = p.telefone;
                comboBoxSexo.Text = p.sexo;
                textBoxEmail.Text = p.email;
                textBoxDataNascimento.Text = p.nascimento;
                textBoxBairro.Text = p.bairro;
                textBoxEndereco.Text = p.endereco;
                textBoxNumero.Text = p.numero;
                textBoxCidade.Text = p.cidade;
                textBoxCep.Text = p.cep;
                textBoxEstado.Text = p.estado;
                comboBoxAtivo.Text = p.ativo;
                AlteraBotoes(3);
                AlteraCampos(1);
            }
        }

        private void ButtonAlterar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "alterar";
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
    }
}
