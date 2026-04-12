namespace RepairIS.Forms
{
    partial class CreateRequestForm
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
            this.lblMachine = new System.Windows.Forms.Label();
            this.cmbMachines = new System.Windows.Forms.ComboBox();
            this.btnAddMachine = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.rbSelfDelivery = new System.Windows.Forms.RadioButton();
            this.rbMasterVisit = new System.Windows.Forms.RadioButton();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtContactPhone = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMachinesCount = new System.Windows.Forms.Label();
            this.lblSelectedMachine = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "НОВАЯ ЗАЯВКА НА РЕМОНТ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMachine
            // 
            this.lblMachine.Location = new System.Drawing.Point(30, 55);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(120, 27);
            this.lblMachine.TabIndex = 1;
            this.lblMachine.Text = "Модель станка:*";
            this.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMachines
            // 
            this.cmbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachines.Location = new System.Drawing.Point(160, 58);
            this.cmbMachines.Name = "cmbMachines";
            this.cmbMachines.Size = new System.Drawing.Size(250, 24);
            this.cmbMachines.TabIndex = 2;
            this.cmbMachines.SelectedIndexChanged += new System.EventHandler(this.cmbMachines_SelectedIndexChanged);
            // 
            // btnAddMachine
            // 
            this.btnAddMachine.BackColor = System.Drawing.Color.LightGray;
            this.btnAddMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddMachine.Location = new System.Drawing.Point(420, 56);
            this.btnAddMachine.Name = "btnAddMachine";
            this.btnAddMachine.Size = new System.Drawing.Size(40, 28);
            this.btnAddMachine.TabIndex = 3;
            this.btnAddMachine.Text = "+";
            this.btnAddMachine.UseVisualStyleBackColor = false;
            this.btnAddMachine.Click += new System.EventHandler(this.btnAddMachine_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(30, 115);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(120, 80);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Описание проблемы:*";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(160, 115);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            this.txtDescription.TabIndex = 7;
            // 
            // lblMethod
            // 
            this.lblMethod.Location = new System.Drawing.Point(30, 195);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(120, 45);
            this.lblMethod.TabIndex = 8;
            this.lblMethod.Text = "Способ осмотра:*";
            this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbSelfDelivery
            // 
            this.rbSelfDelivery.Checked = true;
            this.rbSelfDelivery.Location = new System.Drawing.Point(160, 212);
            this.rbSelfDelivery.Name = "rbSelfDelivery";
            this.rbSelfDelivery.Size = new System.Drawing.Size(120, 40);
            this.rbSelfDelivery.TabIndex = 9;
            this.rbSelfDelivery.TabStop = true;
            this.rbSelfDelivery.Text = "🚚 Сам привезу";
            this.rbSelfDelivery.CheckedChanged += new System.EventHandler(this.rbInspectionMethod_CheckedChanged);
            // 
            // rbMasterVisit
            // 
            this.rbMasterVisit.Location = new System.Drawing.Point(290, 212);
            this.rbMasterVisit.Name = "rbMasterVisit";
            this.rbMasterVisit.Size = new System.Drawing.Size(130, 40);
            this.rbMasterVisit.TabIndex = 10;
            this.rbMasterVisit.Text = "🔧 Выезд мастера";
            this.rbMasterVisit.CheckedChanged += new System.EventHandler(this.rbInspectionMethod_CheckedChanged);
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(30, 258);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(120, 36);
            this.lblPhone.TabIndex = 11;
            this.lblPhone.Text = "Контактный телефон:*";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.Location = new System.Drawing.Point(160, 258);
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.Size = new System.Drawing.Size(300, 22);
            this.txtContactPhone.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(100, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "📝 ОТПРАВИТЬ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(280, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "❌ ОТМЕНА";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblMachinesCount
            // 
            this.lblMachinesCount.ForeColor = System.Drawing.Color.Gray;
            this.lblMachinesCount.Location = new System.Drawing.Point(30, 88);
            this.lblMachinesCount.Name = "lblMachinesCount";
            this.lblMachinesCount.Size = new System.Drawing.Size(200, 20);
            this.lblMachinesCount.TabIndex = 4;
            // 
            // lblSelectedMachine
            // 
            this.lblSelectedMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblSelectedMachine.ForeColor = System.Drawing.Color.Green;
            this.lblSelectedMachine.Location = new System.Drawing.Point(160, 85);
            this.lblSelectedMachine.Name = "lblSelectedMachine";
            this.lblSelectedMachine.Size = new System.Drawing.Size(300, 20);
            this.lblSelectedMachine.TabIndex = 5;
            this.lblSelectedMachine.Visible = false;
            // 
            // CreateRequestForm
            // 
            this.ClientSize = new System.Drawing.Size(504, 378);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.cmbMachines);
            this.Controls.Add(this.btnAddMachine);
            this.Controls.Add(this.lblMachinesCount);
            this.Controls.Add(this.lblSelectedMachine);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.rbSelfDelivery);
            this.Controls.Add(this.rbMasterVisit);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtContactPhone);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание заявки на ремонт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Объявление компонентов
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.ComboBox cmbMachines;
        private System.Windows.Forms.Button btnAddMachine;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.RadioButton rbSelfDelivery;
        private System.Windows.Forms.RadioButton rbMasterVisit;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtContactPhone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMachinesCount;
        private System.Windows.Forms.Label lblSelectedMachine;
    }
}