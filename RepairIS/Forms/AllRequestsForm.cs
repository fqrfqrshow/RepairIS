using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для просмотра и управления всеми заявками (доступна менеджеру).
    /// Соответствует прецедентам "Просмотр всех заявок" и "Обработать заявку" из ТЗ.
    /// </summary>
    public partial class AllRequestsForm : Form
    {
        private readonly RequestSystemFacade _facade;
        private List<Request> _allRequests;
        private List<Master> _masters;
        private Timer _refreshTimer;

        public AllRequestsForm(RequestSystemFacade facade)
        {
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            InitializeAutoRefresh();
            LoadData();
            SetupFilters();
            SetupDataGridView();
        }

        private void InitializeAutoRefresh()
        {
            // Автообновление каждые 30 секунд
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 30000;
            _refreshTimer.Tick += (s, e) => RefreshData();
            _refreshTimer.Start();
        }

        private void SetupDataGridView()
        {
            // Настройка внешнего вида DataGridView
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.MultiSelect = false;
            dgvRequests.ReadOnly = true;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.RowHeadersVisible = false;

            // Цветовая индикация статусов
            dgvRequests.CellFormatting += DgvRequests_CellFormatting;
        }

        private void DgvRequests_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRequests.Rows[e.RowIndex].DataBoundItem == null)
                return;

            var status = dgvRequests.Rows[e.RowIndex].Cells["Status"]?.Value?.ToString();

            switch (status)
            {
                case "Ожидает обработки":
                    dgvRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                    break;
                case "В работе":
                case "В процессе":
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

        private void LoadData()
        {
            try
            {
                _allRequests = _facade.GetAllRequests();
                _masters = _facade.GetMasters();
                DisplayRequests(_allRequests);
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            if (_allRequests == null) return;

            int pendingCount = _allRequests.Count(r => r.Status == "Ожидает обработки");
            int inProgressCount = _allRequests.Count(r => r.Status == "В работе" || r.Status == "В процессе");
            int completedCount = _allRequests.Count(r => r.Status == "Завершено" || r.Status == "Оплачено");

            // Если есть label для статистики, обновляем
            lblStatistics.Text = $"📊 Всего: {_allRequests.Count} | Ожидают: {pendingCount} | В работе: {inProgressCount} | Завершено: {completedCount}";
        }

        private void SetupFilters()
        {
            // Статусы
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("Все");
            cmbStatusFilter.Items.AddRange(new string[] {
                "Ожидает обработки",
                "Принята в работу",
                "Назначен мастер",
                "Станок принят",
                "В работе",
                "В процессе",
                "Завершено",
                "Оплачено",
                "Отклонена"
            });
            cmbStatusFilter.SelectedIndex = 0;

            // Мастера
            RefreshMasterFilter();
        }

        private void RefreshMasterFilter()
        {
            cmbMasterFilter.Items.Clear();
            cmbMasterFilter.Items.Add("Все");
            foreach (var master in _masters)
            {
                cmbMasterFilter.Items.Add(master.Name);
            }
            cmbMasterFilter.SelectedIndex = 0;
        }

        private void DisplayRequests(List<Request> requests)
        {
            dgvRequests.DataSource = null;
            dgvRequests.DataSource = requests.Select(r => new
            {
                Id = r.Id,
                Клиент = GetClientName(r.ClientId),
                Станок = GetMachineModel(r.MachineId),
                Мастер = GetMasterName(r.MasterId),
                Статус = r.Status,
                Описание = r.Description.Length > 50 ? r.Description.Substring(0, 47) + "..." : r.Description,
                Дата = r.CreatedAt.ToString("dd.MM.yyyy HH:mm")
            }).ToList();

            // Настройка ширины колонок
            if (dgvRequests.Columns.Count > 0)
            {
                dgvRequests.Columns["Id"].Width = 50;
                dgvRequests.Columns["Клиент"].Width = 80;
                dgvRequests.Columns["Станок"].Width = 80;
                dgvRequests.Columns["Мастер"].Width = 100;
                dgvRequests.Columns["Статус"].Width = 120;
                dgvRequests.Columns["Описание"].Width = 200;
                dgvRequests.Columns["Дата"].Width = 120;
            }

            lblCount.Text = $"Найдено: {requests.Count} заявок";
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

        private string GetMasterName(int masterId)
        {
            if (masterId == 0) return "Не назначен";
            var master = _masters?.FirstOrDefault(m => m.Id == masterId);
            return master?.Name ?? $"Мастер #{masterId}";
        }

        private void ApplyFilters()
        {
            if (_allRequests == null) return;

            var filtered = _allRequests.AsEnumerable();

            string statusFilter = cmbStatusFilter.SelectedItem?.ToString();
            if (statusFilter != null && statusFilter != "Все")
            {
                filtered = filtered.Where(r => r.Status == statusFilter);
            }

            string masterFilter = cmbMasterFilter.SelectedItem?.ToString();
            if (masterFilter != null && masterFilter != "Все")
            {
                var master = _masters?.FirstOrDefault(m => m.Name == masterFilter);
                if (master != null)
                {
                    filtered = filtered.Where(r => r.MasterId == master.Id);
                }
            }

            // Поиск по тексту
            string searchText = txtSearch.Text?.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filtered = filtered.Where(r =>
                    r.Id.ToString().Contains(searchText) ||
                    r.Description?.ToLower().Contains(searchText) == true);
            }

            DisplayRequests(filtered.ToList());
        }

        private void RefreshData()
        {
            LoadData();
        }

        #region Обработчики событий

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                ShowWarning("Выберите заявку для обработки!");
                return;
            }

            int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
            using (var processForm = new ProcessRequestForm(requestId, _facade))
            {
                processForm.ShowDialog();
            }
            RefreshData();
        }

        private void btnAssignMaster_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                ShowWarning("Выберите заявку для назначения мастера!");
                return;
            }

            int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
            using (var assignForm = new AssignMasterForm(requestId, _facade))
            {
                assignForm.ShowDialog();
            }
            RefreshData();
        }

        private void btnCreateEstimate_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                ShowWarning("Выберите заявку для создания сметы!");
                return;
            }

            int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;

            // Проверяем, есть ли уже осмотр
            var inspection = _facade.GetInspection(requestId);
            if (inspection == null)
            {
                var result = MessageBox.Show("Для создания сметы необходимо провести осмотр. Провести осмотр сейчас?",
                    "Осмотр не проведен", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var inspectionForm = new InspectionForm(requestId, _facade))
                    {
                        inspectionForm.ShowDialog();
                    }
                }
                else
                {
                    return;
                }
            }

            using (var estimateForm = new EstimateForm(requestId, _facade))
            {
                estimateForm.ShowDialog();
            }
            RefreshData();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                ShowWarning("Выберите заявку для просмотра!");
                return;
            }

            int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
            using (var detailsForm = new ManageRequestForm(requestId, _facade))
            {
                detailsForm.ShowDialog();
            }
            RefreshData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbMasterFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvRequests_DoubleClick(object sender, EventArgs e)
        {
            btnViewDetails_Click(sender, e);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AllRequestsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
        }

        #endregion
    }
}