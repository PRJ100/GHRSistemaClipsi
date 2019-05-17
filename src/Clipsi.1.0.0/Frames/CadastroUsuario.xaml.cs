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
    /// Interação lógica para CadastroUsuario.xam
    /// </summary>
    public partial class CadastroUsuario : Page
    {
        private string operacao;
        public CadastroUsuario()
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
            Usuario u = new Usuario();
            u.usuario1 = textBoxUsuario.Text;
            u.senha = passwordBoxSenha.Password;
            u.nivel_acesso = Convert.ToInt32(comboBoxNivelAcesso.Text);

            if (operacao == "cadastrar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    if (passwordBoxSenha.Password == passwordBoxConfirmaSenha.Password)
                    {
                        labelSenha.Content = "";
                        ctx.Usuarios.Add(u);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        labelSenha.Content = "Senha não confere!!";
                    }
                }
            }
            if (operacao == "alterar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    u = ctx.Usuarios.Find(Convert.ToInt32(textBoxCodigo.Text));
                    if (u != null)
                    {
                        if (passwordBoxConfirmaSenha.Password == passwordBoxSenha.Password)
                        {
                            u.usuario1 = textBoxUsuario.Text;
                            u.senha = passwordBoxSenha.Password;
                            u.nivel_acesso = Convert.ToInt32(comboBoxNivelAcesso.Text);
                            labelSenha.Content = "";
                            ctx.SaveChanges();
                        }
                        else
                        {
                            labelSenha.Content = "Senha não confere!!";
                        }
                    }

                }

            }
            if (operacao == "excluir")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    u = ctx.Usuarios.Find(Convert.ToInt32(textBoxCodigo.Text));
                    ctx.Usuarios.Remove(u);
                    ctx.SaveChanges();

                }
            }
            if (passwordBoxConfirmaSenha.Password == passwordBoxSenha.Password)
            {
                AlteraBotoes(1);
                LimparCampos();
                ListarUsuarios();
            }

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
            try
            {
                using (DbContexto ctx = new DbContexto())
                {
                    var consulta = from c in ctx.Usuarios where c.usuario1.Contains(textBoxBuscar.Text) select c;
                    dataGridConsulta.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }

        private void DataGridConsulta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridConsulta.SelectedIndex >= 0)
            {
                Usuario u = (Usuario)dataGridConsulta.Items[dataGridConsulta.SelectedIndex];
                textBoxCodigo.Text = u.codigo.ToString();
                textBoxUsuario.Text = u.usuario1;
                passwordBoxSenha.Password = u.senha;
                passwordBoxConfirmaSenha.Password = u.senha;
                comboBoxNivelAcesso.Text = u.nivel_acesso.ToString();
                AlteraBotoes(3);
                AlteraCampos(1);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AlteraBotoes(1);
            ListarUsuarios();
        }
        private void LimparCampos()
        {
            textBoxCodigo.Text = "";
            textBoxUsuario.Text = "";
            passwordBoxSenha.Password = "";
            passwordBoxConfirmaSenha.Password = "";
            comboBoxNivelAcesso.Text = "";
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
            textBoxUsuario.IsEnabled = false;
            passwordBoxSenha.IsEnabled = false;
            passwordBoxConfirmaSenha.IsEnabled = false;
            comboBoxNivelAcesso.IsEnabled = false;

            if (op == 1)
            {
                textBoxUsuario.IsEnabled = true;
                passwordBoxSenha.IsEnabled = true;
                passwordBoxConfirmaSenha.IsEnabled = true;
                comboBoxNivelAcesso.IsEnabled = true;
            }
        }
        private void ListarUsuarios()
        {
            using (DbContexto ctx = new DbContexto())
            {
                int a = ctx.Usuarios.Count();
                conta.Content = a;
                var consulta = ctx.Usuarios;
                dataGridConsulta.ItemsSource = consulta.ToList();
            }
        }
    }
}
