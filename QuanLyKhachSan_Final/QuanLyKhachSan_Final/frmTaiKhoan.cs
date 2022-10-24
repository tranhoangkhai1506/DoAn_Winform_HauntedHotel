using QuanLyKhachSan_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan_Final
{
    public partial class frmTaiKhoan : Form
    {
        KhachSanDBContext context = new KhachSanDBContext();
        public frmTaiKhoan()
        {
            InitializeComponent();
        }
        private void BrindGrid(List<TAIKHOAN> listTaiKhoan)
        {
            dgvTaiKhoan.Rows.Clear();
            foreach (var item in listTaiKhoan)
            {
                int index = dgvTaiKhoan.Rows.Add();
                dgvTaiKhoan.Rows[index].Cells[0].Value = item.tenDangNhap;
                dgvTaiKhoan.Rows[index].Cells[1].Value = item.matKhau;
                dgvTaiKhoan.Rows[index].Cells[2].Value = item.maNhanVien;
                dgvTaiKhoan.Rows[index].Cells[3].Value = item.maQuyen;
            }
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            List<TAIKHOAN> listTaiKhoan = context.TAIKHOAN.ToList();
            BrindGrid(listTaiKhoan);

            List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();
            cmbMaNhanVien.DataSource = listNhanVien;
            cmbMaNhanVien.DisplayMember = "maNhanVien";

            List<PHANQUYEN> listQuyen = context.PHANQUYEN.ToList();
            cmbMaQuyen.DataSource = listQuyen;
            cmbMaQuyen.DisplayMember = "maQuyen";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool kiemTraTenTaiKhoan(string ma)
        {
            for (int i = 0; i < dgvTaiKhoan.Rows.Count; i++)
            {
                if (dgvTaiKhoan.Rows[i].Cells[0].Value.ToString().CompareTo(ma) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool kiemTraNhanVien(string ma)
        {
            List<TAIKHOAN> listTaiKhoan = context.TAIKHOAN.ToList();

            foreach (TAIKHOAN item in listTaiKhoan)
            {
                if(item.maNhanVien == cmbMaNhanVien.Text)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
                {
                    if (kiemTraTenTaiKhoan(txtTenDangNhap.Text) == true)
                    {
                        if(kiemTraNhanVien(cmbMaNhanVien.Text) == true)
                        {
                                TAIKHOAN taiKhoan = new TAIKHOAN() { tenDangNhap = txtTenDangNhap.Text, matKhau = txtMatKhau.Text, maNhanVien = cmbMaNhanVien.Text, maQuyen = cmbMaQuyen.Text };
                                context.TAIKHOAN.Add(taiKhoan);
                                context.SaveChanges();
                                List<TAIKHOAN> listTaiKhoan = context.TAIKHOAN.ToList();
                                BrindGrid(listTaiKhoan);
                                MessageBox.Show("Thêm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nhân viên đã có tài khoản!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        List<TAIKHOAN> listTaiKhoan = context.TAIKHOAN.ToList();
                        TAIKHOAN taiKhoanUpdate = listTaiKhoan.FirstOrDefault(p => p.tenDangNhap == txtTenDangNhap.Text);
                        taiKhoanUpdate.tenDangNhap = txtTenDangNhap.Text;
                        taiKhoanUpdate.matKhau = txtMatKhau.Text;
                        taiKhoanUpdate.maQuyen = cmbMaQuyen.Text;
                        context.SaveChanges();
                        listTaiKhoan = context.TAIKHOAN.ToList();
                        BrindGrid(listTaiKhoan);
                        MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                TAIKHOAN dbDelete = context.TAIKHOAN.FirstOrDefault(p => p.tenDangNhap == txtTenDangNhap.Text);
                if (dbDelete != null)
                {
                    if (txtTenDangNhap.Text != "")
                    {
                        DialogResult re = MessageBox.Show("Bạn Có Muốn Xóa?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (re == DialogResult.Yes)
                        {
                            context.TAIKHOAN.Remove(dbDelete);
                            context.SaveChanges();
                            List<TAIKHOAN> listKhachHang = context.TAIKHOAN.ToList();
                            BrindGrid(listKhachHang);
                            MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng có mã: " + txtTenDangNhap.Text);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}