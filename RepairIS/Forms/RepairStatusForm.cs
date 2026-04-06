using System;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class RepairStatusForm : Form
    {
        private int requestId;
        private int masterId;
        private RequestSystemFacade facade;

        public RepairStatusForm(int requestId, int masterId, RequestSystemFacade facade)
        {
            this.requestId = requestId;
            this.masterId = masterId;
            this.facade = facade;
            InitializeComponent();
            openStatusForm();
        }

        // openStatusForm(): void - как на диаграмме
        private void openStatusForm()
        {
            UpdateStatusDisplay();
        }

        private void UpdateStatusDisplay()
        {
            var request = facade.GetRequest(requestId);
            if (request != null)
            {
                lblStatus.Text = $"Текущий статус: {request.Status}";
            }
        }

        // startRepair(): void - как на диаграмме
        private void startRepair()
        {
            facade.ChangeStatus(requestId, "В процессе");
            UpdateStatusDisplay();
            MessageBox.Show("Ремонт начат!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // finishRepair(): void - как на диаграмме
        private void finishRepair()
        {
            enterFinishData();
        }

        // enterFinishData(): void - как на диаграмме
        private void enterFinishData()
        {
            if (string.IsNullOrWhiteSpace(txtFinishComment.Text))
            {
                MessageBox.Show("Введите комментарий о выполненной работе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            facade.ChangeStatus(requestId, "Завершено");
            UpdateStatusDisplay();

            MessageBox.Show($"Ремонт завершён!\nДата: {dtpFinishDate.Value.ToShortDateString()}\nКомментарий: {txtFinishComment.Text}",
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnStartRepair_Click(object sender, EventArgs e)
        {
            startRepair();
        }

        private void btnFinishRepair_Click(object sender, EventArgs e)
        {
            finishRepair();
        }
    }
}