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
    /// Interação lógica para ControleDeGastos.xam
    /// </summary>
    public partial class ControleDeGastos : Page
    {
        public ControleDeGastos()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                using (DbContexto ctx = new DbContexto())
                {
                    var consulta1 = from c in ctx.Lancamentos where c.tipo.Equals("Entrada") select c;
                    dataGridEntradas.ItemsSource = consulta1.ToList();
                    var consulta2 = from c in ctx.Lancamentos where c.tipo.Equals("Saida") select c;
                    dataGridSaidas.ItemsSource = consulta2.ToList();

                    EntradaTotal.Content = consulta1.Sum(x => x.valor);
                    SaidaTotal.Content = consulta2.Sum(x => x.valor);
                    decimal en = Convert.ToDecimal(EntradaTotal.Content);
                    decimal sa = Convert.ToDecimal(SaidaTotal.Content);
                    SaldoTotal.Content = en + sa;

                    


                }
            }
            catch { }
        }

        private void ButtonBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DbContexto ctx = new DbContexto())
                {
                    var consulta1 = from c in ctx.Lancamentos where c.data.Equals(textBoxBuscar.Text) & c.tipo.Equals("Entrada") select c;
                    dataGridEntradas.ItemsSource = consulta1.ToList();
                    var consulta2 = from c in ctx.Lancamentos where c.data.Equals(textBoxBuscar.Text) & c.tipo.Equals("Saida") select c;
                    dataGridSaidas.ItemsSource = consulta2.ToList();
                }
            }
            catch { }
        }
    }
}
