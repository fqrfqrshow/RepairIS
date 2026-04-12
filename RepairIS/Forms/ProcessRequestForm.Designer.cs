namespace RepairIS.Forms
{
    partial class ProcessRequestForm
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
            this.lblMachineInfo = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.cmbNewStatus = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStatusInfo = new System.Windows.Forms.Label();
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
            this.lblTitle.Text = "ОБРАБОТКА ЗАЯВКИ";
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
            // lblMachineInfo
            // 
            this.lblMachineInfo.Location = new System.Drawing.Point(20, 120);
            this.lblMachineInfo.Name = "lblMachineInfo";
            this.lblMachineInfo.Size = new System.Drawing.Size(530, 25);
            this.lblMachineInfo.TabIndex = 3;
            this.lblMachineInfo.Text = "";
            // 
            // lblClient
            // 
            this.lblClient.Location = new System.Drawing.Point(20, 150);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(350, 25);
            this.lblClient.TabIndex = 4;
            this.lblClient.Text = "Загрузка...";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(20, 180);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(250, 25);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Загрузка...";
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.Location = new System.Drawing.Point(280, 180);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(270, 25);
            this.lblCreatedAt.TabIndex = 6;
            this.lblCreatedAt.Text = "";
            this.lblCreatedAt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(20, 220);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(150, 30);
            this.lblDesc.TabIndex = 7;
            this.lblDesc.Text = "📝 Описание проблемы:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(180, 220);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(370, 80);
            this.txtDescription.TabIndex = 8;
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblStatusInfo.ForeColor = System.Drawing.Color.Red;
            this.lblStatusInfo.Location = new System.Drawing.Point(20, 310);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(530, 25);
            this.lblStatusInfo.TabIndex = 9;
            this.lblStatusInfo.Text = "";
            this.lblStatusInfo.Visible = false;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.LightGreen;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAccept.Location = new System.Drawing.Point(20, 360);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(180, 45);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "✅ ПРИНЯТЬ В РАБОТУ";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cmbNewStatus
            // 
            this.cmbNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewStatus.Location = new System.Drawing.Point(220, 365);
            this.cmbNewStatus.Name = "cmbNewStatus";
            this.cmbNewStatus.Size = new System.Drawing.Size(180, 24);
            this.cmbNewStatus.TabIndex = 11;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.BackColor = System.Drawing.Color.LightYellow;
            this.btnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStatus.Location = new System.Drawing.Point(410, 360);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(140, 45);
            this.btnChangeStatus.TabIndex = 12;
            this.btnChangeStatus.Text = "🔄 СМЕНИТЬ СТАТУС";
            this.btnChangeStatus.UseVisualStyleBackColor = false;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightCoral;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(470, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "❌";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProcessRequestForm
            // 
            this.ClientSize = new System.Drawing.Size(574, 473);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.lblMachineInfo);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCreatedAt);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblStatusInfo);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cmbNewStatus);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обработка заявки - Менеджер";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label lblMachineInfo;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblStatusInfo;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnClose;
    }
}