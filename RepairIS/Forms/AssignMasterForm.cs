using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для назначения мастера на заявку.
    /// Соответствует прецеденту "Обработать заявку" (назначение мастера) из ТЗ.
    /// </summary>
    public partial class AssignMasterForm : Form
    {
        private readonly int _requestId;
        private readonly RequestSystemFacade _facade;
        private List<Master> _masters;
        private Request _request;

        public AssignMasterForm(int requestId, RequestSystemFacade facade)
        {
            _requestId = requestId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                LoadRequestInfo();
                LoadMasterList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRequestInfo()
        {
            _request = _facade.GetRequest(_requestId);

            if (_request == null)
            {
                MessageBox.Show($"Заявка №{_requestId} не найдена!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string machineName = GetMachineName(_request.MachineId);
            string currentMaster = _request.MasterId > 0 ? GetCurrentMasterName(_request.MasterId) : "Не назначен";

            lblRequestInfo.Text = $"Заявка №{_requestId} | Станок: {machineName} | Статус: {_request.Status} | Текущий мастер: {currentMaster}";

            if (_request.MasterId > 0)
            {
                lblCurrentMaster.Visible = true;
                lblCurrentMaster.Text = $"⚠️ На заявку уже назначен мастер: {currentMaster}. Новое назначение перезапишет текущего.";
                lblCurrentMaster.ForeColor = System.Drawing.Color.Orange;
            }
        }

        private string GetMachineName(int machineId)
        {
            var machine = _facade.GetMachine(machineId);
            return machine?.Model ?? $"Станок #{machineId}";
        }

        private string GetCurrentMasterName(int masterId)
        {
            var master = _facade.GetMasterById(masterId);
            return master?.Name ?? $"Мастер #{masterId}";
        }

        private void LoadMasterList()
        {
            _masters = _facade.GetMasters();

            if (_masters == null || _masters.Count == 0)
            {
                MessageBox.Show("Нет доступных мастеров. Сначала добавьте мастера!",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                btnSave.Enabled = false;

                var result = MessageBox.Show("Добавить нового мастера сейчас?",
                    "Добавление мастера", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var addMasterForm = new AddMasterForm(_facade))
                    {
                        if (addMasterForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadMasterList();
                        }
                    }
                }
                return;
            }

            cmbMasters.DisplayMember = "Name";
            cmbMasters.ValueMember = "Id";
            cmbMasters.DataSource = _masters.ToList();

            if (_request != null && _request.MasterId > 0)
            {
                var currentMaster = _masters.FirstOrDefault(m => m.Id == _request.MasterId);
                if (currentMaster != null)
                {
                    cmbMasters.SelectedItem = currentMaster;
                }
            }

            lblMastersCount.Text = $"Доступно мастеров: {_masters.Count}";
        }

        private void SaveAssignment()
        {
            if (cmbMasters.SelectedItem == null)
            {
                ShowWarning("Выберите мастера из списка!");
                return;
            }

            var selectedMaster = (Master)cmbMasters.SelectedItem;

            if (selectedMaster.Id <= 0)
            {
                ShowWarning("Выбран некорректный мастер!");
                return;
            }

            if (!CanAssignMaster(_request.Status))
            {
                var result = MessageBox.Show(
                    $"Текущий статус заявки: {_request.Status}. Назначение мастера возможно только для заявок в статусе 'Ожидает обработки' или 'Принята в работу'.\n\nПродолжить?",
                    "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;
            }

            try
            {
                bool success = _facade.AssignMaster(_requestId, selectedMaster.Id);

                if (success)
                {
                    MessageBox.Show($"Мастер \"{selectedMaster.Name}\" успешно назначен на заявку №{_requestId}!\nСтатус заявки обновлен на 'Назначен мастер'.",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при назначении мастера!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CanAssignMaster(string status)
        {
            var allowedStatuses = new[] { "Ожидает обработки", "Принята в работу" };
            return allowedStatuses.Contains(status);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Обработчики событий

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAssignment();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMasterList();
        }

        #endregion
    }
}