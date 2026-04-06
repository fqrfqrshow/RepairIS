using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using RepairIS.Models;
using RepairIS.Facades;

namespace RepairIS.Forms
{
    public partial class EstimateForm : Form
    {
        private int requestId;
        private RequestSystemFacade facade;

        public EstimateForm(int requestId, RequestSystemFacade facade)
        {
            this.requestId = requestId;
            this.facade = facade;
            InitializeComponent();
            open();
        }

        // open(): void - как на диаграмме
        private void open()
        {
            showInspectionData();
            fillEstimateFields();
        }

        // showInspectionData(): void - как на диаграмме
        private void showInspectionData()
        {
            var inspection = facade.GetInspection(requestId);
            if (inspection != null)
            {
                lblInspectionData.Text = $"Осмотр: {inspection.Description}\nТрудоёмкость: {inspection.LaborHours} ч | Ориентир. стоимость: {inspection.EstimatedCost:N2} ₽";
            }
            else
            {
                lblInspectionData.Text = "Данные осмотра отсутствуют. Сначала проведите осмотр.";
            }
        }

        // fillEstimateFields(): void - как на диаграмме
        private void fillEstimateFields()
        {
            var inspection = facade.GetInspection(requestId);
            if (inspection != null)
            {
                txtWorkCost.Text = inspection.EstimatedCost.ToString();
                txtPartsCost.Text = "0";
                txtLogisticsCost.Text = "0";
                txtExtraCost.Text = "0";
            }
        }

        private void updateTotal()
        {
            float work = GetFloat(txtWorkCost.Text);
            float parts = GetFloat(txtPartsCost.Text);
            float logistics = GetFloat(txtLogisticsCost.Text);
            float extra = GetFloat(txtExtraCost.Text);
            float total = work + parts + logistics + extra;
            lblTotal.Text = $"{total:N2} ₽";
        }

        private float GetFloat(string text)
        {
            float result;
            float.TryParse(text, out result);
            return result;
        }

        // save(): void - как на диаграмме
        private void save()
        {
            float workCost = GetFloat(txtWorkCost.Text);
            float partsCost = GetFloat(txtPartsCost.Text);
            float logisticsCost = GetFloat(txtLogisticsCost.Text);
            float extraCost = GetFloat(txtExtraCost.Text);

            var estimate = new Estimate
            {
                RequestId = requestId,
                WorkCost = workCost,
                PartsCost = partsCost,
                LogisticsCost = logisticsCost,
                ExtraCost = extraCost,
                IsConfirmed = false
            };

            facade.SaveEstimate(requestId, estimate);

            MessageBox.Show($"Смета сохранена! Итоговая сумма: {estimate.TotalCost:N2} ₽", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            updateTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}