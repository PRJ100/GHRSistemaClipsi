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
using System.Windows.Shapes;

namespace Teste.Frams
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ButtonLogar_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUsuario.Text != "" && passwordBoxSenha.Password != "")
            {
                try
                {
                    using (DbContexto ctx = new DbContexto())
                    {

                        var consulta = ctx.Usuarios.FirstOrDefault(u => u.usuario1 == textBoxUsuario.Text);
                      
                        if (consulta != null)
                        {
                            if (consulta.senha == passwordBoxSenha.Password)
                            {
                                this.Hide();
                                new Frams.Prinipal(consulta.usuario1, consulta.nivel_acesso.ToString()).ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Senha invalida!!");
                            }
                        }
                        else {
                            MessageBox.Show("Usuário invalido!!");
                        }
                    }
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Campo usuário ou senha estão vazios!!");
            }
        }

        private void ButtonSair_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
