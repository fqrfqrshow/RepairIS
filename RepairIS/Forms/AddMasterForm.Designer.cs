namespace RepairIS.Forms
{
    partial class AddMasterForm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "ДОБАВЛЕНИЕ МАСТЕРА";
            this.lblTitle.Location = new System.Drawing.Point(100, 10);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblName
            this.lblName.Text = "ФИО:";
            this.lblName.Location = new System.Drawing.Point(50, 70);
            this.lblName.Size = new System.Drawing.Size(100, 30);

            // txtName
            this.txtName.Location = new System.Drawing.Point(160, 70);
            this.txtName.Size = new System.Drawing.Size(280, 30);

            // lblEmail
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(50, 120);
            this.lblEmail.Size = new System.Drawing.Size(100, 30);

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(160, 120);
            this.txtEmail.Size = new System.Drawing.Size(280, 30);

            // lblPhone
            this.lblPhone.Text = "Телефон:";
            this.lblPhone.Location = new System.Drawing.Point(50, 170);
            this.lblPhone.Size = new System.Drawing.Size(100, 30);

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(160, 170);
            this.txtPhone.Size = new System.Drawing.Size(280, 30);

            // btnSave
            this.btnSave.Text = "СОХРАНИТЬ";
            this.btnSave.Location = new System.Drawing.Point(150, 230);
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // AddMasterForm
            this.Text = "Добавление мастера";
            this.Size = new System.Drawing.Size(500, 340);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnSave);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSave;
    }
}