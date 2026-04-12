using RepairIS.Facades;
using RepairIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для первичной обработки заявки менеджером.
    /// Соответствует прецеденту "Обработать заявку" из ТЗ.
    /// </summary>
    public partial class ProcessRequestForm : Form
    {
        private readonly int _requestId;
        private readonly RequestSystemFacade _facade;
        private Request _currentRequest;
        private Machine _machine;

        public ProcessRequestForm(int requestId, RequestSystemFacade facade)
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
                UpdateUIState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRequestData()
        {
            _currentRequest = _facade.GetRequest(_requestId);

            if (_currentRequest != null)
            {
                lblRequestInfo.Text = $"📋 Заявка №{_requestId}";
                lblClient.Text = $"👤 Клиент ID: {_currentRequest.ClientId} | 📞 Телефон: {_currentRequest.ContactPhone}";
                lblStatus.Text = $"📊 Текущий статус: {_currentRequest.Status}";
                lblCreatedAt.Text = $"📅 Создана: {_currentRequest.CreatedAt:dd.MM.yyyy HH:mm}";
                txtDescription.Text = _currentRequest.Description;

                // Выбираем текущий статус в комбобоксе
                if (cmbNewStatus.Items.Contains(_currentRequest.Status))
                {
                    cmbNewStatus.SelectedItem = _currentRequest.Status;
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
            if (_currentRequest != null)
            {
                _machine = _facade.GetMachine(_currentRequest.MachineId);

                if (_machine != null)
                {
                    lblMachine.Text = $"🔧 Станок: {_machine.Model} (SN: {_machine.SerialNumber ?? "не указан"})";
                    lblMachineInfo.Text = $"🏭 Производитель: {_machine.Manufacturer ?? "не указан"}";
                }
                else
                {
                    lblMachine.Text = $"🔧 Станок ID: {_currentRequest.MachineId} (данные не найдены)";
                }
            }
        }

        private void SetupStatusComboBox()
        {
            cmbNewStatus.Items.Clear();
            cmbNewStatus.Items.AddRange(new string[] {
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

        private void UpdateUIState()
        {
            if (_currentRequest == null) return;

            // Кнопка "Принять в работу" доступна только для заявок со статусом "Ожидает обработки"
            btnAccept.Enabled = (_currentRequest.Status == "Ожидает обработки");

            // Кнопка "Сменить статус" доступна для всех, кроме завершенных и отклоненных
            bool canChangeStatus = _currentRequest.Status != "Оплачено" &&
                                   _currentRequest.Status != "Отклонена" &&
                                   _currentRequest.Status != "Завершено";
            btnChangeStatus.Enabled = canChangeStatus;
            cmbNewStatus.Enabled = canChangeStatus;

            if (!canChangeStatus)
            {
                lblStatusInfo.Text = "⚠️ Заявка завершена или отклонена. Изменение статуса невозможно.";
                lblStatusInfo.Visible = true;
            }
        }

        private void AcceptRequest()
        {
            if (_currentRequest.Status != "Ожидает обработки")
            {
                ShowWarning($"Невозможно принять заявку в работу. Текущий статус: {_currentRequest.Status}");
                return;
            }

            var result = MessageBox.Show(
                $"Принять заявку №{_requestId} в работу?\n\n" +
                $"Станок: {_machine?.Model ?? "Неизвестен"}\n" +
                $"Клиент: ID {_currentRequest.ClientId}\n\n" +
                $"После принятия статус изменится на 'Принята в работу'.",
                "Подтверждение принятия",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _facade.ChangeStatus(_requestId, "Принята в работу");

                    if (success)
                    {
                        MessageBox.Show($"✅ Заявка №{_requestId} принята в работу!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData(); // Перезагружаем данные
                    }
                    else
                    {
                        ShowError("Ошибка при принятии заявки!");
                    }
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }

        private void ChangeStatus()
        {
            if (cmbNewStatus.SelectedItem == null)
            {
                ShowWarning("Выберите новый статус!");
                return;
            }

            string newStatus = cmbNewStatus.SelectedItem.ToString();
            string oldStatus = _currentRequest.Status;

            if (newStatus == oldStatus)
            {
                ShowWarning("Новый статус совпадает с текущим!");
                return;
            }

            // Проверка на допустимость перехода
            if (!IsValidTransition(oldStatus, newStatus))
            {
                ShowWarning($"Недопустимый переход статуса: {oldStatus} → {newStatus}");
                return;
            }

            var result = MessageBox.Show(
                $"Изменить статус заявки №{_requestId}\n" +
                $"с \"{oldStatus}\" на \"{newStatus}\"?",
                "Подтверждение изменения статуса",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _facade.ChangeStatus(_requestId, newStatus);

                    if (success)
                    {
                        MessageBox.Show($"✅ Статус заявки №{_requestId} изменён на \"{newStatus}\"!",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData(); // Перезагружаем данные
                    }
                    else
                    {
                        ShowError("Ошибка при изменении статуса!");
                    }
                }
                catch (Exception ex)
                {
                    ShowError($"Ошибка: {ex.Message}");
                }
            }
        }

        private bool IsValidTransition(string oldStatus, string newStatus)
        {
            // Допустимые переходы статусов
            var validTransitions = new Dictionary<string, string[]>
            {
                { "Ожидает обработки", new[] { "Принята в работу", "Отклонена" } },
                { "Принята в работу", new[] { "Назначен мастер", "Отклонена" } },
                { "Назначен мастер", new[] { "Станок принят", "Отклонена" } },
                { "Станок принят", new[] { "В работе", "Отклонена" } },
                { "В работе", new[] { "Завершено", "Отклонена" } },
                { "Завершено", new[] { "Оплачено", "Возвращён" } }
            };

            if (!validTransitions.ContainsKey(oldStatus))
                return false;

            return validTransitions[oldStatus].Contains(newStatus);
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptRequest();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ChangeStatus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}