namespace RepairIS.Forms
{
    partial class EstimateViewForm
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
            this.lblRequestInfo = new System.Windows.Forms.Label();
            this.lblWorkCost = new System.Windows.Forms.Label();
            this.lblWorkValue = new System.Windows.Forms.Label();
            this.lblPartsCost = new System.Windows.Forms.Label();
            this.lblPartsValue = new System.Windows.Forms.Label();
            this.lblLogisticsCost = new System.Windows.Forms.Label();
            this.lblLogisticsValue = new System.Windows.Forms.Label();
            this.lblExtraCost = new System.Windows.Forms.Label();
            this.lblExtraValue = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "СМЕТА НА РЕМОНТ";
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblRequestInfo
            this.lblRequestInfo.Location = new System.Drawing.Point(30, 50);
            this.lblRequestInfo.Size = new System.Drawing.Size(440, 30);
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Italic);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;

            // lblWorkCost
            this.lblWorkCost.Text = "Стоимость работ:";
            this.lblWorkCost.Location = new System.Drawing.Point(50, 100);
            this.lblWorkCost.Size = new System.Drawing.Size(150, 30);

            // lblWorkValue
            this.lblWorkValue.Location = new System.Drawing.Point(220, 100);
            this.lblWorkValue.Size = new System.Drawing.Size(150, 30);
            this.lblWorkValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

            // lblPartsCost
            this.lblPartsCost.Text = "Стоимость деталей:";
            this.lblPartsCost.Location = new System.Drawing.Point(50, 140);
            this.lblPartsCost.Size = new System.Drawing.Size(150, 30);

            // lblPartsValue
            this.lblPartsValue.Location = new System.Drawing.Point(220, 140);
            this.lblPartsValue.Size = new System.Drawing.Size(150, 30);
            this.lblPartsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

            // lblLogisticsCost
            this.lblLogisticsCost.Text = "Логистика:";
            this.lblLogisticsCost.Location = new System.Drawing.Point(50, 180);
            this.lblLogisticsCost.Size = new System.Drawing.Size(150, 30);

            // lblLogisticsValue
            this.lblLogisticsValue.Location = new System.Drawing.Point(220, 180);
            this.lblLogisticsValue.Size = new System.Drawing.Size(150, 30);
            this.lblLogisticsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

            // lblExtraCost
            this.lblExtraCost.Text = "Доп. расходы:";
            this.lblExtraCost.Location = new System.Drawing.Point(50, 220);
            this.lblExtraCost.Size = new System.Drawing.Size(150, 30);

            // lblExtraValue
            this.lblExtraValue.Location = new System.Drawing.Point(220, 220);
            this.lblExtraValue.Size = new System.Drawing.Size(150, 30);
            this.lblExtraValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

            // lblTotal
            this.lblTotal.Text = "ИТОГО:";
            this.lblTotal.Location = new System.Drawing.Point(50, 270);
            this.lblTotal.Size = new System.Drawing.Size(150, 40);
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold);

            // lblTotalValue
            this.lblTotalValue.Location = new System.Drawing.Point(220, 270);
            this.lblTotalValue.Size = new System.Drawing.Size(200, 40);
            this.lblTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.Green;

            // btnConfirm
            this.btnConfirm.Text = "ПОДТВЕРДИТЬ СМЕТУ";
            this.btnConfirm.Location = new System.Drawing.Point(100, 340);
            this.btnConfirm.Size = new System.Drawing.Size(160, 40);
            this.btnConfirm.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // btnReject
            this.btnReject.Text = "ОТКЛОНИТЬ СМЕТУ";
            this.btnReject.Location = new System.Drawing.Point(280, 340);
            this.btnReject.Size = new System.Drawing.Size(160, 40);
            this.btnReject.BackColor = System.Drawing.Color.LightCoral;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);

            // EstimateViewForm
            this.Text = "Просмотр сметы";
            this.Size = new System.Drawing.Size(520, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblWorkCost);
            this.Controls.Add(this.lblWorkValue);
            this.Controls.Add(this.lblPartsCost);
            this.Controls.Add(this.lblPartsValue);
            this.Controls.Add(this.lblLogisticsCost);
            this.Controls.Add(this.lblLogisticsValue);
            this.Controls.Add(this.lblExtraCost);
            this.Controls.Add(this.lblExtraValue);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnReject);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblWorkCost;
        private System.Windows.Forms.Label lblWorkValue;
        private System.Windows.Forms.Label lblPartsCost;
        private System.Windows.Forms.Label lblPartsValue;
        private System.Windows.Forms.Label lblLogisticsCost;
        private System.Windows.Forms.Label lblLogisticsValue;
        private System.Windows.Forms.Label lblExtraCost;
        private System.Windows.Forms.Label lblExtraValue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnReject;
    }
}