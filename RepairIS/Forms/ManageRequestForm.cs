using System;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для управления заявкой менеджером.
    /// Соответствует прецедентам "Обработать заявку" и "Отметить оплату" из ТЗ.
    /// </summary>
    public partial class ManageRequestForm : Form
    {
        private readonly int _requestId;
        private readonly RequestSystemFacade _facade;
        private Request _request;
        private Machine _machine;

        public ManageRequestForm(int requestId, RequestSystemFacade facade)
        {
            _requestId = requestId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadData();
            SetupStatusComboBox();
        }

        private void LoadData()
        {
            try
            {
                LoadRequestData();
                LoadMachineData();
                LoadAdditionalInfo();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRequestData()
        {
            _request = _facade.GetRequest(_requestId);

            if (_request != null)
            {
                lblRequestInfo.Text = $"📋 Заявка №{_requestId}";
                lblClient.Text = $"👤 Клиент ID: {_request.ClientId} | 📞 Телефон: {_request.ContactPhone}";
                lblCreatedAt.Text = $"📅 Создана: {_request.CreatedAt:dd.MM.yyyy HH:mm}";
                txtDescription.Text = _request.Description;

                // Выбираем текущий статус в комбобоксе
                if (cmbStatus.Items.Contains(_request.Status))
                {
                    cmbStatus.SelectedItem = _request.Status;
                }
            }
            else
            {
                MessageBox.Show($"Заявка №{_requestId} не найдена!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadMachineData()
        {
            if (_request != null)
            {
                _machine = _facade.GetMachine(_request.MachineId);

                if (_machine != null)
                {
                    lblMachine.Text = $"🔧 Станок: {_machine.Model} (SN: {_machine.SerialNumber ?? "не указан"})";
                    btnViewMachine.Enabled = true;
                }
                else
                {
                    lblMachine.Text = $"🔧 Станок ID: {_request.MachineId} (данные не найдены)";
                    btnViewMachine.Enabled = false;
                }
            }
        }

        private void LoadAdditionalInfo()
        {
            // Проверяем наличие осмотра
            var inspection = _facade.GetInspection(_requestId);
            if (inspection != null)
            {
                lblInspectionInfo.Text = $"🔍 Осмотр проведён: {inspection.InspectionDate:dd.MM.yyyy} | " +
                    $"Стоимость: {inspection.EstimatedCost:N2} ₽ | Трудоёмкость: {inspection.LaborHours} ч";
                lblInspectionInfo.Visible = true;
            }

            // Проверяем наличие сметы
            var estimate = _facade.GetEstimate(_requestId);
            if (estimate != null)
            {
                lblEstimateInfo.Text = $"💰 Смета: {estimate.TotalCost:N2} ₽ | " +
                    $"Подтверждена: {(estimate.IsConfirmed ? "Да" : "Нет")}";
                lblEstimateInfo.Visible = true;
            }
        }

        private void SetupStatusComboBox()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] {
                "Принята в работу",
                "Назначен мастер",
                "Станок принят",
                "В работе",
                "Завершено",
                "Оплачено",
                "Возвращён",
                "Отклонена"
            });
        }

        private void UpdateButtonStates()
        {
            // Кнопка "Отметить оплату" доступна только для завершенных заявок
            btnMarkPaid.Enabled = (_request != null && _request.Status == "Завершено");

            // Кнопка изменения статуса
            btnChangeStatus.Enabled = (_request != null && _request.Status != "Оплачено" && _request.Status != "Отклонена");
        }

        private void ChangeStatus()
        {
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите новый статус!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = cmbStatus.SelectedItem.ToString();
            string oldStatus = _request.Status;

            if (newStatus == oldStatus)
            {
                MessageBox.Show("Новый статус совпадает с текущим!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Подтверждение изменения
            var result = MessageBox.Show($"Изменить статус заявки №{_requestId}\n" +
                $"с \"{oldStatus}\" на \"{newStatus}\"?",
                "Подтверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _facade.ChangeStatus(_requestId, newStatus);

                    if (success)
                    {
                        MessageBox.Show($"✅ Статус заявки №{_requestId} изменён на \"{newStatus}\"!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем данные
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при изменении статуса!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MarkAsPaid()
        {
            if (_request == null) return;

            var result = MessageBox.Show($"Отметить заявку №{_requestId} как оплаченную?\n\n" +
                "После этого изменить статус будет невозможно.",
                "Подтверждение оплаты", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _facade.ChangeStatus(_requestId, "Оплачено");

                    if (success)
                    {
                        MessageBox.Show("✅ Оплата отмечена! Заявка закрыта.",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при отметке оплаты!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowHistory()
        {
            var history = _facade.GetStatusHistoryForRequest(_requestId);

            if (history.Count == 0)
            {
                MessageBox.Show("История статусов отсутствует.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string historyText = $"История статусов заявки №{_requestId}:\n\n";
            foreach (var entry in history)
            {
                historyText += $"• {entry.Timestamp:dd.MM.yyyy HH:mm}: {entry.OldStatus} → {entry.NewStatus}\n";
            }

            MessageBox.Show(historyText, "История статусов",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Обработчики событий

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ChangeStatus();
        }

        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            MarkAsPaid();
        }

        private void btnViewMachine_Click(object sender, EventArgs e)
        {
            if (_request != null)
            {
                using (var machineForm = new MachineCardForm(_request.MachineId, _facade))
                {
                    machineForm.ShowDialog();
                }
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            ShowHistory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}