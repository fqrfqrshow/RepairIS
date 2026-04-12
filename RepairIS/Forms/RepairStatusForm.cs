using System;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для фиксации статуса ремонта мастером.
    /// Соответствует прецеденту "Фиксация осмотра и статуса ремонта" из ТЗ.
    /// </summary>
    public partial class RepairStatusForm : Form
    {
        private readonly int _requestId;
        private readonly int _masterId;
        private readonly RequestSystemFacade _facade;
        private Request _currentRequest;
        private Inspection _inspection;

        public RepairStatusForm(int requestId, int masterId, RequestSystemFacade facade)
        {
            _requestId = requestId;
            _masterId = masterId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadData();
            SetupDateTimePicker();
            UpdateUIState();
        }

        private void LoadData()
        {
            try
            {
                _currentRequest = _facade.GetRequest(_requestId);
                _inspection = _facade.GetInspection(_requestId);

                if (_currentRequest != null)
                {
                    LoadRequestInfo();
                }
                else
                {
                    MessageBox.Show($"Заявка №{_requestId} не найдена!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRequestInfo()
        {
            var machine = _facade.GetMachine(_currentRequest.MachineId);
            string machineName = machine?.Model ?? $"Станок #{_currentRequest.MachineId}";

            lblRequestInfo.Text = $"📋 Заявка №{_requestId} | 🔧 {machineName}";
            lblStatus.Text = $"📊 Текущий статус: {_currentRequest.Status}";

            // Показываем данные осмотра
            if (_inspection != null)
            {
                lblInspectionInfo.Visible = true;
                lblInspectionInfo.Text = $"🔍 Данные осмотра от {_inspection.InspectionDate:dd.MM.yyyy}:\n" +
                    $"   • Описание: {_inspection.Description}\n" +
                    $"   • Трудоёмкость: {_inspection.LaborHours} ч\n" +
                    $"   • Ориент. стоимость: {_inspection.EstimatedCost:N2} ₽";
            }
        }

        private void SetupDateTimePicker()
        {
            dtpFinishDate.Value = DateTime.Now;
            dtpFinishDate.MaxDate = DateTime.Now;
            dtpFinishDate.MinDate = _currentRequest?.CreatedAt ?? DateTime.Now.AddDays(-30);
        }

        private void UpdateUIState()
        {
            if (_currentRequest == null) return;

            bool canStartRepair = (_currentRequest.Status == "Станок принят" ||
                                   _currentRequest.Status == "Назначен мастер");
            bool canFinishRepair = (_currentRequest.Status == "В работе" ||
                                    _currentRequest.Status == "В процессе");

            btnStartRepair.Enabled = canStartRepair;
            btnFinishRepair.Enabled = canFinishRepair;

            // Если осмотр не проведен, блокируем кнопку начала ремонта
            if (canStartRepair && _inspection == null)
            {
                btnStartRepair.Enabled = false;
                lblNoInspectionWarning.Visible = true;
                lblNoInspectionWarning.Text = "⚠️ Для начала ремонта необходимо провести осмотр!";
            }
            else
            {
                lblNoInspectionWarning.Visible = false;
            }

            // Настройка видимости полей для завершения
            bool showFinishFields = canFinishRepair || _currentRequest.Status == "Завершено";
            lblComment.Visible = showFinishFields;
            txtFinishComment.Visible = showFinishFields;
            lblDate.Visible = showFinishFields;
            dtpFinishDate.Visible = showFinishFields;
        }

        private void StartRepair()
        {
            if (_currentRequest == null) return;

            if (_inspection == null)
            {
                MessageBox.Show("Невозможно начать ремонт без проведённого осмотра!\n\n" +
                    "Сначала проведите осмотр станка через форму 'Провести осмотр'.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Начать ремонт по заявке №{_requestId}?\n\n" +
                $"Станок: {(_facade.GetMachine(_currentRequest.MachineId)?.Model ?? "Неизвестен")}\n" +
                $"Данные осмотра: {_inspection.Description}\n" +
                $"Трудоёмкость: {_inspection.LaborHours} ч\n\n" +
                $"Статус изменится на 'В работе'.",
                "Подтверждение начала ремонта",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _facade.ChangeStatus(_requestId, "В работе");

                    if (success)
                    {
                        MessageBox.Show("✅ Ремонт начат!\n\n" +
                            "Не забудьте отметить завершение ремонта после выполнения работ.",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                        UpdateUIState();
                    }
                    else
                    {
                        ShowError("Ошибка при начале ремонта!");
                    }
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }

        private void FinishRepair()
        {
            if (_currentRequest == null) return;

            // Валидация комментария
            if (string.IsNullOrWhiteSpace(txtFinishComment.Text))
            {
                ShowWarning("Введите комментарий о выполненной работе!");
                txtFinishComment.Focus();
                return;
            }

            if (txtFinishComment.Text.Length < 10)
            {
                ShowWarning("Комментарий должен содержать не менее 10 символов!");
                txtFinishComment.Focus();
                return;
            }

            var result = MessageBox.Show(
                $"Завершить ремонт по заявке №{_requestId}?\n\n" +
                $"Дата завершения: {dtpFinishDate.Value:dd.MM.yyyy}\n" +
                $"Комментарий: {txtFinishComment.Text}\n\n" +
                $"Статус изменится на 'Завершено'.",
                "Подтверждение завершения ремонта",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _facade.ChangeStatus(_requestId, "Завершено");

                    if (success)
                    {
                        // Здесь можно сохранить комментарий о завершении в отдельный файл
                        SaveRepairCompletionData();

                        MessageBox.Show($"✅ Ремонт завершён!\n\n" +
                            $"📅 Дата: {dtpFinishDate.Value:dd.MM.yyyy}\n" +
                            $"📝 Комментарий: {txtFinishComment.Text}\n\n" +
                            $"Заявка передана на оплату.",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        ShowError("Ошибка при завершении ремонта!");
                    }
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }

        private void SaveRepairCompletionData()
        {
            // TODO: Сохранить данные о завершении ремонта в отдельный файл
            // Можно добавить модель RepairCompletion с полями:
            // RequestId, MasterId, CompletionDate, Comment
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Обработчики событий

        private void btnStartRepair_Click(object sender, EventArgs e)
        {
            StartRepair();
        }

        private void btnFinishRepair_Click(object sender, EventArgs e)
        {
            FinishRepair();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}