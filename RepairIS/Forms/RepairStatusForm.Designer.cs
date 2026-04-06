using System;

namespace RepairIS.Forms
{
    partial class RepairStatusForm
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStartRepair = new System.Windows.Forms.Button();
            this.btnFinishRepair = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtFinishComment = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpFinishDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "УПРАВЛЕНИЕ РЕМОНТОМ";
            this.lblTitle.Location = new System.Drawing.Point(100, 10);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblStatus
            this.lblStatus.Location = new System.Drawing.Point(50, 60);
            this.lblStatus.Size = new System.Drawing.Size(400, 40);
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11, System.Drawing.FontStyle.Bold);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnStartRepair
            this.btnStartRepair.Text = "НАЧАТЬ РЕМОНТ";
            this.btnStartRepair.Location = new System.Drawing.Point(100, 120);
            this.btnStartRepair.Size = new System.Drawing.Size(300, 50);
            this.btnStartRepair.BackColor = System.Drawing.Color.LightGreen;
            this.btnStartRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartRepair.Click += new System.EventHandler(this.btnStartRepair_Click);

            // btnFinishRepair
            this.btnFinishRepair.Text = "ЗАВЕРШИТЬ РЕМОНТ";
            this.btnFinishRepair.Location = new System.Drawing.Point(100, 190);
            this.btnFinishRepair.Size = new System.Drawing.Size(300, 50);
            this.btnFinishRepair.BackColor = System.Drawing.Color.LightYellow;
            this.btnFinishRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishRepair.Click += new System.EventHandler(this.btnFinishRepair_Click);

            // lblComment
            this.lblComment.Text = "Комментарий по завершению:";
            this.lblComment.Location = new System.Drawing.Point(50, 260);
            this.lblComment.Size = new System.Drawing.Size(180, 30);

            // txtFinishComment
            this.txtFinishComment.Location = new System.Drawing.Point(240, 260);
            this.txtFinishComment.Size = new System.Drawing.Size(200, 60);
            this.txtFinishComment.Multiline = true;

            // lblDate
            this.lblDate.Text = "Дата завершения:";
            this.lblDate.Location = new System.Drawing.Point(50, 340);
            this.lblDate.Size = new System.Drawing.Size(120, 30);

            // dtpFinishDate
            this.dtpFinishDate.Location = new System.Drawing.Point(180, 340);
            this.dtpFinishDate.Size = new System.Drawing.Size(150, 30);
            this.dtpFinishDate.Value = DateTime.Now;

            // RepairStatusForm
            this.Text = "Статус ремонта";
            this.Size = new System.Drawing.Size(500, 450);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStartRepair);
            this.Controls.Add(this.btnFinishRepair);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtFinishComment);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpFinishDate);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartRepair;
        private System.Windows.Forms.Button btnFinishRepair;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtFinishComment;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpFinishDate;
    }
}