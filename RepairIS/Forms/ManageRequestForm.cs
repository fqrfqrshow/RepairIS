using System;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class ManageRequestForm : Form
    {
        private int requestId;
        private RequestSystemFacade facade;

        public ManageRequestForm(int requestId, RequestSystemFacade facade)
        {
            this.requestId = requestId;
            this.facade = facade;
            InitializeComponent();
            LoadRequestData();
        }

        private void LoadRequestData()
        {
            var request = facade.GetRequest(requestId);
            if (request != null)
            {
                lblRequestInfo.Text = $"Заявка №{requestId}";
                lblMachine.Text = $"Станок ID: {request.MachineId}";
                lblClient.Text = $"Клиент ID: {request.ClientId} | Телефон: {request.ContactPhone}";
                txtDescription.Text = request.Description;
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem != null)
            {
                facade.ChangeStatus(requestId, cmbStatus.SelectedItem.ToString());
                MessageBox.Show($"Статус изменён на: {cmbStatus.SelectedItem}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            facade.ChangeStatus(requestId, "Оплачено");
            MessageBox.Show("Оплата отмечена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewMachine_Click(object sender, EventArgs e)
        {
            var request = facade.GetRequest(requestId);
            if (request != null)
            {
                new MachineCardForm(request.MachineId, facade).ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}