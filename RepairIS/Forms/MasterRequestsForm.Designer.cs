namespace RepairIS.Forms
{
    partial class MasterRequestsForm
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
            this.lblActiveCount = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.btnInspect = new System.Windows.Forms.Button();
            this.btnRepairStatus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
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
            this.lblTitle.Text = "МОИ ЗАЯВКИ (МАСТЕР)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblWelcome.ForeColor = System.Drawing.Color.Blue;
            this.lblWelcome.Location = new System.Drawing.Point(20, 55);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(400, 30);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Загрузка...";
            // 
            // lblActiveCount
            // 
            this.lblActiveCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblActiveCount.ForeColor = System.Drawing.Color.Green;
            this.lblActiveCount.Location = new System.Drawing.Point(430, 55);
            this.lblActiveCount.Name = "lblActiveCount";
            this.lblActiveCount.Size = new System.Drawing.Size(150, 30);
            this.lblActiveCount.TabIndex = 2;
            this.lblActiveCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStats
            // 
            this.lblStats.Location = new System.Drawing.Point(20, 90);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(450, 25);
            this.lblStats.TabIndex = 3;
            this.lblStats.Text = "Загрузка статистики...";
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(480, 90);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 25);
            this.lblCount.TabIndex = 4;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvRequests
            // 
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.ColumnHeadersHeight = 29;
            this.dgvRequests.Location = new System.Drawing.Point(20, 125);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(560, 280);
            this.dgvRequests.TabIndex = 5;
            // 
            // btnInspect
            // 
            this.btnInspect.BackColor = System.Drawing.Color.LightBlue;
            this.btnInspect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInspect.Location = new System.Drawing.Point(20, 430);
            this.btnInspect.Name = "btnInspect";
            this.btnInspect.Size = new System.Drawing.Size(160, 45);
            this.btnInspect.TabIndex = 6;
            this.btnInspect.Text = "🔍 Провести осмотр";
            this.btnInspect.UseVisualStyleBackColor = false;
            this.btnInspect.Click += new System.EventHandler(this.btnInspect_Click);
            // 
            // btnRepairStatus
            // 
            this.btnRepairStatus.BackColor = System.Drawing.Color.LightYellow;
            this.btnRepairStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairStatus.Location = new System.Drawing.Point(200, 430);
            this.btnRepairStatus.Name = "btnRepairStatus";
            this.btnRepairStatus.Size = new System.Drawing.Size(160, 45);
            this.btnRepairStatus.TabIndex = 7;
            this.btnRepairStatus.Text = "🛠 Статус ремонта";
            this.btnRepairStatus.UseVisualStyleBackColor = false;
            this.btnRepairStatus.Click += new System.EventHandler(this.btnRepairStatus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(380, 430);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 45);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "🔄";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(500, 430);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 45);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "🚪";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MasterRequestsForm
            // 
            this.ClientSize = new System.Drawing.Size(604, 503);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblActiveCount);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.btnInspect);
            this.Controls.Add(this.btnRepairStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasterRequestsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заявки мастера - Ремонтное предприятие";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterRequestsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblActiveCount;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnInspect;
        private System.Windows.Forms.Button btnRepairStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
    }
}