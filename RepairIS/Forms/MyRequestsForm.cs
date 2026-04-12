using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для просмотра истории своих заявок заказчиком.
    /// Соответствует прецеденту "Просмотр истории своих заявок" из ТЗ.
    /// </summary>
    public partial class MyRequestsForm : Form
    {
        private readonly int _userId;
        private readonly RequestSystemFacade _facade;
        private List<Request> _allRequests;
        private Timer _refreshTimer;

        public MyRequestsForm(int userId, RequestSystemFacade facade)
        {
            _userId = userId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            SetupFilters();
            SetupDataGridView();
            LoadRequests();
            StartAutoRefresh();
        }

        private void SetupFilters()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("Все");
            cmbStatusFilter.Items.AddRange(new string[] {
                "Ожидает обработки",
                "Принята в работу",
                "Назначен мастер",
                "Станок принят",
                "В работе",
                "Завершено",
                "Оплачено",
                "Отклонена"
            });
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void SetupDataGridView()
        {
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.ReadOnly = true;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.RowHeadersVisible = false;

            // Цветовая индикация статусов
            dgvRequests.CellFormatting += DgvRequests_CellFormatting;

            // Двойной клик для просмотра деталей
            dgvRequests.DoubleClick += (s, e) => ViewDetails();
        }

        private void DgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRequests.Rows[e.RowIndex].DataBoundItem == null)
                return;

            string status = dgvRequests.Rows[e.RowIndex].Cells["Статус"]?.Value?.ToString();

            switch (status)
            {
                case "Ожидает обработки":
                    dgvRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    break;
                case "Принята в работу":
                case "Назначен мастер":
                case "Станок принят":
                case "В работе":
                    dgvRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                    break;
                case "Завершено":
                case "Оплачено":
                    dgvRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    break;
                case "Отклонена":
                    dgvRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                    break;
            }
        }

        private void StartAutoRefresh()
        {
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 30000; // 30 секунд
            _refreshTimer.Tick += (s, e) => LoadRequests();
            _refreshTimer.Start();
        }

        private void LoadRequests()
        {
            try
            {
                _allRequests = _facade.GetAllRequests();
                var userRequests = _allRequests
                    .Where(r => r.ClientId == _userId)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToList();

                UpdateStatistics(userRequests);
                DisplayRequests(userRequests);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заявок: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics(List<Request> requests)
        {
            if (requests == null) return;

            int totalCount = requests.Count;
            int pendingCount = requests.Count(r => r.Status == "Ожидает обработки");
            int inProgressCount = requests.Count(r => r.Status == "Принята в работу" ||
                r.Status == "Назначен мастер" || r.Status == "Станок принят" || r.Status == "В работе");
            int completedCount = requests.Count(r => r.Status == "Завершено" || r.Status == "Оплачено");
            int rejectedCount = requests.Count(r => r.Status == "Отклонена");

            lblStats.Text = $"📊 Всего: {totalCount} | В работе: {inProgressCount} | Завершено: {completedCount}";

            if (pendingCount > 0)
            {
                lblStats.Text += $" | ⚠️ Ожидают: {pendingCount}";
                lblStats.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                lblStats.ForeColor = System.Drawing.Color.Gray;
            }

            if (rejectedCount > 0)
            {
                lblRejectedInfo.Visible = true;
                lblRejectedInfo.Text = $"❌ Отклонено: {rejectedCount}";
            }
            else
            {
                lblRejectedInfo.Visible = false;
            }
        }

        private void DisplayRequests(List<Request> requests)
        {
            dgvRequests.DataSource = null;
            dgvRequests.DataSource = requests.Select(r => new
            {
                Id = r.Id,
                Станок = GetMachineModel(r.MachineId),
                Статус = r.Status,
                Описание = r.Description.Length > 40 ? r.Description.Substring(0, 37) + "..." : r.Description,
                Дата = r.CreatedAt.ToString("dd.MM.yyyy HH:mm")
            }).ToList();

            // Настройка ширины колонок
            if (dgvRequests.Columns.Count > 0)
            {
                dgvRequests.Columns["Id"].Width = 50;
                dgvRequests.Columns["Станок"].Width = 100;
                dgvRequests.Columns["Статус"].Width = 120;
                dgvRequests.Columns["Описание"].Width = 180;
                dgvRequests.Columns["Дата"].Width = 120;
            }

            lblCount.Text = $"Найдено: {requests.Count} заявок";
        }

        private string GetMachineModel(int machineId)
        {
            var machine = _facade.GetMachine(machineId);
            return machine?.Model ?? $"Станок #{machineId}";
        }

        private void ApplyFilter()
        {
            if (_allRequests == null) return;

            string selectedFilter = cmbStatusFilter.SelectedItem?.ToString();

            var userRequests = _allRequests.Where(r => r.ClientId == _userId);

            if (!string.IsNullOrEmpty(selectedFilter) && selectedFilter != "Все")
            {
                userRequests = userRequests.Where(r => r.Status == selectedFilter);
            }

            var filteredList = userRequests.OrderByDescending(r => r.CreatedAt).ToList();
            DisplayRequests(filteredList);
            UpdateStatistics(filteredList);
        }

        private void ViewDetails()
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                ShowWarning("Выберите заявку для просмотра!");
                return;
            }

            int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
            using (var statusForm = new RequestStatusForm(_userId, _facade, requestId))
            {
                statusForm.ShowDialog();
                LoadRequests(); // Обновляем после закрытия
            }
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Обработчики событий

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            cmbStatusFilter.SelectedIndex = 0;
            ApplyFilter();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            ViewDetails();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void MyRequestsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
        }

        #endregion
    }
}