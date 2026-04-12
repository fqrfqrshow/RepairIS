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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAutoFill = new System.Windows.Forms.Button();
            this.lblExistingInfo = new System.Windows.Forms.Label();
            this.lblConfirmedWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(50, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "СМЕТА НА РЕМОНТ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInspectionData
            // 
            this.lblInspectionData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblInspectionData.ForeColor = System.Drawing.Color.Blue;
            this.lblInspectionData.Location = new System.Drawing.Point(20, 50);
            this.lblInspectionData.Name = "lblInspectionData";
            this.lblInspectionData.Size = new System.Drawing.Size(540, 70);
            this.lblInspectionData.TabIndex = 1;
            this.lblInspectionData.Text = "Загрузка данных осмотра...";
            // 
            // lblExistingInfo
            // 
            this.lblExistingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblExistingInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblExistingInfo.Location = new System.Drawing.Point(20, 125);
            this.lblExistingInfo.Name = "lblExistingInfo";
            this.lblExistingInfo.Size = new System.Drawing.Size(540, 20);
            this.lblExistingInfo.TabIndex = 2;
            this.lblExistingInfo.Text = "";
            this.lblExistingInfo.Visible = false;
            // 
            // lblConfirmedWarning
            // 
            this.lblConfirmedWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfirmedWarning.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmedWarning.Location = new System.Drawing.Point(20, 145);
            this.lblConfirmedWarning.Name = "lblConfirmedWarning";
            this.lblConfirmedWarning.Size = new System.Drawing.Size(540, 25);
            this.lblConfirmedWarning.TabIndex = 3;
            this.lblConfirmedWarning.Text = "";
            this.lblConfirmedWarning.Visible = false;
            this.lblConfirmedWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWork
            // 
            this.lblWork.Location = new System.Drawing.Point(30, 190);
            this.lblWork.Name = "lblWork";
            this.lblWork.Size = new System.Drawing.Size(150, 30);
            this.lblWork.TabIndex = 4;
            this.lblWork.Text = "💰 Стоимость работ:";
            this.lblWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkCost
            // 
            this.txtWorkCost.Location = new System.Drawing.Point(190, 193);
            this.txtWorkCost.Name = "txtWorkCost";
            this.txtWorkCost.Size = new System.Drawing.Size(150, 22);
            this.txtWorkCost.TabIndex = 5;
            this.txtWorkCost.Text = "0";
            // 
            // lblParts
            // 
            this.lblParts.Location = new System.Drawing.Point(30, 230);
            this.lblParts.Name = "lblParts";
            this.lblParts.Size = new System.Drawing.Size(150, 30);
            this.lblParts.TabIndex = 6;
            this.lblParts.Text = "🔩 Стоимость деталей:";
            this.lblParts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPartsCost
            // 
            this.txtPartsCost.Location = new System.Drawing.Point(190, 233);
            this.txtPartsCost.Name = "txtPartsCost";
            this.txtPartsCost.Size = new System.Drawing.Size(150, 22);
            this.txtPartsCost.TabIndex = 7;
            this.txtPartsCost.Text = "0";
            // 
            // lblLogistics
            // 
            this.lblLogistics.Location = new System.Drawing.Point(30, 270);
            this.lblLogistics.Name = "lblLogistics";
            this.lblLogistics.Size = new System.Drawing.Size(150, 30);
            this.lblLogistics.TabIndex = 8;
            this.lblLogistics.Text = "🚚 Логистика:";
            this.lblLogistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLogisticsCost
            // 
            this.txtLogisticsCost.Location = new System.Drawing.Point(190, 273);
            this.txtLogisticsCost.Name = "txtLogisticsCost";
            this.txtLogisticsCost.Size = new System.Drawing.Size(150, 22);
            this.txtLogisticsCost.TabIndex = 9;
            this.txtLogisticsCost.Text = "0";
            // 
            // lblExtra
            // 
            this.lblExtra.Location = new System.Drawing.Point(30, 310);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Size = new System.Drawing.Size(150, 30);
            this.lblExtra.TabIndex = 10;
            this.lblExtra.Text = "📦 Доп. расходы:";
            this.lblExtra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtExtraCost
            // 
            this.txtExtraCost.Location = new System.Drawing.Point(190, 313);
            this.txtExtraCost.Name = "txtExtraCost";
            this.txtExtraCost.Size = new System.Drawing.Size(150, 22);
            this.txtExtraCost.TabIndex = 11;
            this.txtExtraCost.Text = "0";
            // 
            // btnAutoFill
            // 
            this.btnAutoFill.BackColor = System.Drawing.Color.LightBlue;
            this.btnAutoFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoFill.Location = new System.Drawing.Point(360, 190);
            this.btnAutoFill.Name = "btnAutoFill";
            this.btnAutoFill.Size = new System.Drawing.Size(180, 30);
            this.btnAutoFill.TabIndex = 12;
            this.btnAutoFill.Text = "📋 Заполнить из осмотра";
            this.btnAutoFill.UseVisualStyleBackColor = false;
            this.btnAutoFill.Click += new System.EventHandler(this.btnAutoFill_Click);
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(30, 360);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(150, 40);
            this.lblTotalLabel.TabIndex = 13;
            this.lblTotalLabel.Text = "ИТОГО:";
            this.lblTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Location = new System.Drawing.Point(190, 360);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(350, 40);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "0 ₽";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(100, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "💾 СОХРАНИТЬ СМЕТУ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(320, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "❌ ОТМЕНА";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EstimateForm
            // 
            this.ClientSize = new System.Drawing.Size(584, 493);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInspectionData);
            this.Controls.Add(this.lblExistingInfo);
            this.Controls.Add(this.lblConfirmedWarning);
            this.Controls.Add(this.lblWork);
            this.Controls.Add(this.txtWorkCost);
            this.Controls.Add(this.lblParts);
            this.Controls.Add(this.txtPartsCost);
            this.Controls.Add(this.lblLogistics);
            this.Controls.Add(this.txtLogisticsCost);
            this.Controls.Add(this.lblExtra);
            this.Controls.Add(this.txtExtraCost);
            this.Controls.Add(this.btnAutoFill);
            this.Controls.Add(this.lblTotalLabel);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EstimateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Формирование сметы на ремонт";
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAutoFill;
        private System.Windows.Forms.Label lblExistingInfo;
        private System.Windows.Forms.Label lblConfirmedWarning;
    }
}