using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class MyRequestsForm : Form
    {
        private int userId;
        private RequestSystemFacade facade;
        private List<Request> allRequests;

        public MyRequestsForm(int userId, RequestSystemFacade facade)
        {
            this.userId = userId;
            this.facade = facade;
            InitializeComponent();
            LoadRequests();
        }

        private void LoadRequests()
        {
            allRequests = facade.GetAllRequests();
            var userRequests = allRequests.Where(r => r.ClientId == userId).ToList();
            DisplayRequests(userRequests);
        }

        private void DisplayRequests(List<Request> requests)
        {
            dgvRequests.DataSource = null;
            dgvRequests.DataSource = requests.Select(r => new
            {
                r.Id,
                r.MachineId,
                r.Status,
                r.Description,
                r.CreatedAt
            }).ToList();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = cmbStatusFilter.SelectedItem.ToString();

            if (filter == "Все")
            {
                LoadRequests();
            }
            else
            {
                var userRequests = allRequests.Where(r => r.ClientId == userId && r.Status == filter).ToList();
                DisplayRequests(userRequests);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count > 0)
            {
                int requestId = (int)dgvRequests.SelectedRows[0].Cells["Id"].Value;
                new RequestStatusForm(userId, facade, requestId).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите заявку для просмотра!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}