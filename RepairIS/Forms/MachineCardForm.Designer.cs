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
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblOwnerValue = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.lblHistoryInfo = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnViewRequest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(50, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(550, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "КАРТОЧКА СТАНКА";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblModel
            // 
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblModel.Location = new System.Drawing.Point(20, 60);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(130, 30);
            this.lblModel.TabIndex = 1;
            this.lblModel.Text = "🔧 Модель:";
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblModelValue
            // 
            this.lblModelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblModelValue.ForeColor = System.Drawing.Color.Blue;
            this.lblModelValue.Location = new System.Drawing.Point(160, 60);
            this.lblModelValue.Name = "lblModelValue";
            this.lblModelValue.Size = new System.Drawing.Size(400, 30);
            this.lblModelValue.TabIndex = 2;
            this.lblModelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerial
            // 
            this.lblSerial.Location = new System.Drawing.Point(20, 95);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(130, 30);
            this.lblSerial.TabIndex = 3;
            this.lblSerial.Text = "🔢 Серийный номер:";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerialValue
            // 
            this.lblSerialValue.Location = new System.Drawing.Point(160, 95);
            this.lblSerialValue.Name = "lblSerialValue";
            this.lblSerialValue.Size = new System.Drawing.Size(400, 30);
            this.lblSerialValue.TabIndex = 4;
            this.lblSerialValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.Location = new System.Drawing.Point(20, 130);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(130, 30);
            this.lblManufacturer.TabIndex = 5;
            this.lblManufacturer.Text = "🏭 Производитель:";
            this.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManufacturerValue
            // 
            this.lblManufacturerValue.Location = new System.Drawing.Point(160, 130);
            this.lblManufacturerValue.Name = "lblManufacturerValue";
            this.lblManufacturerValue.Size = new System.Drawing.Size(400, 30);
            this.lblManufacturerValue.TabIndex = 6;
            this.lblManufacturerValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwner
            // 
            this.lblOwner.Location = new System.Drawing.Point(20, 165);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(130, 30);
            this.lblOwner.TabIndex = 7;
            this.lblOwner.Text = "👤 Владелец:";
            this.lblOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwnerValue
            // 
            this.lblOwnerValue.Location = new System.Drawing.Point(160, 165);
            this.lblOwnerValue.Name = "lblOwnerValue";
            this.lblOwnerValue.Size = new System.Drawing.Size(400, 30);
            this.lblOwnerValue.TabIndex = 8;
            this.lblOwnerValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStats
            // 
            this.lblStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblStats.ForeColor = System.Drawing.Color.Gray;
            this.lblStats.Location = new System.Drawing.Point(20, 200);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(540, 25);
            this.lblStats.TabIndex = 9;
            this.lblStats.Text = "Загрузка статистики...";
            // 
            // lblHistory
            // 
            this.lblHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistory.Location = new System.Drawing.Point(20, 235);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(180, 30);
            this.lblHistory.TabIndex = 10;
            this.lblHistory.Text = "📋 История ремонтов:";
            // 
            // lblHistoryInfo
            // 
            this.lblHistoryInfo.Location = new System.Drawing.Point(200, 240);
            this.lblHistoryInfo.Name = "lblHistoryInfo";
            this.lblHistoryInfo.Size = new System.Drawing.Size(360, 25);
            this.lblHistoryInfo.TabIndex = 11;
            this.lblHistoryInfo.Text = "";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeight = 29;
            this.dgvHistory.Location = new System.Drawing.Point(20, 270);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.Size = new System.Drawing.Size(580, 200);
            this.dgvHistory.TabIndex = 12;
            // 
            // btnViewRequest
            // 
            this.btnViewRequest.BackColor = System.Drawing.Color.LightBlue;
            this.btnViewRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRequest.Location = new System.Drawing.Point(20, 490);
            this.btnViewRequest.Name = "btnViewRequest";
            this.btnViewRequest.Size = new System.Drawing.Size(160, 40);
            this.btnViewRequest.TabIndex = 13;
            this.btnViewRequest.Text = "🔍 Просмотреть заявку";
            this.btnViewRequest.UseVisualStyleBackColor = false;
            this.btnViewRequest.Click += new System.EventHandler(this.btnViewRequest_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(200, 490);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(130, 40);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "🔄 Обновить";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightCoral;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(470, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "❌ Закрыть";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MachineCardForm
            // 
            this.ClientSize = new System.Drawing.Size(624, 553);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.lblModelValue);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.lblSerialValue);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.lblManufacturerValue);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.lblOwnerValue);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lblHistoryInfo);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.btnViewRequest);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MachineCardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карточка станка";
            
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
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblOwnerValue;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Label lblHistoryInfo;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnViewRequest;
    }
}