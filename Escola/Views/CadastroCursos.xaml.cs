using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Escola.Model;
using MahApps.Metro.Controls.Dialogs;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace Escola.Views
{
    public partial class CadastroCursos
    {
        public CadastroCursos()
        {
            InitializeComponent();
            LoadCombos();
        }

        public static List<CadastroCursosModel> cadastroCursos = new List<CadastroCursosModel>();
        private Notifications.Notifications notification = new Notifications.Notifications();

        private void LoadCombos()
        {
            cboPeriodo.Items.Clear();
            MainWindow.periodo.ForEach(x =>
            {
                cboPeriodo.Items.Add(x.Periodo);
            });

            cboModalidadeCurso.Items.Clear();
            MainWindow.modalidade.ForEach(x =>
            {
                cboModalidadeCurso.Items.Add(x.Modalidade);
            });
        }

        private void BtnVoltar_OnClick(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            Close();
        }

        private async void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (await Validate() == false) return;
            cadastroCursos.Add(new CadastroCursosModel
            {
                NomeCurso = txtCurso.Text,
                Periodo = cboPeriodo.SelectedItem.ToString(),
                ModalidadeCurso = cboModalidadeCurso.SelectedItem.ToString()
            });
            notification.notifier.ShowInformation("Cadastro Salvo!");
            clear();
        }

        private void clear()
        {
            txtCurso.Clear();

            cboPeriodo.SelectedIndex = -1;
            cboPeriodo.Text = "Selecione...";

            cboModalidadeCurso.SelectedIndex = -1;
            cboModalidadeCurso.Text = "Selecione...";
        }

        private async Task<MessageDialogResult> ShowMessage(string message)
        {
            return await App.CurrentWindow.ShowMessageAsync("Atenção", message);
        }

        public async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(txtCurso.Text)
                || cboPeriodo.SelectedIndex == -1
                || cboModalidadeCurso.SelectedIndex == -1)
            {
                await ShowMessage("Preencha todos os campos corretamente!");
                return false;
            }

            if (cadastroCursos.Any(x => string.Equals(x.NomeCurso, txtCurso.Text, StringComparison.CurrentCultureIgnoreCase)
                                     && string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                     && string.Equals(x.ModalidadeCurso, cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)))
            {
                await ShowMessage("Já existe um cadastro com essas informações!");
                return false;
            }

            return true;
        }

        private void CadastroCursos_OnInitialized(object sender, EventArgs e)
        {
            App.CurrentWindow = this;
        }
    }
}
