using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для просмотра назначенных заявок мастером.
    /// Соответствует прецедентам "Просмотреть назначенные заявки" и "Фиксация осмотра и статуса ремонта" из ТЗ.
    /// </summary>
    public partial class MasterRequestsForm : Form
    {
        private readonly int _masterId;
        private readonly RequestSystemFacade _facade;
        private List<Request> _myRequests;
        private Master _currentMaster;
        private Timer _refreshTimer;

        public MasterRequestsForm(int masterId, RequestSystemFacade facade)
        {
            _masterId = masterId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadMasterInfo();
            LoadRequests();
            SetupDataGridView();
            StartAutoRefresh();
        }

        private void LoadMasterInfo()
        {
            _currentMaster = _facade.GetMasterById(_masterId);
            string masterName = _currentMaster?.Name ?? $"Мастер {_masterId}";
            lblWelcome.Text = $"👋 Здравствуйте, {masterName}!";

            // Дополнительная информация
            var allRequests = _facade.GetAllRequests();
            int activeCount = allRequests.Count(r => r.MasterId == _masterId &&
                (r.Status == "Назначен мастер" || r.Status == "Станок принят" || r.Status == "В работе"));

            lblActiveCount.Text = activeCount > 0 ? $"📋 Активных заявок: {activeCount}" : "";
        }

        private void LoadRequests()
        {
            try
            {
                var allRequests = _facade.GetAllRequests();
                _myRequests = allRequests
                    .Where(r => r.MasterId == _masterId)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToList();

                UpdateStatistics();
                DisplayRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            if (_myRequests == null) return;

            int pendingCount = _myRequests.Count(r => r.Status == "Назначен мастер");
            int inProgressCount = _myRequests.Count(r => r.Status == "Станок принят" || r.Status == "В работе");
            int completedCount = _myRequests.Count(r => r.Status == "Завершено");

            lblStats.Text = $"📊 Всего: {_myRequests.Count} | В работе: {inProgressCount} | Завершено: {completedCount}";

            if (pendingCount > 0)
            {
                lblStats.Text += $" | ⚠️ Ожидают начала: {pendingCount}";
                lblStats.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                lblStats.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void SetupDataGridView()
        {
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.ReadOnly = true;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.RowHeadersVisible = false;

            // Цветовая индикация
            dgvRequests.CellFormatting += DgvRequests_CellFormatting;

            // Двойной клик для просмотра деталей
            dgvRequests.DoubleClick += DgvRequests_DoubleClick;
        }

        private void DgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRequests.Rows[e.RowIndex].DataBoundItem == null)
                return;

            string status = dgvRequests.Rows[e.RowIndex].Cells["Статус"]?.Value?.ToString();

            switch (status)
            {
                case "Назначен мастер":
                    dgvRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    break;
                case "Станок принят":
                case "В работе":
                    dgvRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                    break;
                case "Завершено":
                    dgvRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    break;
            }
        }

        private void DgvRequests_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
                ShowRequestDetails(requestId);
            }
        }

        private void DisplayRequests()
        {
            dgvRequests.DataSource = null;
            dgvRequests.DataSource = _myRequests.Select(r => new
            {
                Id = r.Id,
                Клиент = GetClientName(r.ClientId),
                Станок = GetMachineModel(r.MachineId),
                Статус = r.Status,
                Описание = r.Description.Length > 40 ? r.Description.Substring(0, 37) + "..." : r.Description,
                Дата = r.CreatedAt.ToString("dd.MM.yyyy")
            }).ToList();

            // Настройка ширины колонок
            if (dgvRequests.Columns.Count > 0)
            {
                dgvRequests.Columns["Id"].Width = 50;
                dgvRequests.Columns["Клиент"].Width = 80;
                dgvRequests.Columns["Станок"].Width = 100;
                dgvRequests.Columns["Статус"].Width = 100;
                dgvRequests.Columns["Описание"].Width = 150;
                dgvRequests.Columns["Дата"].Width = 80;
            }

            lblCount.Text = $"Найдено: {_myRequests.Count} заявок";
        }

        private string GetClientName(int clientId)
        {
            // TODO: получить имя клиента из User
            return $"Клиент #{clientId}";
        }

        private string GetMachineModel(int machineId)
        {
            var machine = _facade.GetMachine(machineId);
            return machine?.Model ?? $"Станок #{machineId}";
        }

        private void ShowRequestDetails(int requestId)
        {
            var request = _facade.GetRequest(requestId);
            if (request == null) return;

            var machine = _facade.GetMachine(request.MachineId);
            var inspection = _facade.GetInspection(requestId);
            var estimate = _facade.GetEstimate(requestId);

            string details = $"📋 Заявка №{requestId}\n\n" +
                $"🔧 Станок: {machine?.Model ?? "Неизвестен"}\n" +
                $"📊 Статус: {request.Status}\n" +
                $"📝 Описание: {request.Description}\n" +
                $"📅 Создана: {request.CreatedAt:dd.MM.yyyy HH:mm}\n\n";

            if (inspection != null)
            {
                details += $"🔍 Осмотр:\n" +
                    $"   • Описание: {inspection.Description}\n" +
                    $"   • Трудоёмкость: {inspection.LaborHours} ч\n" +
                    $"   • Стоимость: {inspection.EstimatedCost:N2} ₽\n\n";
            }

            if (estimate != null)
            {
                details += $"💰 Смета: {estimate.TotalCost:N2} ₽\n" +
                    $"   • Подтверждена: {(estimate.IsConfirmed ? "Да" : "Нет")}\n";
            }

            MessageBox.Show(details, $"Детали заявки №{requestId}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void StartAutoRefresh()
        {
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 30000; // 30 секунд
            _refreshTimer.Tick += (s, e) => LoadRequests();
            _refreshTimer.Start();
        }

        private void PerformInspection()
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                ShowWarning("Выберите заявку для осмотра!");
                return;
            }

            int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
            var request = _facade.GetRequest(requestId);

            if (request != null && request.Status != "Назначен мастер" && request.Status != "Станок принят")
            {
                ShowWarning($"Осмотр можно проводить только для заявок в статусе 'Назначен мастер' или 'Станок принят'.\nТекущий статус: {request.Status}");
                return;
            }

            using (var inspectionForm = new InspectionForm(requestId, _facade))
            {
                if (inspectionForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRequests();
                }
            }
        }

        private void UpdateRepairStatus()
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                ShowWarning("Выберите заявку для обновления статуса ремонта!");
                return;
            }

            int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
            var request = _facade.GetRequest(requestId);

            if (request != null && request.Status != "Станок принят" && request.Status != "В работе")
            {
                ShowWarning($"Обновление статуса ремонта доступно только для заявок в статусе 'Станок принят' или 'В работе'.\nТекущий статус: {request.Status}");
                return;
            }

            using (var repairStatusForm = new RepairStatusForm(requestId, _masterId, _facade))
            {
                if (repairStatusForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRequests();
                }
            }
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Обработчики событий

        private void btnInspect_Click(object sender, EventArgs e)
        {
            PerformInspection();
        }

        private void btnRepairStatus_Click(object sender, EventArgs e)
        {
            UpdateRepairStatus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _refreshTimer?.Stop();
                this.Close();
                new LoginForm().Show();
            }
        }

        private void MasterRequestsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
        }

        #endregion
    }
}