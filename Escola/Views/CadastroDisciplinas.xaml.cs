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
    public partial class CadastroDisciplinas
    {
        public CadastroDisciplinas()
        {
            InitializeComponent();
            LoadCombo();
            Enabled(false, false);
        }

        public static List<CadastroDisciplinasModel> cadastroDisciplinas = new List<CadastroDisciplinasModel>();
        private Notifications.Notifications notification = new Notifications.Notifications();

        private void Enabled(bool periodo, bool modalidade)
        {
            cboPeriodo.IsEnabled = periodo;
            cboModalidadeCurso.IsEnabled = modalidade;
        }

        private void LoadCombo()
        {
            cboNomeCurso.Items.Clear();
            CadastroCursos.cadastroCursos.ForEach(x =>
            {
                var add = cboNomeCurso.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.NomeCurso, StringComparison.CurrentCultureIgnoreCase));
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

        public async Task<MessageDialogResult> ShowMessage(string message)
        {
            return await App.CurrentWindow.ShowMessageAsync("Atenção", message);
        }

        private async Task<bool> Validate()
        {
            if (cboNomeCurso.SelectedIndex == -1 
                || cboPeriodo.SelectedIndex == -1 
                || cboModalidadeCurso.SelectedIndex == -1 
                || string.IsNullOrEmpty(txtNomeDisciplina.Text))
            {
                await ShowMessage("Preencha todos os campos corretamente!");
                return false;
            }

            if (cadastroDisciplinas.Any(x => string.Equals(x.Curso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                          && string.Equals(x.NomeDisciplina, txtNomeDisciplina.Text, StringComparison.CurrentCultureIgnoreCase) 
                                          && string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                          && string.Equals(x.ModalidadeCurso, cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)))
            {
                await ShowMessage("Já existe um cadastro com essas informações!");
                return false;
            }

            return true;
        }

        private async void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (await Validate() == false) return;
            cadastroDisciplinas.Add(new CadastroDisciplinasModel
            {
                Curso = cboNomeCurso.SelectedItem.ToString(),
                Periodo = cboPeriodo.SelectedItem.ToString(),
                ModalidadeCurso = cboModalidadeCurso.SelectedItem.ToString(),
                NomeDisciplina = txtNomeDisciplina.Text
            });
            notification.notifier.ShowInformation("Cadastro Salvo!");
            clear();
            Enabled(false, false);
        }

        private void clear()
        {
            cboNomeCurso.SelectedIndex = -1;
            cboNomeCurso.Text = "Selecione...";

            cboPeriodo.SelectedIndex = -1;
            cboPeriodo.Text = "Selecione...";

            cboModalidadeCurso.SelectedIndex = -1;
            cboModalidadeCurso.Text = "Selecione...";

            txtNomeDisciplina.Clear();
        }

        private void CboNomeCurso_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboNomeCurso.SelectedIndex <= -1) return;
            var list = CadastroCursos.cadastroCursos.Where(x => string.Equals(x.NomeCurso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboPeriodo.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboPeriodo.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.Periodo, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboPeriodo.Items.Add(x.Periodo);
            });

            Enabled(true, false);
        }

        private void CadastroDisciplinas_OnInitialized(object sender, EventArgs e)
        {
            App.CurrentWindow = this;
        }

        private void CboPeriodo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPeriodo.SelectedIndex <= -1) return;
            var list = CadastroCursos.cadastroCursos.Where(x => string.Equals(x.NomeCurso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                             && string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboModalidadeCurso.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboModalidadeCurso.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.ModalidadeCurso, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboModalidadeCurso.Items.Add(x.ModalidadeCurso);
            });

            Enabled(true, true);
        }
    }
}
