using Banco_de_Dados.Classes;
using Banco_de_Dados.Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Teste.Frams
{
    /// <summary>
    /// Interação lógica para AgendamentoConsultas.xam
    /// </summary>
    public partial class AgendamentoConsultas : Page
    {
        private string operacao;
        public List<Medico> med { get; set; }
        public List<Plano> pla { get; set; }
        public AgendamentoConsultas()
        {
            InitializeComponent();
        }

        private void PreencherComboBox()
        {
            try
            {
                using (DbContexto ctx = new DbContexto())
                {
                    var item = ctx.Medicos.ToList();
                    med = item;

                    var item2 = ctx.Planos.ToList();
                    pla = item2;

                    comboBoxMedico.DataContext = med;
                    comboBoxConvenio.DataContext = pla;
                }
            }
            catch { }
        }

        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            PreencherComboBox();
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
            Agendamento a = new Agendamento();
            a.medico = Convert.ToInt32(comboBoxMedico.Text);
            a.tipo = comboBoxTipoAgendamento.Text;
            a.data = datePickerDataAgendamento.Text;
            a.horario = textBoxHoraAtendimento.Text;
            a.paciente = textBoxCodigoPaciente.Text;
            a.convenio = comboBoxConvenio.Text;

            if (operacao == "cadastrar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    ctx.Agendamentos.Add(a);
                    ctx.SaveChanges();
                }
            }
            if (operacao == "alterar")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    a = ctx.Agendamentos.Find(Convert.ToInt32(textBoxCodigo.Text));
                    if (a != null)
                    {
                        a.medico = Convert.ToInt32(comboBoxMedico.Text);
                        a.tipo = comboBoxTipoAgendamento.Text;
                        a.data = datePickerDataAgendamento.Text;
                        a.horario = textBoxHoraAtendimento.Text;
                        a.paciente = textBoxCodigoPaciente.Text;
                        a.convenio = comboBoxConvenio.Text;
                        ctx.SaveChanges();
                    }

                }

            }
            if (operacao == "excluir")
            {
                using (DbContexto ctx = new DbContexto())
                {
                    a = ctx.Agendamentos.Find(Convert.ToInt32(textBoxCodigo.Text));
                    ctx.Agendamentos.Remove(a);
                    ctx.SaveChanges();

                }
            }
            AlteraBotoes(1);
            LimparCampos();
            LimparTabela();
            ListarAgendamentos();
        }

        private void LimparTabela()
        {
            dataGridPaciente.ItemsSource = "";
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            operacao = "";
            AlteraCampos(1);
            AlteraBotoes(1);
            LimparCampos();
        }

        private void ButtonBuscaPaciente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DbContexto ctx = new DbContexto())
                {
                    var consulta = from c in ctx.Clientes where c.nome.Contains(textBoxPaciente.Text) select c;
                    dataGridPaciente.ItemsSource = consulta.ToList();
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
                    var consulta = from c in ctx.Agendamentos where c.data.Contains(textBoxBuscar.Text) select c;
                    dataGridConsulta.ItemsSource = consulta.ToList();
                }
            }
            catch { }
        }

        private void DataGridConsulta_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridConsulta.SelectedIndex >= 0)
            {
                PreencherComboBox();
                Agendamento a = (Agendamento)dataGridConsulta.Items[dataGridConsulta.SelectedIndex];

                textBoxCodigo.Text = a.codigo.ToString();
                comboBoxMedico.Text = a.medico.ToString();
                comboBoxTipoAgendamento.Text = a.tipo;
                datePickerDataAgendamento.Text = a.data;
                textBoxHoraAtendimento.Text = a.horario;
                textBoxCodigoPaciente.Text = a.paciente;
                comboBoxConvenio.Text = a.convenio;
                AlteraBotoes(3);
                AlteraCampos(1);
            }
        }

        private void DataGridPaciente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridPaciente.SelectedIndex >= 0)
            {
                Cliente p = (Cliente)dataGridPaciente.Items[dataGridPaciente.SelectedIndex];
                textBoxCodigoPaciente.Text = p.codigo.ToString();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AlteraBotoes(1);
            ListarAgendamentos();
        }
        private void LimparCampos()
        {
            comboBoxMedico.Text = "";
            textBoxCodigo.Text = "";
            comboBoxTipoAgendamento.Text = "";
            datePickerDataAgendamento.Text = "";
            textBoxHoraAtendimento.Text = "";
            textBoxCodigoPaciente.Text = "";
            comboBoxConvenio.Text = "";
        }

        private void AlteraBotoes(int op)
        {
            buttonCadastrar.IsEnabled = false;
            buttonAlterar.IsEnabled = false;
            buttonExcluir.IsEnabled = false;
            buttonSalvar.IsEnabled = false;
            buttonCancelar.IsEnabled = false;
            buttonBuscaPaciente.IsEnabled = false;

            if (op == 1)
            {
                buttonCadastrar.IsEnabled = true;
                AlteraCampos(0);
            }
            if (op == 2)
            {
                buttonSalvar.IsEnabled = true;
                buttonCancelar.IsEnabled = true;
                buttonBuscaPaciente.IsEnabled = true;
                AlteraCampos(1);
            }
            if (op == 3)
            {
                buttonAlterar.IsEnabled = true;
                buttonExcluir.IsEnabled = true;
                buttonCancelar.IsEnabled = true;
                buttonBuscaPaciente.IsEnabled = true;
                AlteraCampos(1);
            }
        }

        private void AlteraCampos(int op)
        {
            comboBoxMedico.IsEnabled = false;
            comboBoxTipoAgendamento.IsEnabled = false;
            datePickerDataAgendamento.IsEnabled = false;
            textBoxHoraAtendimento.IsEnabled = false;
            textBoxPaciente.IsEnabled = false;
            comboBoxConvenio.IsEnabled = false;

            if (op == 1)
            {
                comboBoxMedico.IsEnabled = true;
                comboBoxTipoAgendamento.IsEnabled = true;
                datePickerDataAgendamento.IsEnabled = true;
                textBoxHoraAtendimento.IsEnabled = true;
                comboBoxConvenio.IsEnabled = true;
                textBoxPaciente.IsEnabled = true;
            }
        }
        private void ListarAgendamentos()
        {
            using (DbContexto ctx = new DbContexto())
            {
                int a = ctx.Agendamentos.Count();
                conta.Content = a;
                var consulta = ctx.Agendamentos;
                dataGridConsulta.ItemsSource = consulta.ToList();
            }
        }
    }

}
