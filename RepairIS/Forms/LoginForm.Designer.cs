namespace RepairIS.Forms
{
    partial class LoginForm
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
            this.lblRole = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "Вход в систему ремонтного предприятия";
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblRole
            this.lblRole.Text = "Роль:";
            this.lblRole.Location = new System.Drawing.Point(50, 70);
            this.lblRole.Size = new System.Drawing.Size(80, 30);

            // cmbRole
            this.cmbRole.Location = new System.Drawing.Point(140, 70);
            this.cmbRole.Size = new System.Drawing.Size(200, 30);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Items.AddRange(new string[] { "Заказчик", "Менеджер", "Мастер" });
            this.cmbRole.SelectedIndex = 0;

            // lblUserId
            this.lblUserId.Text = "ID пользователя:";
            this.lblUserId.Location = new System.Drawing.Point(50, 120);
            this.lblUserId.Size = new System.Drawing.Size(120, 30);

            // txtUserId
            this.txtUserId.Location = new System.Drawing.Point(180, 120);
            this.txtUserId.Size = new System.Drawing.Size(160, 30);
            this.txtUserId.Text = "1";

            // btnLogin
            this.btnLogin.Text = "Войти";
            this.btnLogin.Location = new System.Drawing.Point(140, 180);
            this.btnLogin.Size = new System.Drawing.Size(120, 40);
            this.btnLogin.BackColor = System.Drawing.Color.LightBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.Text = "Авторизация";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.btnLogin);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnLogin;
    }
}