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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnCreateRequest = new System.Windows.Forms.Button();
            this.btnMyRequests = new System.Windows.Forms.Button();
            this.btnCheckStatus = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.Location = new System.Drawing.Point(100, 30);
            this.lblWelcome.Size = new System.Drawing.Size(300, 40);
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold);
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnCreateRequest
            this.btnCreateRequest.Text = "Создать заявку";
            this.btnCreateRequest.Location = new System.Drawing.Point(150, 100);
            this.btnCreateRequest.Size = new System.Drawing.Size(200, 50);
            this.btnCreateRequest.BackColor = System.Drawing.Color.LightGreen;
            this.btnCreateRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRequest.Click += new System.EventHandler(this.btnCreateRequest_Click);

            // btnMyRequests
            this.btnMyRequests.Text = "Мои заявки";
            this.btnMyRequests.Location = new System.Drawing.Point(150, 170);
            this.btnMyRequests.Size = new System.Drawing.Size(200, 50);
            this.btnMyRequests.BackColor = System.Drawing.Color.LightBlue;
            this.btnMyRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyRequests.Click += new System.EventHandler(this.btnMyRequests_Click);

            // btnCheckStatus
            this.btnCheckStatus.Text = "Проверить статус заявки";
            this.btnCheckStatus.Location = new System.Drawing.Point(150, 240);
            this.btnCheckStatus.Size = new System.Drawing.Size(200, 50);
            this.btnCheckStatus.BackColor = System.Drawing.Color.LightYellow;
            this.btnCheckStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckStatus.Click += new System.EventHandler(this.btnCheckStatus_Click);

            // btnLogout
            this.btnLogout.Text = "Выйти";
            this.btnLogout.Location = new System.Drawing.Point(150, 310);
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.BackColor = System.Drawing.Color.LightGray;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // ClientMainForm
            this.Text = "Главное меню - Заказчик";
            this.Size = new System.Drawing.Size(500, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnCreateRequest);
            this.Controls.Add(this.btnMyRequests);
            this.Controls.Add(this.btnCheckStatus);
            this.Controls.Add(this.btnLogout);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnCreateRequest;
        private System.Windows.Forms.Button btnMyRequests;
        private System.Windows.Forms.Button btnCheckStatus;
        private System.Windows.Forms.Button btnLogout;
    }
}