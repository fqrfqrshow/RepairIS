using System;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class EstimateViewForm : Form
    {
        private int requestId;
        private RequestSystemFacade facade;
        private Estimate estimate;

        public EstimateViewForm(int requestId, RequestSystemFacade facade)
        {
            this.requestId = requestId;
            this.facade = facade;
            InitializeComponent();
            LoadEstimate();
        }

        private void LoadEstimate()
        {
            var request = facade.GetRequest(requestId);
            if (request != null)
            {
                lblRequestInfo.Text = $"Заявка №{requestId} | Станок ID: {request.MachineId}";
            }

            estimate = facade.GetEstimate(requestId);
            if (estimate != null)
            {
                lblWorkValue.Text = $"{estimate.WorkCost:N2} ₽";
                lblPartsValue.Text = $"{estimate.PartsCost:N2} ₽";
                lblLogisticsValue.Text = $"{estimate.LogisticsCost:N2} ₽";
                lblExtraValue.Text = $"{estimate.ExtraCost:N2} ₽";
                lblTotalValue.Text = $"{estimate.TotalCost:N2} ₽";
            }
            else
            {
                MessageBox.Show("Смета отсутствует!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            facade.ConfirmEstimate(requestId);
            MessageBox.Show("Смета подтверждена! Заявка принята в работу.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            facade.RejectEstimate(requestId);
            MessageBox.Show("Смета отклонена. Заявка закрыта.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}