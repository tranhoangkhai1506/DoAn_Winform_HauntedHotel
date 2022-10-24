namespace QuanLyKhachSan_Final
{
    partial class frmPhongTrong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhongTrong));
            this.dgvHienTrangPhong = new System.Windows.Forms.DataGridView();
            this.tenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTroVe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienTrangPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHienTrangPhong
            // 
            this.dgvHienTrangPhong.AllowUserToAddRows = false;
            this.dgvHienTrangPhong.AllowUserToDeleteRows = false;
            this.dgvHienTrangPhong.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHienTrangPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienTrangPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tenPhong});
            this.dgvHienTrangPhong.Location = new System.Drawing.Point(6, 5);
            this.dgvHienTrangPhong.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHienTrangPhong.Name = "dgvHienTrangPhong";
            this.dgvHienTrangPhong.RowHeadersWidth = 51;
            this.dgvHienTrangPhong.RowTemplate.Height = 24;
            this.dgvHienTrangPhong.Size = new System.Drawing.Size(423, 519);
            this.dgvHienTrangPhong.TabIndex = 0;
            // 
            // tenPhong
            // 
            this.tenPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenPhong.HeaderText = "Tên Phòng";
            this.tenPhong.MinimumWidth = 6;
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.ReadOnly = true;
            // 
            // btnTroVe
            // 
            this.btnTroVe.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTroVe.Location = new System.Drawing.Point(438, 225);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(80, 80);
            this.btnTroVe.TabIndex = 3;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.UseVisualStyleBackColor = false;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // frmPhongTrong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 525);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.dgvHienTrangPhong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPhongTrong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH PHÒNG TRỐNG";
            this.Load += new System.EventHandler(this.frmHienTrangPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienTrangPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHienTrangPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenPhong;
        private System.Windows.Forms.Button btnTroVe;
    }
}