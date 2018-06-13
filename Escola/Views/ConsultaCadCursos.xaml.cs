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
    /// Interação lógica para ConsultaCadCursos.xam
    /// </summary>
    public partial class ConsultaCadCursos
    {
        public ConsultaCadCursos()
        {
            InitializeComponent();
            LoadCombos();
            Enabled(false, false);
        }

        private Notifications.Notifications notification = new Notifications.Notifications();

        public void Visible(Visibility visible)
        {
            btnDelete.Visibility = visible;
        }

        private void Enabled(bool periodo, bool modalidade)
        {
            cboPeriodo.IsEnabled = periodo;
            cboModalidadeCurso.IsEnabled = modalidade;
        }

        private void LoadCombos()
        {
            cboCurso.Items.Clear();
            CadastroCursos.cadastroCursos.ForEach(x =>
            {
                var add = cboCurso.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.NomeCurso, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboCurso.Items.Add(x.NomeCurso);
            });
        }

        private void ConsultaCadCursos_OnInitialized(object sender, EventArgs e)
        {
            App.CurrentWindow = this;
        }

        private void BtnVoltar_OnClick(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            Close();
        }

        private async Task<MessageDialogResult> ShowMessage(string message, bool quest)
        {
            if (!quest)
                return await App.CurrentWindow.ShowMessageAsync("Atenção", message);

            return await App.CurrentWindow.ShowMessageAsync("Atenção", message, MessageDialogStyle.AffirmativeAndNegative);
        }

        private async Task<bool> Validate()
        {
            if (cboCurso.SelectedIndex == -1
                || cboPeriodo.SelectedIndex == -1
                || cboModalidadeCurso.SelectedIndex == -1)
            {
                await ShowMessage("Preencha todos os campos antes de prosseguir com a exclusão!", false);
                return false;
            }

            return true;
        }

        private async void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if(await Validate() == false) return;
            var quest = await ShowMessage("Deseja prosseguir com a exclusão!", true);
            if (quest == MessageDialogResult.Negative) return;

            var index = 0;
            foreach (var curso in CadastroCursos.cadastroCursos)
            {
                if (string.Equals(curso.NomeCurso, cboCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                    && string.Equals(curso.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                    && string.Equals(curso.ModalidadeCurso, cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    break;
                index++;
            }

            CadastroCursos.cadastroCursos.RemoveAt(index);
            notification.notifier.ShowError("Excluido!");
            LoadCombos();
            Enabled(false, false);
            Clear(true, true);
        }

        private void CboCurso_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCurso.SelectedIndex <= -1) return;
            var list = CadastroCursos.cadastroCursos.Where(x => string.Equals(x.NomeCurso, cboCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboPeriodo.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboPeriodo.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.Periodo, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboPeriodo.Items.Add(x.Periodo);
            });

            Clear(true, true);
            Enabled(true, false);
        }

        private void CboPeriodo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPeriodo.SelectedIndex <= -1) return;
            var list = CadastroCursos.cadastroCursos.Where(x => string.Equals(x.NomeCurso, cboCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                             && string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboModalidadeCurso.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboModalidadeCurso.Items.Cast<object>().All(item => !string.Equals(item.ToString(), cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboModalidadeCurso.Items.Add(x.ModalidadeCurso);
            });
            Clear(false, true);
            Enabled(true, true);
        }

        private void Clear(bool periodo, bool modalidade)
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
        }
    }
}
