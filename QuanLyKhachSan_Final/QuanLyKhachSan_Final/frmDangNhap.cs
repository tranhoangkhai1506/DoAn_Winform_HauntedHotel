using QuanLyKhachSan_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan_Final
{
    public partial class frmDangNhap : Form
    {
        KhachSanDBContext context = new KhachSanDBContext();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("THOÁT?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (re == DialogResult.Yes)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            List<TAIKHOAN> listTaiKhoan = context.TAIKHOAN.ToList();
            List<PHANQUYEN> listPhanQuyen = context.PHANQUYEN.ToList();


            TAIKHOAN tkDangNhap = context.TAIKHOAN.FirstOrDefault(p => p.tenDangNhap == txtTaiKhoan.Text
                                                                      && p.matKhau == txtMatKhau.Text);


            try
            {
                if (txtTaiKhoan.Text != "" && txtMatKhau.Text != "")
                {
                    if (tkDangNhap != null)
                    {
                        this.Hide();
                        frmMain frmMain = new frmMain();
                        frmMain.tenDangNhap = txtTaiKhoan.Text;
                        frmMain.matKhau = txtMatKhau.Text;
                        frmMain.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tên tài khoản và mật khẩu", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDangNhap_Enter(object sender, EventArgs e)
        {
            btnDangNhap_Click(sender, e);
        }
    }
}