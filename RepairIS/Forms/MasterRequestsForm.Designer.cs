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
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.btnInspect = new System.Windows.Forms.Button();
            this.btnRepairStatus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "МОИ ЗАЯВКИ (МАСТЕР)";
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblWelcome
            this.lblWelcome.Location = new System.Drawing.Point(30, 50);
            this.lblWelcome.Size = new System.Drawing.Size(540, 30);
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Italic);
            this.lblWelcome.ForeColor = System.Drawing.Color.Blue;

            // dgvRequests
            this.dgvRequests.Location = new System.Drawing.Point(30, 100);
            this.dgvRequests.Size = new System.Drawing.Size(540, 300);
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // btnInspect
            this.btnInspect.Text = "Провести осмотр";
            this.btnInspect.Location = new System.Drawing.Point(80, 430);
            this.btnInspect.Size = new System.Drawing.Size(150, 40);
            this.btnInspect.Click += new System.EventHandler(this.btnInspect_Click);

            // btnRepairStatus
            this.btnRepairStatus.Text = "Статус ремонта";
            this.btnRepairStatus.Location = new System.Drawing.Point(260, 430);
            this.btnRepairStatus.Size = new System.Drawing.Size(150, 40);
            this.btnRepairStatus.Click += new System.EventHandler(this.btnRepairStatus_Click);

            // btnRefresh
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Location = new System.Drawing.Point(440, 430);
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // MasterRequestsForm
            this.Text = "Заявки мастера";
            this.Size = new System.Drawing.Size(620, 540);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.btnInspect);
            this.Controls.Add(this.btnRepairStatus);
            this.Controls.Add(this.btnRefresh);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnInspect;
        private System.Windows.Forms.Button btnRepairStatus;
        private System.Windows.Forms.Button btnRefresh;
    }
}