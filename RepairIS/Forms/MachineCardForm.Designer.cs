namespace RepairIS.Forms
{
    partial class MachineCardForm
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
            this.lblModel = new System.Windows.Forms.Label();
            this.lblModelValue = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblSerialValue = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblManufacturerValue = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "КАРТОЧКА СТАНКА";
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Size = new System.Drawing.Size(250, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblModel
            this.lblModel.Text = "Модель:";
            this.lblModel.Location = new System.Drawing.Point(30, 60);
            this.lblModel.Size = new System.Drawing.Size(100, 30);

            // lblModelValue
            this.lblModelValue.Location = new System.Drawing.Point(140, 60);
            this.lblModelValue.Size = new System.Drawing.Size(300, 30);
            this.lblModelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold);

            // lblSerial
            this.lblSerial.Text = "Серийный номер:";
            this.lblSerial.Location = new System.Drawing.Point(30, 100);
            this.lblSerial.Size = new System.Drawing.Size(100, 30);

            // lblSerialValue
            this.lblSerialValue.Location = new System.Drawing.Point(140, 100);
            this.lblSerialValue.Size = new System.Drawing.Size(300, 30);

            // lblManufacturer
            this.lblManufacturer.Text = "Производитель:";
            this.lblManufacturer.Location = new System.Drawing.Point(30, 140);
            this.lblManufacturer.Size = new System.Drawing.Size(100, 30);

            // lblManufacturerValue
            this.lblManufacturerValue.Location = new System.Drawing.Point(140, 140);
            this.lblManufacturerValue.Size = new System.Drawing.Size(300, 30);

            // lblHistory
            this.lblHistory.Text = "История ремонтов:";
            this.lblHistory.Location = new System.Drawing.Point(30, 190);
            this.lblHistory.Size = new System.Drawing.Size(150, 30);

            // dgvHistory
            this.dgvHistory.Location = new System.Drawing.Point(30, 230);
            this.dgvHistory.Size = new System.Drawing.Size(540, 200);
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ReadOnly = true;

            // btnClose
            this.btnClose.Text = "Закрыть";
            this.btnClose.Location = new System.Drawing.Point(250, 460);
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // MachineCardForm
            this.Text = "Карточка станка";
            this.Size = new System.Drawing.Size(620, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblModelValue);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.lblSerialValue);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.lblManufacturerValue);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.btnClose);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblModelValue;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblSerialValue;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblManufacturerValue;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnClose;
    }
}