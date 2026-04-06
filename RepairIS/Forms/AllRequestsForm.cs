using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class AllRequestsForm : Form
    {
        private RequestSystemFacade facade;
        private List<Request> allRequests;
        private List<Master> masters;

        public AllRequestsForm(RequestSystemFacade facade)
        {
            this.facade = facade;
            InitializeComponent();
            LoadData();
            SetupFilters();
        }

        private void LoadData()
        {
            allRequests = facade.GetAllRequests();
            masters = facade.GetMasters();
            DisplayRequests(allRequests);
        }

        private void SetupFilters()
        {
            // Статусы
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("Все");
            cmbStatusFilter.Items.AddRange(new string[] { "Ожидает обработки", "Принята в работу", "Назначен мастер", "В процессе", "Завершено", "Оплачено" });
            cmbStatusFilter.SelectedIndex = 0;

            // Мастера
            cmbMasterFilter.Items.Clear();
            cmbMasterFilter.Items.Add("Все");
            foreach (var master in masters)
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
                r.Id,
                r.MachineId,
                r.ClientId,
                MasterName = masters.FirstOrDefault(m => m.Id == r.MasterId)?.Name ?? "Не назначен",
                r.Status,
                r.Description,
                r.CreatedAt
            }).ToList();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var filtered = allRequests.AsEnumerable();

            string statusFilter = cmbStatusFilter.SelectedItem.ToString();
            if (statusFilter != "Все")
            {
                filtered = filtered.Where(r => r.Status == statusFilter);
            }

            string masterFilter = cmbMasterFilter.SelectedItem.ToString();
            if (masterFilter != "Все")
            {
                var master = masters.FirstOrDefault(m => m.Name == masterFilter);
                if (master != null)
                {
                    filtered = filtered.Where(r => r.MasterId == master.Id);
                }
            }

            DisplayRequests(filtered.ToList());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
                new ProcessRequestForm(requestId, facade).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Выберите заявку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAssignMaster_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
                new AssignMasterForm(requestId, facade).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Выберите заявку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCreateEstimate_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
                new EstimateForm(requestId, facade).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите заявку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}