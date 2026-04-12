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
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnViewDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "УПРАВЛЕНИЕ ЗАЯВКАМИ (МЕНЕДЖЕР)";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatusFilter
            // 
            this.lblStatusFilter.Location = new System.Drawing.Point(27, 45);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(120, 45);
            this.lblStatusFilter.TabIndex = 1;
            this.lblStatusFilter.Text = "Фильтр по статусу:";
            this.lblStatusFilter.Click += new System.EventHandler(this.lblStatusFilter_Click);
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Location = new System.Drawing.Point(134, 55);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(176, 24);
            this.cmbStatusFilter.TabIndex = 2;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);
            // 
            // lblMasterFilter
            // 
            this.lblMasterFilter.Location = new System.Drawing.Point(334, 47);
            this.lblMasterFilter.Name = "lblMasterFilter";
            this.lblMasterFilter.Size = new System.Drawing.Size(120, 32);
            this.lblMasterFilter.TabIndex = 3;
            this.lblMasterFilter.Text = "Фильтр по мастеру:";
            // 
            // cmbMasterFilter
            // 
            this.cmbMasterFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMasterFilter.Location = new System.Drawing.Point(460, 55);
            this.cmbMasterFilter.Name = "cmbMasterFilter";
            this.cmbMasterFilter.Size = new System.Drawing.Size(150, 24);
            this.cmbMasterFilter.TabIndex = 4;
            this.cmbMasterFilter.SelectedIndexChanged += new System.EventHandler(this.cmbMasterFilter_SelectedIndexChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(630, 53);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 30);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Применить";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dgvRequests
            // 
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.ColumnHeadersHeight = 29;
            this.dgvRequests.Location = new System.Drawing.Point(30, 125);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(820, 320);
            this.dgvRequests.TabIndex = 7;
            this.dgvRequests.DoubleClick += new System.EventHandler(this.dgvRequests_DoubleClick);
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.LightBlue;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Location = new System.Drawing.Point(30, 495);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(155, 48);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "📋 Обработать заявку";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnAssignMaster
            // 
            this.btnAssignMaster.BackColor = System.Drawing.Color.LightYellow;
            this.btnAssignMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignMaster.Location = new System.Drawing.Point(191, 493);
            this.btnAssignMaster.Name = "btnAssignMaster";
            this.btnAssignMaster.Size = new System.Drawing.Size(155, 53);
            this.btnAssignMaster.TabIndex = 9;
            this.btnAssignMaster.Text = "👤 Назначить мастера";
            this.btnAssignMaster.UseVisualStyleBackColor = false;
            this.btnAssignMaster.Click += new System.EventHandler(this.btnAssignMaster_Click);
            // 
            // btnCreateEstimate
            // 
            this.btnCreateEstimate.BackColor = System.Drawing.Color.LightGreen;
            this.btnCreateEstimate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateEstimate.Location = new System.Drawing.Point(360, 495);
            this.btnCreateEstimate.Name = "btnCreateEstimate";
            this.btnCreateEstimate.Size = new System.Drawing.Size(155, 48);
            this.btnCreateEstimate.TabIndex = 10;
            this.btnCreateEstimate.Text = "💰 Создать смету";
            this.btnCreateEstimate.UseVisualStyleBackColor = false;
            this.btnCreateEstimate.Click += new System.EventHandler(this.btnCreateEstimate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(740, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Location = new System.Drawing.Point(30, 90);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(60, 22);
            this.lblSearch.TabIndex = 13;
            this.lblSearch.Text = "Поиск:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(100, 90);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 22);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblStatistics
            // 
            this.lblStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatistics.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblStatistics.Location = new System.Drawing.Point(30, 460);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(400, 25);
            this.lblStatistics.TabIndex = 11;
            this.lblStatistics.Text = "📊 Статистика: загрузка...";
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(650, 460);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(200, 25);
            this.lblCount.TabIndex = 12;
            this.lblCount.Text = "Найдено: 0 заявок";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.LightGray;
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Location = new System.Drawing.Point(525, 495);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(155, 48);
            this.btnViewDetails.TabIndex = 15;
            this.btnViewDetails.Text = "🔍 Детали заявки";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // AllRequestsForm
            // 
            this.ClientSize = new System.Drawing.Size(882, 555);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatistics);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblStatusFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.lblMasterFilter);
            this.Controls.Add(this.cmbMasterFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnAssignMaster);
            this.Controls.Add(this.btnCreateEstimate);
            this.Controls.Add(this.btnViewDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AllRequestsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Все заявки - Менеджер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AllRequestsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnViewDetails;
    }
}