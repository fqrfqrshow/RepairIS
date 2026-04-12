namespace RepairIS.Forms
{
    partial class InspectionForm
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
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblWork = new System.Windows.Forms.Label();
            this.txtWorkRequired = new System.Windows.Forms.TextBox();
            this.lblParts = new System.Windows.Forms.Label();
            this.txtPartsNeeded = new System.Windows.Forms.TextBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.txtLaborHours = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtEstimatedCost = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblExistingInfo = new System.Windows.Forms.Label();
            this.lblEstimatedTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(50, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(480, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "АКТ ОСМОТРА СТАНКА";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblRequestInfo.Location = new System.Drawing.Point(20, 50);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(520, 50);
            this.lblRequestInfo.TabIndex = 1;
            this.lblRequestInfo.Text = "Загрузка информации о заявке...";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(20, 135);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(160, 48);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "📝 Описание неисправности:*";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(190, 135);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(350, 60);
            this.txtDescription.TabIndex = 4;
            // 
            // lblWork
            // 
            this.lblWork.Location = new System.Drawing.Point(20, 210);
            this.lblWork.Name = "lblWork";
            this.lblWork.Size = new System.Drawing.Size(160, 60);
            this.lblWork.TabIndex = 5;
            this.lblWork.Text = "🛠 Необходимые работы:";
            this.lblWork.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWorkRequired
            // 
            this.txtWorkRequired.Location = new System.Drawing.Point(190, 210);
            this.txtWorkRequired.Multiline = true;
            this.txtWorkRequired.Name = "txtWorkRequired";
            this.txtWorkRequired.Size = new System.Drawing.Size(350, 60);
            this.txtWorkRequired.TabIndex = 6;
            // 
            // lblParts
            // 
            this.lblParts.Location = new System.Drawing.Point(20, 285);
            this.lblParts.Name = "lblParts";
            this.lblParts.Size = new System.Drawing.Size(160, 60);
            this.lblParts.TabIndex = 7;
            this.lblParts.Text = "🔩 Необходимые детали:";
            this.lblParts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPartsNeeded
            // 
            this.txtPartsNeeded.Location = new System.Drawing.Point(190, 285);
            this.txtPartsNeeded.Multiline = true;
            this.txtPartsNeeded.Name = "txtPartsNeeded";
            this.txtPartsNeeded.Size = new System.Drawing.Size(350, 60);
            this.txtPartsNeeded.TabIndex = 8;
            // 
            // lblHours
            // 
            this.lblHours.Location = new System.Drawing.Point(20, 350);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(160, 40);
            this.lblHours.TabIndex = 9;
            this.lblHours.Text = "⏱ Трудоёмкость (часы):*";
            this.lblHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLaborHours
            // 
            this.txtLaborHours.Location = new System.Drawing.Point(190, 363);
            this.txtLaborHours.Name = "txtLaborHours";
            this.txtLaborHours.Size = new System.Drawing.Size(150, 22);
            this.txtLaborHours.TabIndex = 10;
            // 
            // lblCost
            // 
            this.lblCost.Location = new System.Drawing.Point(20, 400);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(160, 39);
            this.lblCost.TabIndex = 11;
            this.lblCost.Text = "💰 Ориентир. стоимость:*";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEstimatedCost
            // 
            this.txtEstimatedCost.Location = new System.Drawing.Point(190, 403);
            this.txtEstimatedCost.Name = "txtEstimatedCost";
            this.txtEstimatedCost.Size = new System.Drawing.Size(150, 22);
            this.txtEstimatedCost.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(60, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 45);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "💾 СОХРАНИТЬ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(240, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 45);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "❌ ОТМЕНА";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightYellow;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(390, 460);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(130, 45);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "🗑 ОЧИСТИТЬ";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblExistingInfo
            // 
            this.lblExistingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblExistingInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblExistingInfo.Location = new System.Drawing.Point(20, 105);
            this.lblExistingInfo.Name = "lblExistingInfo";
            this.lblExistingInfo.Size = new System.Drawing.Size(520, 20);
            this.lblExistingInfo.TabIndex = 2;
            this.lblExistingInfo.Visible = false;
            // 
            // lblEstimatedTotal
            // 
            this.lblEstimatedTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstimatedTotal.ForeColor = System.Drawing.Color.Green;
            this.lblEstimatedTotal.Location = new System.Drawing.Point(360, 360);
            this.lblEstimatedTotal.Name = "lblEstimatedTotal";
            this.lblEstimatedTotal.Size = new System.Drawing.Size(180, 65);
            this.lblEstimatedTotal.TabIndex = 13;
            this.lblEstimatedTotal.Visible = false;
            // 
            // InspectionForm
            // 
            this.ClientSize = new System.Drawing.Size(564, 533);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblExistingInfo);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblWork);
            this.Controls.Add(this.txtWorkRequired);
            this.Controls.Add(this.lblParts);
            this.Controls.Add(this.txtPartsNeeded);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.txtLaborHours);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.txtEstimatedCost);
            this.Controls.Add(this.lblEstimatedTotal);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InspectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Осмотр станка - Ремонтное предприятие";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblWork;
        private System.Windows.Forms.TextBox txtWorkRequired;
        private System.Windows.Forms.Label lblParts;
        private System.Windows.Forms.TextBox txtPartsNeeded;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.TextBox txtLaborHours;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtEstimatedCost;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblExistingInfo;
        private System.Windows.Forms.Label lblEstimatedTotal;
    }
}