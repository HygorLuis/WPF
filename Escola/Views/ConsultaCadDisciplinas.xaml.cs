using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using ToastNotifications.Messages;

namespace Escola.Views
{
    /// <summary>
    /// Interação lógica para ConsultaCadDisciplinas.xam
    /// </summary>
    public partial class ConsultaCadDisciplinas
    {
        public ConsultaCadDisciplinas()
        {
            InitializeComponent();
            LoadCombo();
            Enabled(false, false, false);
        }

        private Notifications.Notifications notification = new Notifications.Notifications();

        public void Visible(Visibility visible)
        {
            btnDelete.Visibility = visible;
        }

        private void Enabled(bool periodo, bool modalidade, bool disciplina)
        {
            cboPeriodo.IsEnabled = periodo;
            cboModalidadeCurso.IsEnabled = modalidade;
            cboDisciplina.IsEnabled = disciplina;
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

        private void ConsultaCadDisciplinas_OnInitialized(object sender, EventArgs e)
        {
            App.CurrentWindow = this;
        }

        private void BtnVoltar_OnClick(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            Close();
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

            Enabled(true, false, false);
            Clear(true, true, true);
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

            Enabled(true, true, false);
            Clear(false, true, true);
        }

        private void CboModalidadeCurso_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboModalidadeCurso.SelectedIndex <= -1) return;
            var list = CadastroDisciplinas.cadastroDisciplinas.Where(x => string.Equals(x.Curso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                                       && string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                                       && string.Equals(x.ModalidadeCurso, cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboDisciplina.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboDisciplina.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.NomeDisciplina, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboDisciplina.Items.Add(x.NomeDisciplina);
            });

            Enabled(true, true, true);
            Clear(false, false, true);
        }

        private async void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (await Validate() == false) return;
            var quest = await ShowMessage("Deseja prosseguir com a exclusão!", true);
            if (quest == MessageDialogResult.Negative) return;

            var index = 0;
            foreach (var disciplina in CadastroDisciplinas.cadastroDisciplinas)
            {
                if (disciplina.Curso == cboNomeCurso.SelectedItem.ToString() 
                    && disciplina.Periodo == cboPeriodo.SelectedItem.ToString() 
                    && disciplina.ModalidadeCurso == cboModalidadeCurso.SelectedItem.ToString() 
                    && disciplina.NomeDisciplina == cboDisciplina.SelectedItem.ToString())
                    break;
                index++;
            }

            CadastroDisciplinas.cadastroDisciplinas.RemoveAt(index);
            notification.notifier.ShowError("Excluido!");
            LoadCombo();
            Enabled(false, false, false);
            Clear(true, true, true);
        }

        private async Task<bool> Validate()
        {
            if (cboNomeCurso.SelectedIndex == -1
                || cboPeriodo.SelectedIndex == -1
                || cboModalidadeCurso.SelectedIndex == -1
                || cboDisciplina.SelectedIndex == -1)
            {
                await ShowMessage("Preencha todos os campos antes de prosseguir com a exclusão!", false);
                return false;
            }

            return true;
        }

        private async Task<MessageDialogResult> ShowMessage(string message, bool quest)
        {
            if (!quest)
                return await App.CurrentWindow.ShowMessageAsync("Atenção", message);

            return await App.CurrentWindow.ShowMessageAsync("Atenção", message, MessageDialogStyle.AffirmativeAndNegative);
        }

        private void Clear(bool periodo, bool modalidade, bool disciplina)
        {
            if (periodo)
            {
                cboPeriodo.SelectedIndex = -1;
                cboPeriodo.Text = "Selecione...";
            }

            if (modalidade)
            {
                cboModalidadeCurso.SelectedIndex = -1;
                cboModalidadeCurso.Text = "Selecione...";
            }

            if (disciplina)
            {
                cboDisciplina.SelectedIndex = -1;
                cboDisciplina.Text = "Selecione...";
            }
        }
    }
}
