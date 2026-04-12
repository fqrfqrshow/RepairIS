using RepairIS.Adapters;
using RepairIS.Facades;
using RepairIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для просмотра статуса заявки заказчиком.
    /// Соответствует прецеденту "Просмотр статуса заявки" из ТЗ.
    /// </summary>
    public partial class RequestStatusForm : Form
    {
        private readonly int _userId;
        private readonly RequestSystemFacade _facade;
        private List<Request> _userRequests;
        private Dictionary<int, List<StatusHistoryEntry>> _statusHistory;

        public RequestStatusForm(int userId, RequestSystemFacade facade, int? preselectedRequestId = null)
        {
            _userId = userId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadUserRequests();

            if (preselectedRequestId.HasValue && preselectedRequestId.Value > 0)
            {
                cmbRequestSelect.SelectedValue = preselectedRequestId.Value;
            }
        }

        private void LoadUserRequests()
        {
            try
            {
                var allRequests = _facade.GetAllRequests();
                _userRequests = allRequests
                    .Where(r => r.ClientId == _userId)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToList();

                if (_userRequests.Count == 0)
                {
                    cmbRequestSelect.Enabled = false;
                    txtStatus.Text = "У вас нет заявок";
                    txtStatus.BackColor = System.Drawing.Color.LightGray;
                    lstHistory.Items.Clear();
                    lstHistory.Items.Add("Нет заявок для отображения");
                    return;
                }

                cmbRequestSelect.DisplayMember = "Id";
                cmbRequestSelect.ValueMember = "Id";
                cmbRequestSelect.DataSource = _userRequests;
                cmbRequestSelect.SelectedIndex = 0; // Выбираем первую заявку
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatusHistory(int requestId)
        {
            try
            {
                _statusHistory = _facade.GetStatusHistory();

                lstHistory.Items.Clear();

                if (_statusHistory.ContainsKey(requestId) && _statusHistory[requestId].Count > 0)
                {
                    foreach (var entry in _statusHistory[requestId])
                    {
                        lstHistory.Items.Add($"• {entry.Timestamp:dd.MM.yyyy HH:mm}: {entry.OldStatus} → {entry.NewStatus}");
                    }
                }
                else
                {
                    lstHistory.Items.Add("Нет истории изменений статуса");
                }
            }
            catch (Exception ex)
            {
                lstHistory.Items.Clear();
                lstHistory.Items.Add($"Ошибка загрузки истории: {ex.Message}");
            }
        }

        private void LoadRequestDetails(int requestId)
        {
            var request = _userRequests.FirstOrDefault(r => r.Id == requestId);
            if (request != null)
            {
                // Отображаем статус с цветом
                txtStatus.Text = request.Status;

                // Цвет статуса
                switch (request.Status)
                {
                    case "Ожидает обработки":
                        txtStatus.BackColor = System.Drawing.Color.LightYellow;
                        break;
                    case "Принята в работу":
                    case "Назначен мастер":
                    case "Станок принят":
                    case "В работе":
                        txtStatus.BackColor = System.Drawing.Color.LightBlue;
                        break;
                    case "Завершено":
                    case "Оплачено":
                        txtStatus.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "Отклонена":
                        txtStatus.BackColor = System.Drawing.Color.LightPink;
                        break;
                    default:
                        txtStatus.BackColor = System.Drawing.Color.LightGray;
                        break;
                }

                // Обновляем заголовок с информацией о заявке
                var machine = _facade.GetMachine(request.MachineId);
                string machineName = machine?.Model ?? $"Станок #{request.MachineId}";
                this.Text = $"Просмотр статуса заявки №{requestId} - {machineName}";
            }
        }

        private void ShowEstimateInfo(int requestId)
        {
            var estimate = _facade.GetEstimate(requestId);
            if (estimate != null)
            {
                string estimateText = $"💰 Смета: {estimate.TotalCost:N2} ₽ | Подтверждена: {(estimate.IsConfirmed ? "Да" : "Нет")}";

                // Добавляем информацию о смете в историю или отдельный label
                // Если есть lblEstimateInfo в дизайне, можно его обновить
            }
        }

        private void ShowInspectionInfo(int requestId)
        {
            var inspection = _facade.GetInspection(requestId);
            if (inspection != null)
            {
                string inspectionText = $"🔍 Осмотр: {inspection.Description} | Трудоёмкость: {inspection.LaborHours} ч | Стоимость: {inspection.EstimatedCost:N2} ₽";
                // Если есть lblInspectionInfo в дизайне, можно его обновить
            }
        }

        private void cmbRequestSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRequestSelect.SelectedValue != null && int.TryParse(cmbRequestSelect.SelectedValue.ToString(), out int requestId))
            {
                LoadRequestDetails(requestId);
                LoadStatusHistory(requestId);
                ShowEstimateInfo(requestId);
                ShowInspectionInfo(requestId);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Обновляем список заявок
            LoadUserRequests();

            if (cmbRequestSelect.SelectedValue != null && int.TryParse(cmbRequestSelect.SelectedValue.ToString(), out int requestId))
            {
                LoadRequestDetails(requestId);
                LoadStatusHistory(requestId);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RequestStatusForm_Load(object sender, EventArgs e)
        {
            // Форма загружена
        }
    }
}