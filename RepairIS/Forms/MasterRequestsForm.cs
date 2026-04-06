using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class MasterRequestsForm : Form
    {
        private int masterId;
        private RequestSystemFacade facade;
        private List<Request> myRequests;

        public MasterRequestsForm(int masterId, RequestSystemFacade facade)
        {
            this.masterId = masterId;
            this.facade = facade;
            InitializeComponent();
            LoadRequests();

            var master = facade.GetMasters().FirstOrDefault(m => m.Id == masterId);
            lblWelcome.Text = master != null ? $"Здравствуйте, {master.Name}!" : $"Здравствуйте, мастер {masterId}!";
        }

        private void LoadRequests()
        {
            var allRequests = facade.GetAllRequests();
            myRequests = allRequests.Where(r => r.MasterId == masterId).ToList();

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = myRequests.Select(r => new
            {
                r.Id,
                r.MachineId,
                r.ClientId,
                r.Status,
                r.Description,
                r.CreatedAt
            }).ToList();
        }

        private void btnInspect_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
                new InspectionForm(requestId, facade).ShowDialog();
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Выберите заявку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRepairStatus_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
                new RepairStatusForm(requestId, masterId, facade).ShowDialog();
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Выберите заявку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRequests();
        }
    }
}