using System;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class ProcessRequestForm : Form
    {
        private int requestId;
        private RequestSystemFacade facade;
        private Request currentRequest;

        public ProcessRequestForm(int requestId, RequestSystemFacade facade)
        {
            this.requestId = requestId;
            this.facade = facade;
            InitializeComponent();
            open();
        }

        // open(): void - как на диаграмме
        private void open()
        {
            showRequest();
        }

        // showRequest(): void - как на диаграмме
        private void showRequest()
        {
            currentRequest = facade.GetRequest(requestId);
            if (currentRequest != null)
            {
                lblRequestInfo.Text = $"Заявка №{requestId}";
                lblMachine.Text = $"Станок ID: {currentRequest.MachineId}";
                lblClient.Text = $"Клиент ID: {currentRequest.ClientId} | Телефон: {currentRequest.ContactPhone}";
                txtDescription.Text = currentRequest.Description;

                if (currentRequest.Status != "Ожидает обработки")
                {
                    btnAccept.Enabled = false;
                }
            }
        }

        // acceptRequest(): void - как на диаграмме
        private void acceptRequest()
        {
            facade.ChangeStatus(requestId, "Принята в работу");
            MessageBox.Show("Заявка принята в работу!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAccept.Enabled = false;
            showRequest();
        }

        // changeStatus(): void - как на диаграмме
        private void changeStatus()
        {
            if (cmbNewStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите новый статус!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = cmbNewStatus.SelectedItem.ToString();
            facade.ChangeStatus(requestId, newStatus);
            MessageBox.Show($"Статус изменён на: {newStatus}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            showRequest();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            acceptRequest();
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            changeStatus();
        }
    }
}