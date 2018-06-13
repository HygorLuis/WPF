using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Escola.Model;
using Escola.Views;
using MahApps.Metro.Controls.Dialogs;

namespace Escola
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCboTipo();
            LoadInformation();
        }

        public static List<PeriodoModel> periodo = new List<PeriodoModel>();
        public static List<ModalidadeCursoModel> modalidade = new List<ModalidadeCursoModel>();

        private void LoadInformation()
        {
            if (periodo.Count > 0 && modalidade.Count > 0) return;
            var information = new Dictionary<int, string>();
            information.Add(0, "Integral");
            information.Add(1, "Matutino");
            information.Add(2, "Noturno");
            information.Add(3, "Vespertino");

            foreach (var inf in information)
            {
                periodo.Add(new PeriodoModel
                {
                    IdPeriodo = inf.Key,
                    Periodo = inf.Value
                });
            }

            information.Clear();
            information.Add(0, "Presencial");
            information.Add(1, "Semi-Presencial");
            information.Add(2, "EAD");

            foreach (var inf in information)
            {
                modalidade.Add(new ModalidadeCursoModel
                {
                    IdModalidade = inf.Key,
                    Modalidade = inf.Value
                });
            }
        }

        private void LoadCboTipo()
        {
            cboTipo.Items.Add("Cursos");
            cboTipo.Items.Add("Disciplinas");
            cboTipo.Items.Add("Alunos");
        }

        private async Task<MessageDialogResult> ShowMessage(string message)
        {
            return await App.CurrentWindow.ShowMessageAsync("Atenção", message);
        }

        public async Task<bool> Validate()
        {
            if (rbConsultar.IsChecked == false && rbCadastrar.IsChecked == false && rbExcluir.IsChecked == false)
            {
                await ShowMessage("Marque alguma opção!");
                return false;
            }

            return true;
        }

        private async void BtnConfirmar_OnClick(object sender, RoutedEventArgs e)
        {
            if (await Validate() == false) return;

            if (rbCadastrar.IsChecked == true)
            {
                switch (cboTipo.SelectedIndex)
                {
                    case 0:
                        var cadCursosView = new CadastroCursos();
                        cadCursosView.Show();
                        Close();
                        break;

                    case 1:
                        var cadDisciplinasView = new CadastroDisciplinas();
                        cadDisciplinasView.Show();
                        Close();
                        break;

                    case 2:
                        var cadAlunosView = new CadastroAlunos();
                        cadAlunosView.Show();
                        Close();
                        break;
                }
                return;
            }

            if (rbConsultar.IsChecked == true)
            {
                switch (cboTipo.SelectedIndex)
                {
                    case 0:
                        var ConsultaCadCursosView = new ConsultaCadCursos();
                        ConsultaCadCursosView.Show();
                        ConsultaCadCursosView.Visible(Visibility.Hidden);
                        Close();
                        break;

                    case 1:
                        var ConsultaCadDisciplinasView = new ConsultaCadDisciplinas();
                        ConsultaCadDisciplinasView.Show();
                        ConsultaCadDisciplinasView.Visible(Visibility.Hidden);
                        Close();
                        break;

                    case 2:
                        var ConsultaCadAlunosView = new ConsultaCadAlunos();
                        ConsultaCadAlunosView.Show();
                        ConsultaCadAlunosView.Visible(Visibility.Hidden);
                        Close();
                        break;
                }
                return;
            }

            if (rbExcluir.IsChecked == true)
            {
                switch (cboTipo.SelectedIndex)
                {
                    case 0:
                        var ConsultaCadCursosView = new ConsultaCadCursos();
                        ConsultaCadCursosView.Show();
                        ConsultaCadCursosView.Visible(Visibility.Visible);
                        Close();
                        break;

                    case 1:
                        var cadDisciplinasView = new ConsultaCadDisciplinas();
                        cadDisciplinasView.Show();
                        cadDisciplinasView.Visible(Visibility.Visible);
                        Close();
                        break;

                    case 2:
                        var cadAlunosView = new ConsultaCadAlunos();
                        cadAlunosView.Show();
                        cadAlunosView.Visible(Visibility.Visible);
                        Close();
                        break;
                }
            }
        }

        private void BtnFechar_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainWindow_OnInitialized(object sender, EventArgs e)
        {
            App.CurrentWindow = this;
        }
    }
}
