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
            this.lblClient = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.cmbNewStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "ОБРАБОТКА ЗАЯВКИ";
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

            // btnAccept
            this.btnAccept.Text = "ПРИНЯТЬ В РАБОТУ";
            this.btnAccept.Location = new System.Drawing.Point(100, 270);
            this.btnAccept.Size = new System.Drawing.Size(200, 40);
            this.btnAccept.BackColor = System.Drawing.Color.LightGreen;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);

            // cmbNewStatus
            this.cmbNewStatus.Location = new System.Drawing.Point(100, 330);
            this.cmbNewStatus.Size = new System.Drawing.Size(200, 30);
            this.cmbNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewStatus.Items.AddRange(new string[] { "Принята в работу", "Назначен мастер", "В процессе", "Завершено", "Оплачено", "Возвращён" });

            // btnChangeStatus
            this.btnChangeStatus.Text = "СМЕНИТЬ СТАТУС";
            this.btnChangeStatus.Location = new System.Drawing.Point(320, 325);
            this.btnChangeStatus.Size = new System.Drawing.Size(150, 40);
            this.btnChangeStatus.BackColor = System.Drawing.Color.LightYellow;
            this.btnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);

            // ProcessRequestForm
            this.Text = "Обработка заявки";
            this.Size = new System.Drawing.Size(550, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cmbNewStatus);
            this.Controls.Add(this.btnChangeStatus);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox cmbNewStatus;
        private System.Windows.Forms.Button btnChangeStatus;
    }
}