namespace RepairIS.Forms
{
    partial class MyRequestsForm
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
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "МОИ ЗАЯВКИ";
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblFilter
            this.lblFilter.Text = "Фильтр по статусу:";
            this.lblFilter.Location = new System.Drawing.Point(30, 50);
            this.lblFilter.Size = new System.Drawing.Size(120, 30);

            // cmbStatusFilter
            this.cmbStatusFilter.Location = new System.Drawing.Point(160, 50);
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 30);
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.Items.AddRange(new string[] { "Все", "Ожидает обработки", "Принята в работу", "Назначен мастер", "В процессе", "Завершено", "Оплачено" });
            this.cmbStatusFilter.SelectedIndex = 0;

            // btnFilter
            this.btnFilter.Text = "Применить фильтр";
            this.btnFilter.Location = new System.Drawing.Point(330, 48);
            this.btnFilter.Size = new System.Drawing.Size(120, 30);
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // dgvRequests
            this.dgvRequests.Location = new System.Drawing.Point(30, 100);
            this.dgvRequests.Size = new System.Drawing.Size(540, 300);
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // btnViewDetails
            this.btnViewDetails.Text = "Просмотреть детали";
            this.btnViewDetails.Location = new System.Drawing.Point(200, 420);
            this.btnViewDetails.Size = new System.Drawing.Size(150, 40);
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);

            // MyRequestsForm
            this.Text = "Мои заявки";
            this.Size = new System.Drawing.Size(620, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.btnViewDetails);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnViewDetails;
    }
}