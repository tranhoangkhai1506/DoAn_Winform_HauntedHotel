namespace QuanLyKhachSan_Final
{
    partial class frmPhongDangThue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhongDangThue));
            this.btnTroVe = new System.Windows.Forms.Button();
            this.dgvHienTrangPhong = new System.Windows.Forms.DataGridView();
            this.maPhieuThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienTrangPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTroVe
            // 
            this.btnTroVe.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnTroVe.Location = new System.Drawing.Point(543, 223);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(80, 80);
            this.btnTroVe.TabIndex = 2;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.UseVisualStyleBackColor = false;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // dgvHienTrangPhong
            // 
            this.dgvHienTrangPhong.AllowUserToAddRows = false;
            this.dgvHienTrangPhong.AllowUserToDeleteRows = false;
            this.dgvHienTrangPhong.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHienTrangPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienTrangPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maPhieuThue,
            this.tenPhong,
            this.khachHang,
            this.ngayThue});
            this.dgvHienTrangPhong.Location = new System.Drawing.Point(5, 4);
            this.dgvHienTrangPhong.Name = "dgvHienTrangPhong";
            this.dgvHienTrangPhong.ReadOnly = true;
            this.dgvHienTrangPhong.RowHeadersWidth = 51;
            this.dgvHienTrangPhong.RowTemplate.Height = 24;
            this.dgvHienTrangPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHienTrangPhong.Size = new System.Drawing.Size(538, 520);
            this.dgvHienTrangPhong.TabIndex = 3;
            // 
            // maPhieuThue
            // 
            this.maPhieuThue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.maPhieuThue.HeaderText = "Mã Phiếu Thuê";
            this.maPhieuThue.MinimumWidth = 6;
            this.maPhieuThue.Name = "maPhieuThue";
            this.maPhieuThue.ReadOnly = true;
            // 
            // tenPhong
            // 
            this.tenPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenPhong.HeaderText = "Tên Phòng";
            this.tenPhong.MinimumWidth = 6;
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.ReadOnly = true;
            // 
            // khachHang
            // 
            this.khachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.khachHang.HeaderText = "Khách Hàng";
            this.khachHang.MinimumWidth = 6;
            this.khachHang.Name = "khachHang";
            this.khachHang.ReadOnly = true;
            // 
            // ngayThue
            // 
            this.ngayThue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ngayThue.HeaderText = "Ngày Thuê";
            this.ngayThue.MinimumWidth = 6;
            this.ngayThue.Name = "ngayThue";
            this.ngayThue.ReadOnly = true;
            // 
            // frmPhongDangThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(635, 525);
            this.Controls.Add(this.dgvHienTrangPhong);
            this.Controls.Add(this.btnTroVe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPhongDangThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH PHÒNG ĐANG ĐƯỢC THUÊ";
            this.Load += new System.EventHandler(this.frmPhongDaThue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienTrangPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.DataGridView dgvHienTrangPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn maPhieuThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn khachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayThue;
    }
}