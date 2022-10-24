namespace QuanLyKhachSan_Final
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            this.btnTroVe = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnXuatReport = new System.Windows.Forms.Button();
            this.rdoTheoNgay = new System.Windows.Forms.RadioButton();
            this.rdoTheoThang = new System.Windows.Forms.RadioButton();
            this.dateTimePickerNgay1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerThang = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgay2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoXuatTatCa = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTroVe
            // 
            this.btnTroVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTroVe.Location = new System.Drawing.Point(748, 380);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(120, 65);
            this.btnTroVe.TabIndex = 3;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.UseVisualStyleBackColor = false;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(7, 171);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(718, 450);
            this.reportViewer1.TabIndex = 5;
            // 
            // btnXuatReport
            // 
            this.btnXuatReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnXuatReport.Location = new System.Drawing.Point(748, 289);
            this.btnXuatReport.Name = "btnXuatReport";
            this.btnXuatReport.Size = new System.Drawing.Size(120, 65);
            this.btnXuatReport.TabIndex = 6;
            this.btnXuatReport.Text = "Xuất Báo Cáo";
            this.btnXuatReport.UseVisualStyleBackColor = false;
            this.btnXuatReport.Click += new System.EventHandler(this.btnXuatReport_Click);
            // 
            // rdoTheoNgay
            // 
            this.rdoTheoNgay.AutoSize = true;
            this.rdoTheoNgay.Location = new System.Drawing.Point(202, 126);
            this.rdoTheoNgay.Name = "rdoTheoNgay";
            this.rdoTheoNgay.Size = new System.Drawing.Size(205, 24);
            this.rdoTheoNgay.TabIndex = 7;
            this.rdoTheoNgay.Text = "Xuất báo cáo theo ngày";
            this.rdoTheoNgay.UseVisualStyleBackColor = true;
            // 
            // rdoTheoThang
            // 
            this.rdoTheoThang.AutoSize = true;
            this.rdoTheoThang.Location = new System.Drawing.Point(202, 96);
            this.rdoTheoThang.Name = "rdoTheoThang";
            this.rdoTheoThang.Size = new System.Drawing.Size(211, 24);
            this.rdoTheoThang.TabIndex = 8;
            this.rdoTheoThang.Text = "Xuất báo cáo theo tháng";
            this.rdoTheoThang.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNgay1
            // 
            this.dateTimePickerNgay1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerNgay1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgay1.Location = new System.Drawing.Point(419, 126);
            this.dateTimePickerNgay1.Name = "dateTimePickerNgay1";
            this.dateTimePickerNgay1.Size = new System.Drawing.Size(132, 27);
            this.dateTimePickerNgay1.TabIndex = 9;
            // 
            // dateTimePickerThang
            // 
            this.dateTimePickerThang.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerThang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerThang.Location = new System.Drawing.Point(419, 93);
            this.dateTimePickerThang.Name = "dateTimePickerThang";
            this.dateTimePickerThang.Size = new System.Drawing.Size(132, 27);
            this.dateTimePickerThang.TabIndex = 10;
            // 
            // dateTimePickerNgay2
            // 
            this.dateTimePickerNgay2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerNgay2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerNgay2.Location = new System.Drawing.Point(593, 126);
            this.dateTimePickerNgay2.Name = "dateTimePickerNgay2";
            this.dateTimePickerNgay2.Size = new System.Drawing.Size(132, 27);
            this.dateTimePickerNgay2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(557, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "~";
            // 
            // rdoXuatTatCa
            // 
            this.rdoXuatTatCa.AutoSize = true;
            this.rdoXuatTatCa.Checked = true;
            this.rdoXuatTatCa.Location = new System.Drawing.Point(202, 66);
            this.rdoXuatTatCa.Name = "rdoXuatTatCa";
            this.rdoXuatTatCa.Size = new System.Drawing.Size(111, 24);
            this.rdoXuatTatCa.TabIndex = 13;
            this.rdoXuatTatCa.TabStop = true;
            this.rdoXuatTatCa.Text = "Xuất tất cả";
            this.rdoXuatTatCa.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.rdoXuatTatCa);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerNgay2);
            this.groupBox1.Controls.Add(this.dateTimePickerThang);
            this.groupBox1.Controls.Add(this.dateTimePickerNgay1);
            this.groupBox1.Controls.Add(this.rdoTheoThang);
            this.groupBox1.Controls.Add(this.rdoTheoNgay);
            this.groupBox1.Controls.Add(this.btnXuatReport);
            this.groupBox1.Controls.Add(this.reportViewer1);
            this.groupBox1.Controls.Add(this.btnTroVe);
            this.groupBox1.Location = new System.Drawing.Point(3, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(881, 628);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QuanLyKhachSan_Final.Properties.Resources.chart_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(24, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 112);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::QuanLyKhachSan_Final.Properties.Resources.download;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(684, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(184, 79);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 646);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTroVe;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnXuatReport;
        private System.Windows.Forms.RadioButton rdoTheoNgay;
        private System.Windows.Forms.RadioButton rdoTheoThang;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgay1;
        private System.Windows.Forms.DateTimePicker dateTimePickerThang;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgay2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoXuatTatCa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}