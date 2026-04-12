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
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblInspectionInfo = new System.Windows.Forms.Label();
            this.lblEstimateInfo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnMarkPaid = new System.Windows.Forms.Button();
            this.btnViewMachine = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(50, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "УПРАВЛЕНИЕ ЗАЯВКОЙ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblRequestInfo.Location = new System.Drawing.Point(20, 55);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(530, 30);
            this.lblRequestInfo.TabIndex = 1;
            this.lblRequestInfo.Text = "Заявка №";
            // 
            // lblMachine
            // 
            this.lblMachine.Location = new System.Drawing.Point(20, 95);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(530, 25);
            this.lblMachine.TabIndex = 2;
            this.lblMachine.Text = "Загрузка...";
            // 
            // lblClient
            // 
            this.lblClient.Location = new System.Drawing.Point(20, 120);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(300, 25);
            this.lblClient.TabIndex = 3;
            this.lblClient.Text = "Загрузка...";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Location = new System.Drawing.Point(330, 120);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(220, 25);
            this.lblCreatedAt.TabIndex = 4;
            this.lblCreatedAt.Text = "";
            this.lblCreatedAt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(20, 160);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(150, 30);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "📝 Описание проблемы:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(180, 160);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(370, 70);
            this.txtDescription.TabIndex = 6;
            // 
            // lblInspectionInfo
            // 
            this.lblInspectionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblInspectionInfo.ForeColor = System.Drawing.Color.Green;
            this.lblInspectionInfo.Location = new System.Drawing.Point(20, 240);
            this.lblInspectionInfo.Name = "lblInspectionInfo";
            this.lblInspectionInfo.Size = new System.Drawing.Size(530, 20);
            this.lblInspectionInfo.TabIndex = 7;
            this.lblInspectionInfo.Text = "";
            this.lblInspectionInfo.Visible = false;
            // 
            // lblEstimateInfo
            // 
            this.lblEstimateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblEstimateInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblEstimateInfo.Location = new System.Drawing.Point(20, 265);
            this.lblEstimateInfo.Name = "lblEstimateInfo";
            this.lblEstimateInfo.Size = new System.Drawing.Size(530, 20);
            this.lblEstimateInfo.TabIndex = 8;
            this.lblEstimateInfo.Text = "";
            this.lblEstimateInfo.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 305);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 30);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "📊 Изменить статус:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(150, 308);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(180, 24);
            this.cmbStatus.TabIndex = 10;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.BackColor = System.Drawing.Color.LightBlue;
            this.btnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStatus.Location = new System.Drawing.Point(350, 305);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(130, 30);
            this.btnChangeStatus.TabIndex = 11;
            this.btnChangeStatus.Text = "🔄 Сменить статус";
            this.btnChangeStatus.UseVisualStyleBackColor = false;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnMarkPaid
            // 
            this.btnMarkPaid.BackColor = System.Drawing.Color.LightGreen;
            this.btnMarkPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkPaid.Location = new System.Drawing.Point(20, 360);
            this.btnMarkPaid.Name = "btnMarkPaid";
            this.btnMarkPaid.Size = new System.Drawing.Size(140, 40);
            this.btnMarkPaid.TabIndex = 12;
            this.btnMarkPaid.Text = "💰 Отметить оплату";
            this.btnMarkPaid.UseVisualStyleBackColor = false;
            this.btnMarkPaid.Click += new System.EventHandler(this.btnMarkPaid_Click);
            // 
            // btnViewMachine
            // 
            this.btnViewMachine.Location = new System.Drawing.Point(180, 360);
            this.btnViewMachine.Name = "btnViewMachine";
            this.btnViewMachine.Size = new System.Drawing.Size(130, 40);
            this.btnViewMachine.TabIndex = 13;
            this.btnViewMachine.Text = "🔧 Карточка станка";
            this.btnViewMachine.Click += new System.EventHandler(this.btnViewMachine_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(330, 360);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(130, 40);
            this.btnHistory.TabIndex = 14;
            this.btnHistory.Text = "📜 История статусов";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightCoral;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(480, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "❌ Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ManageRequestForm
            // 
            this.ClientSize = new System.Drawing.Size(604, 423);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblCreatedAt);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblInspectionInfo);
            this.Controls.Add(this.lblEstimateInfo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnMarkPaid);
            this.Controls.Add(this.btnViewMachine);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление заявкой - Менеджер";
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblInspectionInfo;
        private System.Windows.Forms.Label lblEstimateInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnMarkPaid;
        private System.Windows.Forms.Button btnViewMachine;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnClose;
    }
}