namespace RepairIS.Forms
{
    partial class AssignMasterForm
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
            this.lblMaster = new System.Windows.Forms.Label();
            this.cmbMasters = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "НАЗНАЧЕНИЕ МАСТЕРА";
            this.lblTitle.Location = new System.Drawing.Point(100, 10);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblRequestInfo
            this.lblRequestInfo.Location = new System.Drawing.Point(30, 60);
            this.lblRequestInfo.Size = new System.Drawing.Size(440, 40);
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;

            // lblMaster
            this.lblMaster.Text = "Выберите мастера:";
            this.lblMaster.Location = new System.Drawing.Point(30, 120);
            this.lblMaster.Size = new System.Drawing.Size(120, 30);

            // cmbMasters
            this.cmbMasters.Location = new System.Drawing.Point(160, 120);
            this.cmbMasters.Size = new System.Drawing.Size(250, 30);
            this.cmbMasters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnSave
            this.btnSave.Text = "НАЗНАЧИТЬ";
            this.btnSave.Location = new System.Drawing.Point(150, 190);
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // AssignMasterForm
            this.Text = "Назначение мастера";
            this.Size = new System.Drawing.Size(500, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblMaster);
            this.Controls.Add(this.cmbMasters);
            this.Controls.Add(this.btnSave);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblMaster;
        private System.Windows.Forms.ComboBox cmbMasters;
        private System.Windows.Forms.Button btnSave;
    }
}