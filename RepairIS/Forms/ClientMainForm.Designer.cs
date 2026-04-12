namespace RepairIS.Forms
{
    partial class ClientMainForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.btnCreateRequest = new System.Windows.Forms.Button();
            this.btnMyRequests = new System.Windows.Forms.Button();
            this.btnCheckStatus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(34, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(442, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "РЕМОНТНОЕ ПРЕДПРИЯТИЕ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.Blue;
            this.lblWelcome.Location = new System.Drawing.Point(50, 55);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(300, 40);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Добро пожаловать!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserId
            // 
            this.lblUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblUserId.ForeColor = System.Drawing.Color.Gray;
            this.lblUserId.Location = new System.Drawing.Point(350, 60);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(100, 25);
            this.lblUserId.TabIndex = 2;
            this.lblUserId.Text = "ID: ";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStats
            // 
            this.lblStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblStats.Location = new System.Drawing.Point(50, 95);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(400, 30);
            this.lblStats.TabIndex = 3;
            this.lblStats.Text = "📊 Загрузка статистики...";
            this.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateRequest
            // 
            this.btnCreateRequest.BackColor = System.Drawing.Color.LightGreen;
            this.btnCreateRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreateRequest.Location = new System.Drawing.Point(100, 140);
            this.btnCreateRequest.Name = "btnCreateRequest";
            this.btnCreateRequest.Size = new System.Drawing.Size(300, 45);
            this.btnCreateRequest.TabIndex = 4;
            this.btnCreateRequest.Text = "📝 СОЗДАТЬ ЗАЯВКУ";
            this.btnCreateRequest.UseVisualStyleBackColor = false;
            this.btnCreateRequest.Click += new System.EventHandler(this.btnCreateRequest_Click);
            // 
            // btnMyRequests
            // 
            this.btnMyRequests.BackColor = System.Drawing.Color.LightBlue;
            this.btnMyRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnMyRequests.Location = new System.Drawing.Point(100, 200);
            this.btnMyRequests.Name = "btnMyRequests";
            this.btnMyRequests.Size = new System.Drawing.Size(300, 45);
            this.btnMyRequests.TabIndex = 5;
            this.btnMyRequests.Text = "📋 МОИ ЗАЯВКИ";
            this.btnMyRequests.UseVisualStyleBackColor = false;
            this.btnMyRequests.Click += new System.EventHandler(this.btnMyRequests_Click);
            // 
            // btnCheckStatus
            // 
            this.btnCheckStatus.BackColor = System.Drawing.Color.LightYellow;
            this.btnCheckStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckStatus.Location = new System.Drawing.Point(100, 260);
            this.btnCheckStatus.Name = "btnCheckStatus";
            this.btnCheckStatus.Size = new System.Drawing.Size(300, 45);
            this.btnCheckStatus.TabIndex = 6;
            this.btnCheckStatus.Text = "🔍 СТАТУС ЗАЯВКИ";
            this.btnCheckStatus.UseVisualStyleBackColor = false;
            this.btnCheckStatus.Click += new System.EventHandler(this.btnCheckStatus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(100, 320);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 40);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "🔄 ОБНОВИТЬ";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnLogout.Location = new System.Drawing.Point(260, 320);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(140, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "🚪 ВЫЙТИ";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ClientMainForm
            // 
            this.ClientSize = new System.Drawing.Size(504, 391);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnCreateRequest);
            this.Controls.Add(this.btnMyRequests);
            this.Controls.Add(this.btnCheckStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ClientMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ремонтное предприятие - Личный кабинет клиента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientMainForm_FormClosing);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnCreateRequest;
        private System.Windows.Forms.Button btnMyRequests;
        private System.Windows.Forms.Button btnCheckStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
    }
}