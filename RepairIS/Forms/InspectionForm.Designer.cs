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
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "АКТ ОСМОТРА СТАНКА";
            this.lblTitle.Location = new System.Drawing.Point(150, 10);
            this.lblTitle.Size = new System.Drawing.Size(250, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblRequestInfo
            this.lblRequestInfo.Location = new System.Drawing.Point(30, 50);
            this.lblRequestInfo.Size = new System.Drawing.Size(480, 50);
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Italic);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;

            // lblDesc
            this.lblDesc.Text = "Описание неисправности:";
            this.lblDesc.Location = new System.Drawing.Point(30, 110);
            this.lblDesc.Size = new System.Drawing.Size(150, 30);

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(190, 110);
            this.txtDescription.Size = new System.Drawing.Size(300, 60);
            this.txtDescription.Multiline = true;

            // lblWork
            this.lblWork.Text = "Необходимые работы:";
            this.lblWork.Location = new System.Drawing.Point(30, 190);
            this.lblWork.Size = new System.Drawing.Size(150, 30);

            // txtWorkRequired
            this.txtWorkRequired.Location = new System.Drawing.Point(190, 190);
            this.txtWorkRequired.Size = new System.Drawing.Size(300, 60);
            this.txtWorkRequired.Multiline = true;

            // lblParts
            this.lblParts.Text = "Необходимые детали:";
            this.lblParts.Location = new System.Drawing.Point(30, 270);
            this.lblParts.Size = new System.Drawing.Size(150, 30);

            // txtPartsNeeded
            this.txtPartsNeeded.Location = new System.Drawing.Point(190, 270);
            this.txtPartsNeeded.Size = new System.Drawing.Size(300, 60);
            this.txtPartsNeeded.Multiline = true;

            // lblHours
            this.lblHours.Text = "Трудоёмкость (часы):";
            this.lblHours.Location = new System.Drawing.Point(30, 350);
            this.lblHours.Size = new System.Drawing.Size(150, 30);

            // txtLaborHours
            this.txtLaborHours.Location = new System.Drawing.Point(190, 350);
            this.txtLaborHours.Size = new System.Drawing.Size(150, 30);

            // lblCost
            this.lblCost.Text = "Ориентир. стоимость:";
            this.lblCost.Location = new System.Drawing.Point(30, 400);
            this.lblCost.Size = new System.Drawing.Size(150, 30);

            // txtEstimatedCost
            this.txtEstimatedCost.Location = new System.Drawing.Point(190, 400);
            this.txtEstimatedCost.Size = new System.Drawing.Size(150, 30);

            // btnSave
            this.btnSave.Text = "Сохранить осмотр";
            this.btnSave.Location = new System.Drawing.Point(150, 460);
            this.btnSave.Size = new System.Drawing.Size(250, 40);
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // InspectionForm
            this.Text = "Осмотр станка";
            this.Size = new System.Drawing.Size(550, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
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
            this.Controls.Add(this.btnSave);
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
    }
}