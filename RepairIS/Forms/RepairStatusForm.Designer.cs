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
            this.lblRequestInfo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblInspectionInfo = new System.Windows.Forms.Label();
            this.btnStartRepair = new System.Windows.Forms.Button();
            this.btnFinishRepair = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtFinishComment = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpFinishDate = new System.Windows.Forms.DateTimePicker();
            this.lblNoInspectionWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(50, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "УПРАВЛЕНИЕ РЕМОНТОМ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestInfo
            // 
            this.lblRequestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblRequestInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblRequestInfo.Location = new System.Drawing.Point(20, 55);
            this.lblRequestInfo.Name = "lblRequestInfo";
            this.lblRequestInfo.Size = new System.Drawing.Size(530, 30);
            this.lblRequestInfo.TabIndex = 1;
            this.lblRequestInfo.Text = "Загрузка информации о заявке...";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(20, 95);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(530, 35);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Загрузка статуса...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInspectionInfo
            // 
            this.lblInspectionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblInspectionInfo.ForeColor = System.Drawing.Color.Green;
            this.lblInspectionInfo.Location = new System.Drawing.Point(20, 135);
            this.lblInspectionInfo.Name = "lblInspectionInfo";
            this.lblInspectionInfo.Size = new System.Drawing.Size(530, 60);
            this.lblInspectionInfo.TabIndex = 3;
            this.lblInspectionInfo.Visible = false;
            // 
            // btnStartRepair
            // 
            this.btnStartRepair.BackColor = System.Drawing.Color.LightGreen;
            this.btnStartRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartRepair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartRepair.Location = new System.Drawing.Point(50, 250);
            this.btnStartRepair.Name = "btnStartRepair";
            this.btnStartRepair.Size = new System.Drawing.Size(220, 50);
            this.btnStartRepair.TabIndex = 5;
            this.btnStartRepair.Text = "🔧 НАЧАТЬ РЕМОНТ";
            this.btnStartRepair.UseVisualStyleBackColor = false;
            this.btnStartRepair.Click += new System.EventHandler(this.btnStartRepair_Click);
            // 
            // btnFinishRepair
            // 
            this.btnFinishRepair.BackColor = System.Drawing.Color.LightYellow;
            this.btnFinishRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinishRepair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnFinishRepair.Location = new System.Drawing.Point(290, 250);
            this.btnFinishRepair.Name = "btnFinishRepair";
            this.btnFinishRepair.Size = new System.Drawing.Size(220, 50);
            this.btnFinishRepair.TabIndex = 6;
            this.btnFinishRepair.Text = "✅ ЗАВЕРШИТЬ РЕМОНТ";
            this.btnFinishRepair.UseVisualStyleBackColor = false;
            this.btnFinishRepair.Click += new System.EventHandler(this.btnFinishRepair_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(470, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 35);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "❌";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(50, 320);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(180, 60);
            this.lblComment.TabIndex = 7;
            this.lblComment.Text = "📝 Комментарий по завершению:";
            this.lblComment.Visible = false;
            // 
            // txtFinishComment
            // 
            this.txtFinishComment.Location = new System.Drawing.Point(240, 320);
            this.txtFinishComment.Multiline = true;
            this.txtFinishComment.Name = "txtFinishComment";
            this.txtFinishComment.Size = new System.Drawing.Size(270, 60);
            this.txtFinishComment.TabIndex = 8;
            this.txtFinishComment.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(50, 395);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(150, 30);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "📅 Дата завершения:";
            this.lblDate.Visible = false;
            // 
            // dtpFinishDate
            // 
            this.dtpFinishDate.Location = new System.Drawing.Point(240, 398);
            this.dtpFinishDate.Name = "dtpFinishDate";
            this.dtpFinishDate.Size = new System.Drawing.Size(150, 22);
            this.dtpFinishDate.TabIndex = 10;
            this.dtpFinishDate.Visible = false;
            // 
            // lblNoInspectionWarning
            // 
            this.lblNoInspectionWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblNoInspectionWarning.ForeColor = System.Drawing.Color.Red;
            this.lblNoInspectionWarning.Location = new System.Drawing.Point(20, 200);
            this.lblNoInspectionWarning.Name = "lblNoInspectionWarning";
            this.lblNoInspectionWarning.Size = new System.Drawing.Size(530, 30);
            this.lblNoInspectionWarning.TabIndex = 4;
            this.lblNoInspectionWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoInspectionWarning.Visible = false;
            // 
            // RepairStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(574, 493);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRequestInfo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblInspectionInfo);
            this.Controls.Add(this.lblNoInspectionWarning);
            this.Controls.Add(this.btnStartRepair);
            this.Controls.Add(this.btnFinishRepair);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtFinishComment);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpFinishDate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepairStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление ремонтом - Мастер";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequestInfo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblInspectionInfo;
        private System.Windows.Forms.Label lblNoInspectionWarning;
        private System.Windows.Forms.Button btnStartRepair;
        private System.Windows.Forms.Button btnFinishRepair;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtFinishComment;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpFinishDate;
    }
}