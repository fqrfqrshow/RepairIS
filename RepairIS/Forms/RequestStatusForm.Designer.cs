namespace RepairIS.Forms
{
    partial class RequestStatusForm
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
            this.lblRequestId = new System.Windows.Forms.Label();
            this.cmbRequestSelect = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(143, -2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "СТАТУС ЗАЯВКИ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestId
            // 
            this.lblRequestId.Location = new System.Drawing.Point(30, 60);
            this.lblRequestId.Name = "lblRequestId";
            this.lblRequestId.Size = new System.Drawing.Size(120, 50);
            this.lblRequestId.TabIndex = 1;
            this.lblRequestId.Text = "Выберите заявку:";
            // 
            // cmbRequestSelect
            // 
            this.cmbRequestSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequestSelect.Location = new System.Drawing.Point(160, 60);
            this.cmbRequestSelect.Name = "cmbRequestSelect";
            this.cmbRequestSelect.Size = new System.Drawing.Size(250, 24);
            this.cmbRequestSelect.TabIndex = 2;
            this.cmbRequestSelect.SelectedIndexChanged += new System.EventHandler(this.cmbRequestSelect_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(30, 110);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 30);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Текущий статус:";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.Color.LightYellow;
            this.txtStatus.Location = new System.Drawing.Point(160, 110);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(250, 22);
            this.txtStatus.TabIndex = 4;
            // 
            // lblHistory
            // 
            this.lblHistory.Location = new System.Drawing.Point(30, 160);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(150, 30);
            this.lblHistory.TabIndex = 5;
            this.lblHistory.Text = "История изменений:";
            // 
            // lstHistory
            // 
            this.lstHistory.ItemHeight = 16;
            this.lstHistory.Location = new System.Drawing.Point(30, 200);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(440, 148);
            this.lstHistory.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(200, 380);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Закрыть";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RequestStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(502, 433);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestId);
            this.Controls.Add(this.cmbRequestSelect);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.btnClose);
            this.Name = "RequestStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр статуса заявки";
            this.Load += new System.EventHandler(this.RequestStatusForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestId;
        private System.Windows.Forms.ComboBox cmbRequestSelect;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Button btnClose;
    }
}