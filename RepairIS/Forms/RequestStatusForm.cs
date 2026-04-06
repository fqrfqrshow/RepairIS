using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class RequestStatusForm : Form
    {
        private int userId;
        private RequestSystemFacade facade;
        private List<Request> userRequests;
        private Dictionary<int, List<string>> statusHistory;

        public RequestStatusForm(int userId, RequestSystemFacade facade, int? preselectedRequestId = null)
        {
            this.userId = userId;
            this.facade = facade;
            InitializeComponent();
            LoadUserRequests();

            if (preselectedRequestId.HasValue)
            {
                cmbRequestSelect.SelectedValue = preselectedRequestId.Value;
            }
        }

        private void LoadUserRequests()
        {
            var allRequests = facade.GetAllRequests();
            userRequests = allRequests.Where(r => r.ClientId == userId).ToList();

            cmbRequestSelect.DisplayMember = "Id";
            cmbRequestSelect.ValueMember = "Id";
            cmbRequestSelect.DataSource = userRequests;

            if (userRequests.Count == 0)
            {
                MessageBox.Show("У вас нет заявок!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadStatusHistory(int requestId)
        {
            statusHistory = facade.GetStatusHistory();
            if (statusHistory.ContainsKey(requestId))
            {
                lstHistory.Items.Clear();
                foreach (var status in statusHistory[requestId])
                {
                    lstHistory.Items.Add(status);
                }
            }
            else
            {
                lstHistory.Items.Clear();
                lstHistory.Items.Add("Нет истории изменений");
            }
        }

        private void cmbRequestSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRequestSelect.SelectedValue != null)
            {
                int requestId = (int)cmbRequestSelect.SelectedValue;
                var request = userRequests.FirstOrDefault(r => r.Id == requestId);
                if (request != null)
                {
                    txtStatus.Text = request.Status;
                    LoadStatusHistory(requestId);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}