namespace RepairIS.Forms
{
    partial class AllRequestsForm
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
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblMasterFilter = new System.Windows.Forms.Label();
            this.cmbMasterFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnAssignMaster = new System.Windows.Forms.Button();
            this.btnCreateEstimate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "УПРАВЛЕНИЕ ЗАЯВКАМИ (МЕНЕДЖЕР)";
            this.lblTitle.Location = new System.Drawing.Point(100, 10);
            this.lblTitle.Size = new System.Drawing.Size(400, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblStatusFilter
            this.lblStatusFilter.Text = "Фильтр по статусу:";
            this.lblStatusFilter.Location = new System.Drawing.Point(30, 55);
            this.lblStatusFilter.Size = new System.Drawing.Size(120, 30);

            // cmbStatusFilter
            this.cmbStatusFilter.Location = new System.Drawing.Point(160, 55);
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 30);
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // lblMasterFilter
            this.lblMasterFilter.Text = "Фильтр по мастеру:";
            this.lblMasterFilter.Location = new System.Drawing.Point(330, 55);
            this.lblMasterFilter.Size = new System.Drawing.Size(120, 30);

            // cmbMasterFilter
            this.cmbMasterFilter.Location = new System.Drawing.Point(460, 55);
            this.cmbMasterFilter.Size = new System.Drawing.Size(150, 30);
            this.cmbMasterFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnFilter
            this.btnFilter.Text = "Применить фильтр";
            this.btnFilter.Location = new System.Drawing.Point(630, 53);
            this.btnFilter.Size = new System.Drawing.Size(120, 30);
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // btnRefresh
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Location = new System.Drawing.Point(760, 53);
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // dgvRequests
            this.dgvRequests.Location = new System.Drawing.Point(30, 100);
            this.dgvRequests.Size = new System.Drawing.Size(820, 350);
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // btnProcess
            this.btnProcess.Text = "Обработать заявку";
            this.btnProcess.Location = new System.Drawing.Point(30, 470);
            this.btnProcess.Size = new System.Drawing.Size(150, 40);
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);

            // btnAssignMaster
            this.btnAssignMaster.Text = "Назначить мастера";
            this.btnAssignMaster.Location = new System.Drawing.Point(200, 470);
            this.btnAssignMaster.Size = new System.Drawing.Size(150, 40);
            this.btnAssignMaster.Click += new System.EventHandler(this.btnAssignMaster_Click);

            // btnCreateEstimate
            this.btnCreateEstimate.Text = "Создать смету";
            this.btnCreateEstimate.Location = new System.Drawing.Point(370, 470);
            this.btnCreateEstimate.Size = new System.Drawing.Size(150, 40);
            this.btnCreateEstimate.Click += new System.EventHandler(this.btnCreateEstimate_Click);

            // AllRequestsForm
            this.Text = "Все заявки - Менеджер";
            this.Size = new System.Drawing.Size(900, 570);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatusFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblMasterFilter);
            this.Controls.Add(this.cmbMasterFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnAssignMaster);
            this.Controls.Add(this.btnCreateEstimate);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblMasterFilter;
        private System.Windows.Forms.ComboBox cmbMasterFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnAssignMaster;
        private System.Windows.Forms.Button btnCreateEstimate;
    }
}