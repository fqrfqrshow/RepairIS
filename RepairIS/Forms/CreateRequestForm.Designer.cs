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
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(90, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(370, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "НОВАЯ ЗАЯВКА НА РЕМОНТ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMachine
            // 
            this.lblMachine.Location = new System.Drawing.Point(30, 60);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(120, 30);
            this.lblMachine.TabIndex = 1;
            this.lblMachine.Text = "Модель станка:";
            // 
            // cmbMachines
            // 
            this.cmbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachines.Location = new System.Drawing.Point(160, 60);
            this.cmbMachines.Name = "cmbMachines";
            this.cmbMachines.Size = new System.Drawing.Size(250, 24);
            this.cmbMachines.TabIndex = 2;
            // 
            // btnAddMachine
            // 
            this.btnAddMachine.Location = new System.Drawing.Point(420, 60);
            this.btnAddMachine.Name = "btnAddMachine";
            this.btnAddMachine.Size = new System.Drawing.Size(40, 30);
            this.btnAddMachine.TabIndex = 3;
            this.btnAddMachine.Text = "+";
            this.btnAddMachine.Click += new System.EventHandler(this.btnAddMachine_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(30, 110);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(120, 80);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Описание проблемы:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(160, 110);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            this.txtDescription.TabIndex = 5;
            // 
            // lblMethod
            // 
            this.lblMethod.Location = new System.Drawing.Point(30, 217);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(120, 30);
            this.lblMethod.TabIndex = 6;
            this.lblMethod.Text = "Способ осмотра:";
            // 
            // rbSelfDelivery
            // 
            this.rbSelfDelivery.Checked = true;
            this.rbSelfDelivery.Location = new System.Drawing.Point(160, 210);
            this.rbSelfDelivery.Name = "rbSelfDelivery";
            this.rbSelfDelivery.Size = new System.Drawing.Size(120, 30);
            this.rbSelfDelivery.TabIndex = 7;
            this.rbSelfDelivery.TabStop = true;
            this.rbSelfDelivery.Text = "Сам привезу";
            // 
            // rbMasterVisit
            // 
            this.rbMasterVisit.Location = new System.Drawing.Point(290, 216);
            this.rbMasterVisit.Name = "rbMasterVisit";
            this.rbMasterVisit.Size = new System.Drawing.Size(120, 19);
            this.rbMasterVisit.TabIndex = 8;
            this.rbMasterVisit.Text = "Выезд мастера";
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(30, 260);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(120, 57);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "Контактные данные:";
            // 
            // txtContactPhone
            // 
            this.txtContactPhone.Location = new System.Drawing.Point(160, 260);
            this.txtContactPhone.Name = "txtContactPhone";
            this.txtContactPhone.Size = new System.Drawing.Size(300, 22);
            this.txtContactPhone.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(150, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Отправить заявку";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CreateRequestForm
            // 
            this.ClientSize = new System.Drawing.Size(514, 418);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.cmbMachines);
            this.Controls.Add(this.btnAddMachine);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.rbSelfDelivery);
            this.Controls.Add(this.rbMasterVisit);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtContactPhone);
            this.Controls.Add(this.btnSave);
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
    }
}