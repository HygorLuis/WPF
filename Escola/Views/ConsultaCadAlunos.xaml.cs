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
    /// Interação lógica para ConsultaCadAlunos.xam
    /// </summary>
    public partial class ConsultaCadAlunos
    {
        public ConsultaCadAlunos()
        {
            InitializeComponent();
            LoadCombo();
            Enabled(false, false, false, false);
        }

        private Notifications.Notifications notification = new Notifications.Notifications();

        private void Enabled(bool curso, bool periodo, bool modalidade, bool disciplina)
        {
            cboNomeCurso.IsEnabled = curso;
            cboPeriodo.IsEnabled = periodo;
            cboModalidadeCurso.IsEnabled = modalidade;
            cboDisciplina.IsEnabled = disciplina;
        }

        private void Clear(bool ra, bool curso, bool periodo, bool modalidade, bool disciplina)
        {
            if (ra)
                txtRA.Clear();

            if (curso)
            {
                cboNomeCurso.SelectedIndex = -1;
                cboNomeCurso.Text = "Selecione...";
            }

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

        private void LoadCombo()
        {
            cboNomeAluno.Items.Clear();
            CadastroAlunos.alunos.ForEach(x =>
            {
                var add = cboNomeAluno.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.NomeAluno, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboNomeAluno.Items.Add(x.NomeAluno);
            });
        }

        public void Visible(Visibility visible)
        {
            btnDelete.Visibility = visible;
        }

        private void ConsultaCadAlunos_OnInitialized(object sender, EventArgs e)
        {
            App.CurrentWindow = this;
        }

        private void BtnVoltar_OnClick(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            Close();
        }

        private void CboNomeAluno_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboNomeAluno.SelectedIndex <= -1) return;
            var list = CadastroAlunos.alunos.Where(x => string.Equals(x.NomeAluno, cboNomeAluno.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboNomeCurso.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboNomeCurso.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.Curso, StringComparison.CurrentCultureIgnoreCase));
                if (!add) return;
                txtRA.Text = x.RA;
                cboNomeCurso.Items.Add(x.Curso);
            });
            Enabled(true, false, false, false);
            Clear(false, true, true, true, true);
        }

        private void CboNomeCurso_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboNomeCurso.SelectedIndex <= -1) return;
            var list = CadastroAlunos.alunos.Where(x => string.Equals(x.NomeAluno, cboNomeAluno.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                     && string.Equals(x.Curso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboPeriodo.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboPeriodo.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.Periodo, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboPeriodo.Items.Add(x.Periodo);
            });
            Enabled(true, true, false, false);
            Clear(false, false, true, true, true);
        }

        private void CboPeriodo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPeriodo.SelectedIndex <= -1) return;
            var list = CadastroAlunos.alunos.Where(x => string.Equals(x.NomeAluno, cboNomeAluno.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                     && string.Equals(x.Curso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                     && string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboModalidadeCurso.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboModalidadeCurso.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.ModalidadeCurso, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboModalidadeCurso.Items.Add(x.ModalidadeCurso);
            });
            Enabled(true, true, true, false);
            Clear(false, false, false, true, true);
        }

        private void CboModalidadeCurso_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboModalidadeCurso.SelectedIndex <= -1) return;
            var list = CadastroAlunos.alunos.Where(x => string.Equals(x.NomeAluno, cboNomeAluno.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                     && string.Equals(x.Curso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                     && string.Equals(x.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                                                     && string.Equals(x.ModalidadeCurso, cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            cboDisciplina.Items.Clear();
            list.ForEach(x =>
            {
                var add = cboDisciplina.Items.Cast<object>().All(item => !string.Equals(item.ToString(), x.Disciplina, StringComparison.CurrentCultureIgnoreCase));
                if (add)
                    cboDisciplina.Items.Add(x.Disciplina);
            });
            Enabled(true, true, true, true);
            Clear(false, false, false, false, true);
        }

        private async void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            if (await Validate() == false) return;
            var quest = await ShowMessage("Deseja prosseguir com a exclusão!", true);
            if (quest == MessageDialogResult.Negative) return;

            var index = 0;
            foreach (var alunos in CadastroAlunos.alunos)
            {
                if (string.Equals(alunos.Curso, cboNomeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                    && string.Equals(alunos.Periodo, cboPeriodo.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                    && string.Equals(alunos.ModalidadeCurso, cboModalidadeCurso.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                    && string.Equals(alunos.Disciplina, cboDisciplina.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase)
                    && string.Equals(alunos.NomeAluno, cboNomeAluno.SelectedItem.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    break;
                index++;
            }

            CadastroAlunos.alunos.RemoveAt(index);
            notification.notifier.ShowError("Excluido!");
            LoadCombo();
            Enabled(false, false, false, false);
            Clear(true, true, true, true, true);
        }

        private async Task<bool> Validate()
        {
            if (cboNomeAluno.SelectedIndex == -1
                || cboNomeCurso.SelectedIndex == -1
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
    }
}
