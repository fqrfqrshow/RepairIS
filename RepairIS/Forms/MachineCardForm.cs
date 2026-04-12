using System;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    /// <summary>
    /// Форма для просмотра карточки станка и истории ремонтов.
    /// Соответствует прецеденту "Просмотреть карточку станка" из ТЗ.
    /// </summary>
    public partial class MachineCardForm : Form
    {
        private readonly int _machineId;
        private readonly RequestSystemFacade _facade;
        private Machine _machine;

        public MachineCardForm(int machineId, RequestSystemFacade facade)
        {
            _machineId = machineId;
            _facade = facade ?? throw new ArgumentNullException(nameof(facade));
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                LoadMachineData();
                LoadRepairHistory();
                LoadStatistics();
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMachineData()
        {
            _machine = _facade.GetMachine(_machineId);

            if (_machine != null)
            {
                lblModelValue.Text = _machine.Model;
                lblSerialValue.Text = string.IsNullOrEmpty(_machine.SerialNumber) ? "не указан" : _machine.SerialNumber;
                lblManufacturerValue.Text = string.IsNullOrEmpty(_machine.Manufacturer) ? "не указан" : _machine.Manufacturer;
                lblOwnerValue.Text = $"Владелец ID: {_machine.OwnerId}";

                this.Text = $"Карточка станка - {_machine.Model}";
            }
            else
            {
                MessageBox.Show("Станок не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void LoadRepairHistory()
        {
            var allRequests = _facade.GetAllRequests();
            var machineRequests = allRequests
                .Where(r => r.MachineId == _machineId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            if (machineRequests.Count == 0)
            {
                lblHistoryInfo.Text = "📋 История ремонтов: нет записей";
                dgvHistory.Visible = false;
            }
            else
            {
                lblHistoryInfo.Text = $"📋 История ремонтов: {machineRequests.Count} записей";
                dgvHistory.Visible = true;

                dgvHistory.DataSource = machineRequests.Select(r => new
                {
                    Id = r.Id,
                    Статус = r.Status,
                    Описание = r.Description.Length > 50 ? r.Description.Substring(0, 47) + "..." : r.Description,
                    Мастер = GetMasterName(r.MasterId),
                    Дата = r.CreatedAt.ToString("dd.MM.yyyy HH:mm")
                }).ToList();
            }
        }

        private void LoadStatistics()
        {
            var allRequests = _facade.GetAllRequests();
            var machineRequests = allRequests.Where(r => r.MachineId == _machineId).ToList();

            int completedCount = machineRequests.Count(r => r.Status == "Завершено" || r.Status == "Оплачено");
            int inProgressCount = machineRequests.Count(r => r.Status == "В работе" || r.Status == "Назначен мастер");
            int pendingCount = machineRequests.Count(r => r.Status == "Ожидает обработки");

            lblStats.Text = $"📊 Статистика: Всего: {machineRequests.Count} | Завершено: {completedCount} | В работе: {inProgressCount}";

            if (pendingCount > 0)
            {
                lblStats.Text += $" | Ожидает: {pendingCount}";
                lblStats.ForeColor = System.Drawing.Color.Orange;
            }
        }

        private void SetupDataGridView()
        {
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.ReadOnly = true;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.RowHeadersVisible = false;

            // Цветовая индикация статусов
            dgvHistory.CellFormatting += DgvHistory_CellFormatting;

            // Двойной клик для просмотра заявки
            dgvHistory.DoubleClick += DgvHistory_DoubleClick;
        }

        private void DgvHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHistory.Rows[e.RowIndex].DataBoundItem == null)
                return;

            if (dgvHistory.Columns[e.ColumnIndex].Name == "Статус")
            {
                string status = e.Value?.ToString();
                switch (status)
                {
                    case "Завершено":
                    case "Оплачено":
                        dgvHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "В работе":
                    case "Назначен мастер":
                        dgvHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        break;
                    case "Ожидает обработки":
                        dgvHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        break;
                    case "Отклонена":
                        dgvHistory.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;
                        break;
                }
            }
        }

        private void DgvHistory_DoubleClick(object sender, EventArgs e)
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvHistory.SelectedRows[0].Cells["Id"].Value;
                // Открыть форму просмотра заявки
                using (var requestForm = new ManageRequestForm(requestId, _facade))
                {
                    requestForm.ShowDialog();
                }
            }
        }

        private string GetMasterName(int masterId)
        {
            if (masterId == 0) return "Не назначен";
            var master = _facade.GetMasterById(masterId);
            return master?.Name ?? $"Мастер #{masterId}";
        }

        private void ShowRequestDetails()
        {
            if (dgvHistory.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvHistory.SelectedRows[0].Cells["Id"].Value;
                var request = _facade.GetRequest(requestId);

                if (request != null)
                {
                    string details = $"📋 Заявка №{request.Id}\n" +
                        $"📅 Дата: {request.CreatedAt:dd.MM.yyyy HH:mm}\n" +
                        $"📊 Статус: {request.Status}\n" +
                        $"📝 Описание: {request.Description}\n" +
                        $"👤 Клиент ID: {request.ClientId}\n" +
                        $"🔧 Мастер: {GetMasterName(request.MasterId)}";

                    MessageBox.Show(details, $"Детали заявки №{requestId}",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку из списка!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Обработчики событий

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnViewRequest_Click(object sender, EventArgs e)
        {
            ShowRequestDetails();
        }

        #endregion
    }
}