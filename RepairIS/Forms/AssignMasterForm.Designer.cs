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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCurrentMaster = new System.Windows.Forms.Label();
            this.lblMastersCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "НАЗНАЧЕНИЕ МАСТЕРА НА ЗАЯВКУ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblRequestInfo.Location = new System.Drawing.Point(20, 50);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(460, 45);
            this.lblRequestInfo.TabIndex = 1;
            this.lblRequestInfo.Text = "Загрузка информации о заявке...";
            // 
            // lblMaster
            // 
            this.lblMaster.Location = new System.Drawing.Point(20, 130);
            this.lblMaster.Name = "lblMaster";
            this.lblMaster.Size = new System.Drawing.Size(140, 29);
            this.lblMaster.TabIndex = 3;
            this.lblMaster.Text = "Выберите мастера:";
            this.lblMaster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMasters
            // 
            this.cmbMasters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMasters.Location = new System.Drawing.Point(160, 135);
            this.cmbMasters.Name = "cmbMasters";
            this.cmbMasters.Size = new System.Drawing.Size(250, 24);
            this.cmbMasters.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(80, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "НАЗНАЧИТЬ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(220, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "ОТМЕНА";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCurrentMaster
            // 
            this.lblCurrentMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblCurrentMaster.ForeColor = System.Drawing.Color.Orange;
            this.lblCurrentMaster.Location = new System.Drawing.Point(20, 95);
            this.lblCurrentMaster.Name = "lblCurrentMaster";
            this.lblCurrentMaster.Size = new System.Drawing.Size(460, 25);
            this.lblCurrentMaster.TabIndex = 2;
            this.lblCurrentMaster.Visible = false;
            // 
            // lblMastersCount
            // 
            this.lblMastersCount.ForeColor = System.Drawing.Color.Gray;
            this.lblMastersCount.Location = new System.Drawing.Point(420, 138);
            this.lblMastersCount.Name = "lblMastersCount";
            this.lblMastersCount.Size = new System.Drawing.Size(60, 20);
            this.lblMastersCount.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(340, 200);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 35);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "🔄";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // AssignMasterForm
            // 
            this.ClientSize = new System.Drawing.Size(504, 261);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblCurrentMaster);
            this.Controls.Add(this.lblMaster);
            this.Controls.Add(this.cmbMasters);
            this.Controls.Add(this.lblMastersCount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignMasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Назначение мастера";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblCurrentMaster;
        private System.Windows.Forms.Label lblMaster;
        private System.Windows.Forms.ComboBox cmbMasters;
        private System.Windows.Forms.Label lblMastersCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRefresh;
    }
}