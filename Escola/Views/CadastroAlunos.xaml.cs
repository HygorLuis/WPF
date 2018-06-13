using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Escola.Model;
using MahApps.Metro.Controls.Dialogs;
using ToastNotifications.Messages;

namespace Escola.Views
{
    /// <summary>
    /// Interação lógica para CasdastroAlunos.xam
    /// </summary>
    public partial class CadastroAlunos
    {
        public CadastroAlunos()
        {
            InitializeComponent();
            LoadCombos();
            Enabled(false, false, false);
        }

        private List<CadastroCursosModel> lista = new List<CadastroCursosModel>();
        public static List<CadastroAlunosModel> alunos = new List<CadastroAlunosModel>();
        private Notifications.Notifications notification = new Notifications.Notifications();

        private void Enabled(bool periodo, bool modalidade, bool disciplina)
        {
            cboPeriodo.IsEnabled = periodo;
            cboModalidadeCurso.IsEnabled = modalidade;
            cboDisciplina.IsEnabled = disciplina;
        }

        private void LoadCombos()
        {
            cboNomeCurso.Items.Clear();
            CadastroCursos.cadastroCursos.ForEach(x =>
            {
                var add = cboNomeCurso.Items.Cast<object>().All(item => item.ToString().ToUpper() != x.NomeCurso.ToUpper());
                if (add)
                    cboNomeCurso.Items.Add(x.NomeCurso);
            });
        }

        private void BtnVoltar_OnClick(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            Close();
        }

        private async Task<MessageDialogResult> ShowMessage(string message)
        {
            return await App.CurrentWindow.ShowMessageAsync("Atenção", message);
        }

        public async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(txtNomeAluno.Text) 
                || string.IsNullOrEmpty(txtRA.Text)
                || cboNomeCurso.SelectedIndex == -1 
                || cboPeriodo.SelectedIndex == -1 
                || cboModalidadeCurso.SelectedIndex == -1 
                || cboDisciplina.SelectedIndex == -1)
            {
                await ShowMessage("Preencha todos os campos corretamente!");
                return false;
            }

            if (!long.TryParse(txtRA.Text, out var i))
            {
                await ShowMessage("Digite somente números no RA!");
                return false;
            }

            if (alunos.Any(x => string.Equals(x.NomeAluno, txtNomeAluno.Text, StringComparison.CurrentCultureIgnoreCase) 
                             && string.Equals(x.RA, txtRA.Text, StringComparison.CurrentCultureIgnoreCase)
                             && string.Equals(x.Curso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                             && string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                             && string.Equals(x.ModalidadeCurso, cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                             && string.Equals(x.Disciplina, cboDisciplina.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)))
            {
                await ShowMessage("Já existe um cadastro com essas informações!");
                return false;
            }

            return true;
        }

        private async void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (await Validate() == false) return;
            alunos.Add(new CadastroAlunosModel
            {
                NomeAluno = txtNomeAluno.Text,
                RA = txtRA.Text,
                Curso = cboNomeCurso.SelectedItem.ToString(),
                Periodo = cboPeriodo.SelectedItem.ToString(),
                ModalidadeCurso = cboModalidadeCurso.SelectedItem.ToString(),
                Disciplina = cboDisciplina.SelectedItem.ToString()
            });
            notification.notifier.ShowInformation("Cadastro Salvo!");
            clear();
            Enabled(false, false, false);
        }

        private void clear()
        {
            txtNomeAluno.Clear();
            txtRA.Clear();

            cboNomeCurso.SelectedIndex = -1;
            cboNomeCurso.Text = "Selecione...";

            cboPeriodo.SelectedIndex = -1;
            cboPeriodo.Text = "Selecione...";

            cboModalidadeCurso.SelectedIndex = -1;
            cboModalidadeCurso.Text = "Selecione...";

            cboDisciplina.SelectedIndex = -1;
            cboDisciplina.Text = "Selecione...";
        }

        private void CboNomeCurso_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboNomeCurso.SelectedIndex <= -1) return;
            lista = CadastroCursos.cadastroCursos.Where(x => string.Equals(x.NomeCurso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboPeriodo.Items.Clear();
            lista.ForEach(x =>
            {
                var add = cboPeriodo.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.Periodo, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboPeriodo.Items.Add(x.Periodo);
            });
            Enabled(true, false, false);
        }

        private void CboPeriodo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPeriodo.SelectedIndex <= -1) return;
            lista = lista.Where(x => string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboModalidadeCurso.Items.Clear();
            lista.ForEach(x =>
            {
                var add = cboModalidadeCurso.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.ModalidadeCurso, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboModalidadeCurso.Items.Add(x.ModalidadeCurso);
            });
            Enabled(true, true, false);
        }

        private void CboModalidadeCurso_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboModalidadeCurso.SelectedIndex <= -1) return;
            var listaDisciplina = CadastroDisciplinas.cadastroDisciplinas.Where(m => string.Equals(m.ModalidadeCurso, cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                                                  && string.Equals(m.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                                                  && string.Equals(m.Curso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboDisciplina.Items.Clear();
            listaDisciplina.ForEach(x =>
            {
                var add = cboDisciplina.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.NomeDisciplina, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboDisciplina.Items.Add(x.NomeDisciplina);
            });
            Enabled(true, true, true);
        }

        private void CadastroAlunos_OnInitialized(object sender, EventArgs e)
        {
            App.CurrentWindow = this;
        }
    }
}
