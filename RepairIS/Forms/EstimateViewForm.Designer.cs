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
            this.lblAlreadyConfirmed = new System.Windows.Forms.Label();
            this.lblEstimateDetails = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(50, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ПРОСМОТР СМЕТЫ НА РЕМОНТ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblRequestInfo.Location = new System.Drawing.Point(20, 50);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(480, 50);
            this.lblRequestInfo.TabIndex = 1;
            this.lblRequestInfo.Text = "Загрузка информации о заявке...";
            // 
            // lblWorkCost
            // 
            this.lblWorkCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblWorkCost.Location = new System.Drawing.Point(40, 190);
            this.lblWorkCost.Name = "lblWorkCost";
            this.lblWorkCost.Size = new System.Drawing.Size(180, 30);
            this.lblWorkCost.TabIndex = 4;
            this.lblWorkCost.Text = "💰 Стоимость работ:";
            this.lblWorkCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkValue
            // 
            this.lblWorkValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblWorkValue.Location = new System.Drawing.Point(240, 190);
            this.lblWorkValue.Name = "lblWorkValue";
            this.lblWorkValue.Size = new System.Drawing.Size(150, 30);
            this.lblWorkValue.TabIndex = 5;
            this.lblWorkValue.Text = "0 ₽";
            this.lblWorkValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPartsCost
            // 
            this.lblPartsCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPartsCost.Location = new System.Drawing.Point(40, 225);
            this.lblPartsCost.Name = "lblPartsCost";
            this.lblPartsCost.Size = new System.Drawing.Size(180, 40);
            this.lblPartsCost.TabIndex = 6;
            this.lblPartsCost.Text = "🔩 Стоимость деталей:";
            this.lblPartsCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPartsValue
            // 
            this.lblPartsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPartsValue.Location = new System.Drawing.Point(240, 225);
            this.lblPartsValue.Name = "lblPartsValue";
            this.lblPartsValue.Size = new System.Drawing.Size(150, 30);
            this.lblPartsValue.TabIndex = 7;
            this.lblPartsValue.Text = "0 ₽";
            this.lblPartsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogisticsCost
            // 
            this.lblLogisticsCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblLogisticsCost.Location = new System.Drawing.Point(40, 260);
            this.lblLogisticsCost.Name = "lblLogisticsCost";
            this.lblLogisticsCost.Size = new System.Drawing.Size(180, 30);
            this.lblLogisticsCost.TabIndex = 8;
            this.lblLogisticsCost.Text = "🚚 Логистика:";
            this.lblLogisticsCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogisticsValue
            // 
            this.lblLogisticsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblLogisticsValue.Location = new System.Drawing.Point(240, 260);
            this.lblLogisticsValue.Name = "lblLogisticsValue";
            this.lblLogisticsValue.Size = new System.Drawing.Size(150, 30);
            this.lblLogisticsValue.TabIndex = 9;
            this.lblLogisticsValue.Text = "0 ₽";
            this.lblLogisticsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExtraCost
            // 
            this.lblExtraCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblExtraCost.Location = new System.Drawing.Point(40, 295);
            this.lblExtraCost.Name = "lblExtraCost";
            this.lblExtraCost.Size = new System.Drawing.Size(180, 30);
            this.lblExtraCost.TabIndex = 10;
            this.lblExtraCost.Text = "📦 Доп. расходы:";
            this.lblExtraCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExtraValue
            // 
            this.lblExtraValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblExtraValue.Location = new System.Drawing.Point(240, 295);
            this.lblExtraValue.Name = "lblExtraValue";
            this.lblExtraValue.Size = new System.Drawing.Size(150, 30);
            this.lblExtraValue.TabIndex = 11;
            this.lblExtraValue.Text = "0 ₽";
            this.lblExtraValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(40, 340);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(150, 40);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "ИТОГО:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.Green;
            this.lblTotalValue.Location = new System.Drawing.Point(240, 340);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(250, 40);
            this.lblTotalValue.TabIndex = 13;
            this.lblTotalValue.Text = "0 ₽";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightGreen;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.Location = new System.Drawing.Point(60, 410);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(180, 45);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "✅ ПОДТВЕРДИТЬ";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.LightCoral;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnReject.Location = new System.Drawing.Point(260, 410);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(180, 45);
            this.btnReject.TabIndex = 15;
            this.btnReject.Text = "❌ ОТКЛОНИТЬ";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // lblAlreadyConfirmed
            // 
            this.lblAlreadyConfirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlreadyConfirmed.ForeColor = System.Drawing.Color.Green;
            this.lblAlreadyConfirmed.Location = new System.Drawing.Point(20, 145);
            this.lblAlreadyConfirmed.Name = "lblAlreadyConfirmed";
            this.lblAlreadyConfirmed.Size = new System.Drawing.Size(480, 25);
            this.lblAlreadyConfirmed.TabIndex = 3;
            this.lblAlreadyConfirmed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlreadyConfirmed.Visible = false;
            // 
            // lblEstimateDetails
            // 
            this.lblEstimateDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblEstimateDetails.ForeColor = System.Drawing.Color.Gray;
            this.lblEstimateDetails.Location = new System.Drawing.Point(20, 105);
            this.lblEstimateDetails.Name = "lblEstimateDetails";
            this.lblEstimateDetails.Size = new System.Drawing.Size(480, 40);
            this.lblEstimateDetails.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightGray;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(460, 410);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(50, 45);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "🖨️";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // EstimateViewForm
            // 
            this.ClientSize = new System.Drawing.Size(534, 483);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblEstimateDetails);
            this.Controls.Add(this.lblAlreadyConfirmed);
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
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EstimateViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр сметы - Ремонтное предприятие";
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
        private System.Windows.Forms.Label lblAlreadyConfirmed;
        private System.Windows.Forms.Label lblEstimateDetails;
        private System.Windows.Forms.Button btnPrint;
    }
}