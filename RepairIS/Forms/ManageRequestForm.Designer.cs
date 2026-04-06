namespace RepairIS.Forms
{
    partial class ManageRequestForm
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
            this.lblMachine = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnMarkPaid = new System.Windows.Forms.Button();
            this.btnViewMachine = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "УПРАВЛЕНИЕ ЗАЯВКОЙ";
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Size = new System.Drawing.Size(250, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblRequestInfo
            this.lblRequestInfo.Location = new System.Drawing.Point(30, 50);
            this.lblRequestInfo.Size = new System.Drawing.Size(480, 30);
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;

            // lblMachine
            this.lblMachine.Location = new System.Drawing.Point(30, 90);
            this.lblMachine.Size = new System.Drawing.Size(480, 25);

            // lblClient
            this.lblClient.Location = new System.Drawing.Point(30, 120);
            this.lblClient.Size = new System.Drawing.Size(480, 25);

            // lblDesc
            this.lblDesc.Text = "Описание проблемы:";
            this.lblDesc.Location = new System.Drawing.Point(30, 160);
            this.lblDesc.Size = new System.Drawing.Size(150, 30);

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(190, 160);
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            this.txtDescription.Multiline = true;
            this.txtDescription.ReadOnly = true;

            // lblStatus
            this.lblStatus.Text = "Изменить статус:";
            this.lblStatus.Location = new System.Drawing.Point(30, 260);
            this.lblStatus.Size = new System.Drawing.Size(120, 30);

            // cmbStatus
            this.cmbStatus.Location = new System.Drawing.Point(160, 260);
            this.cmbStatus.Size = new System.Drawing.Size(180, 30);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new string[] { "Принята в работу", "Назначен мастер", "В процессе", "Завершено", "Оплачено", "Возвращён" });

            // btnChangeStatus
            this.btnChangeStatus.Text = "Сменить статус";
            this.btnChangeStatus.Location = new System.Drawing.Point(360, 258);
            this.btnChangeStatus.Size = new System.Drawing.Size(120, 35);
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);

            // btnMarkPaid
            this.btnMarkPaid.Text = "Отметить оплату";
            this.btnMarkPaid.Location = new System.Drawing.Point(100, 320);
            this.btnMarkPaid.Size = new System.Drawing.Size(150, 40);
            this.btnMarkPaid.BackColor = System.Drawing.Color.LightGreen;
            this.btnMarkPaid.Click += new System.EventHandler(this.btnMarkPaid_Click);

            // btnViewMachine
            this.btnViewMachine.Text = "Карточка станка";
            this.btnViewMachine.Location = new System.Drawing.Point(270, 320);
            this.btnViewMachine.Size = new System.Drawing.Size(150, 40);
            this.btnViewMachine.Click += new System.EventHandler(this.btnViewMachine_Click);

            // btnClose
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(440, 320);
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ManageRequestForm
            this.Text = "Управление заявкой";
            this.Size = new System.Drawing.Size(600, 430);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnMarkPaid);
            this.Controls.Add(this.btnViewMachine);
            this.Controls.Add(this.btnClose);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnMarkPaid;
        private System.Windows.Forms.Button btnViewMachine;
        private System.Windows.Forms.Button btnClose;
    }
}