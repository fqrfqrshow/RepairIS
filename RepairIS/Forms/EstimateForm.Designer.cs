namespace RepairIS.Forms
{
    partial class EstimateForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInspectionData = new System.Windows.Forms.Label();
            this.lblWork = new System.Windows.Forms.Label();
            this.txtWorkCost = new System.Windows.Forms.TextBox();
            this.lblParts = new System.Windows.Forms.Label();
            this.txtPartsCost = new System.Windows.Forms.TextBox();
            this.lblLogistics = new System.Windows.Forms.Label();
            this.txtLogisticsCost = new System.Windows.Forms.TextBox();
            this.lblExtra = new System.Windows.Forms.Label();
            this.txtExtraCost = new System.Windows.Forms.TextBox();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "СМЕТА НА РЕМОНТ";
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Size = new System.Drawing.Size(250, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblInspectionData
            this.lblInspectionData.Location = new System.Drawing.Point(30, 50);
            this.lblInspectionData.Size = new System.Drawing.Size(480, 60);
            this.lblInspectionData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Italic);
            this.lblInspectionData.ForeColor = System.Drawing.Color.Blue;

            // lblWork
            this.lblWork.Text = "Стоимость работ:";
            this.lblWork.Location = new System.Drawing.Point(30, 130);
            this.lblWork.Size = new System.Drawing.Size(150, 30);

            // txtWorkCost
            this.txtWorkCost.Location = new System.Drawing.Point(190, 130);
            this.txtWorkCost.Size = new System.Drawing.Size(150, 30);
            this.txtWorkCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);

            // lblParts
            this.lblParts.Text = "Стоимость деталей:";
            this.lblParts.Location = new System.Drawing.Point(30, 180);
            this.lblParts.Size = new System.Drawing.Size(150, 30);

            // txtPartsCost
            this.txtPartsCost.Location = new System.Drawing.Point(190, 180);
            this.txtPartsCost.Size = new System.Drawing.Size(150, 30);
            this.txtPartsCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);

            // lblLogistics
            this.lblLogistics.Text = "Логистика:";
            this.lblLogistics.Location = new System.Drawing.Point(30, 230);
            this.lblLogistics.Size = new System.Drawing.Size(150, 30);

            // txtLogisticsCost
            this.txtLogisticsCost.Location = new System.Drawing.Point(190, 230);
            this.txtLogisticsCost.Size = new System.Drawing.Size(150, 30);
            this.txtLogisticsCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);

            // lblExtra
            this.lblExtra.Text = "Доп. расходы:";
            this.lblExtra.Location = new System.Drawing.Point(30, 280);
            this.lblExtra.Size = new System.Drawing.Size(150, 30);

            // txtExtraCost
            this.txtExtraCost.Location = new System.Drawing.Point(190, 280);
            this.txtExtraCost.Size = new System.Drawing.Size(150, 30);
            this.txtExtraCost.TextChanged += new System.EventHandler(this.txtCost_TextChanged);

            // lblTotalLabel
            this.lblTotalLabel.Text = "ИТОГО:";
            this.lblTotalLabel.Location = new System.Drawing.Point(30, 340);
            this.lblTotalLabel.Size = new System.Drawing.Size(150, 40);
            this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);

            // lblTotal
            this.lblTotal.Text = "0 ₽";
            this.lblTotal.Location = new System.Drawing.Point(190, 340);
            this.lblTotal.Size = new System.Drawing.Size(200, 40);
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Green;

            // btnSave
            this.btnSave.Text = "Сохранить смету";
            this.btnSave.Location = new System.Drawing.Point(150, 420);
            this.btnSave.Size = new System.Drawing.Size(250, 40);
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // EstimateForm
            this.Text = "Формирование сметы";
            this.Size = new System.Drawing.Size(550, 530);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInspectionData);
            this.Controls.Add(this.lblWork);
            this.Controls.Add(this.txtWorkCost);
            this.Controls.Add(this.lblParts);
            this.Controls.Add(this.txtPartsCost);
            this.Controls.Add(this.lblLogistics);
            this.Controls.Add(this.txtLogisticsCost);
            this.Controls.Add(this.lblExtra);
            this.Controls.Add(this.txtExtraCost);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnSave);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInspectionData;
        private System.Windows.Forms.Label lblWork;
        private System.Windows.Forms.TextBox txtWorkCost;
        private System.Windows.Forms.Label lblParts;
        private System.Windows.Forms.TextBox txtPartsCost;
        private System.Windows.Forms.Label lblLogistics;
        private System.Windows.Forms.TextBox txtLogisticsCost;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.TextBox txtExtraCost;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSave;
    }
}