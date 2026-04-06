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

            // lblTitle
            this.lblTitle.Text = "СТАТУС ЗАЯВКИ";
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblRequestId
            this.lblRequestId.Text = "Выберите заявку:";
            this.lblRequestId.Location = new System.Drawing.Point(30, 60);
            this.lblRequestId.Size = new System.Drawing.Size(120, 30);

            // cmbRequestSelect
            this.cmbRequestSelect.Location = new System.Drawing.Point(160, 60);
            this.cmbRequestSelect.Size = new System.Drawing.Size(250, 30);
            this.cmbRequestSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequestSelect.SelectedIndexChanged += new System.EventHandler(this.cmbRequestSelect_SelectedIndexChanged);

            // lblStatus
            this.lblStatus.Text = "Текущий статус:";
            this.lblStatus.Location = new System.Drawing.Point(30, 110);
            this.lblStatus.Size = new System.Drawing.Size(120, 30);

            // txtStatus
            this.txtStatus.Location = new System.Drawing.Point(160, 110);
            this.txtStatus.Size = new System.Drawing.Size(250, 30);
            this.txtStatus.ReadOnly = true;
            this.txtStatus.BackColor = System.Drawing.Color.LightYellow;

            // lblHistory
            this.lblHistory.Text = "История изменений:";
            this.lblHistory.Location = new System.Drawing.Point(30, 160);
            this.lblHistory.Size = new System.Drawing.Size(150, 30);

            // lstHistory
            this.lstHistory.Location = new System.Drawing.Point(30, 200);
            this.lstHistory.Size = new System.Drawing.Size(440, 150);

            // btnClose
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(200, 380);
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // RequestStatusForm
            this.Text = "Просмотр статуса заявки";
            this.Size = new System.Drawing.Size(520, 480);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestId);
            this.Controls.Add(this.cmbRequestSelect);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.btnClose);
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