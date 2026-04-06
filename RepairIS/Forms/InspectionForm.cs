using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using RepairIS.Models;
using RepairIS.Facades;

namespace RepairIS.Forms
{
    public partial class InspectionForm : Form
    {
        private int requestId;
        private RequestSystemFacade facade;

        public InspectionForm(int requestId, RequestSystemFacade facade)
        {
            this.requestId = requestId;
            this.facade = facade;
            InitializeComponent();
            open();
        }

        // open(): void - как на диаграмме
        private void open()
        {
            showRequestInfo();
        }

        // showRequestInfo(): void - как на диаграмме
        private void showRequestInfo()
        {
            var request = facade.GetRequest(requestId);
            if (request != null)
            {
                lblRequestInfo.Text = $"Заявка №{requestId} | Станок ID: {request.MachineId} | Клиент: {request.ClientId}\nСтатус: {request.Status}";
            }
            else
            {
                lblRequestInfo.Text = $"Заявка №{requestId} не найдена";
            }
        }

        // enterInspectionData(): void - как на диаграмме (данные вводятся в поля)
        private void enterInspectionData()
        {
            // Пользователь вводит данные в текстовые поля
        }

        // saveInspection(): void - как на диаграмме
        private void saveInspection()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание неисправности!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float laborHours;
            if (!float.TryParse(txtLaborHours.Text, out laborHours))
            {
                MessageBox.Show("Введите корректную трудоёмкость!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float estimatedCost;
            if (!float.TryParse(txtEstimatedCost.Text, out estimatedCost))
            {
                MessageBox.Show("Введите ориентировочную стоимость!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var inspection = new Inspection
            {
                RequestId = requestId,
                Description = txtDescription.Text,
                WorkRequired = txtWorkRequired.Text,
                PartsNeeded = txtPartsNeeded.Text,
                LaborHours = laborHours,
                EstimatedCost = estimatedCost,
                InspectionDate = DateTime.Now
            };

            facade.SaveInspection(requestId, inspection);

            MessageBox.Show("Данные осмотра сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveInspection();
        }
    }
}