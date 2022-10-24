using QuanLyKhachSan_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan_Final
{    
    public partial class frmMain : Form
    {
        public KhachSanDBContext context = new KhachSanDBContext();

        public string tenDangNhap;
        public string matKhau;

        public frmMain()
        {
            InitializeComponent();
        }

        private void quanLyKhachHangMenu_Click(object sender, EventArgs e)
        {
            frmKhachHang themkh = new frmKhachHang();
            themkh.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.ShowDialog();
        }
        private bool kiemtraPhongTrongHD(string tenPhong, List<HOADON> listHoaDon, List<PHIEUTHUEPHONG> listPhieuThue)
        {
            if (listPhieuThue != null)
            {
                foreach (PHIEUTHUEPHONG i in listPhieuThue)
                {
                    if (i.PHONG.tenPhong == tenPhong)
                    {
                        HOADON hoaDon = listHoaDon.FirstOrDefault(p => p.maPhieuThue == i.maPhieuThue);
                        if (hoaDon == null)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void loadHienTrang()
        {
            int phongDangDuocThue = 0;
            // Phong da thue
            List<PHIEUTHUEPHONG> listPhieuThue = context.PHIEUTHUEPHONG.ToList();
            List<HOADON> listHoaDon = context.HOADON.ToList();
            // 2 list de kiem tra phong trong
            List<PHONG> listPhong = context.PHONG.ToList();// de ktra tung phong
            List<PHONG> listPhongTrong = context.PHONG.ToList(); // thuc hien viec xoa neu phong do dang dc thue

            foreach (var item in listPhong)
            {
                if (kiemtraPhongTrongHD(item.tenPhong, listHoaDon, listPhieuThue) == false)
                {
                    phongDangDuocThue++;
                }
            }

            btnPhongDaThue.Text = "Phòng đang được thuê: " + phongDangDuocThue;
            // Phong chua thue


            foreach (var item in listPhong)
            {
                if (kiemtraPhongTrongHD(item.tenPhong, listHoaDon, listPhieuThue) == false)
                {
                    listPhongTrong.Remove(item);
                }
            }

            btnPhongTrong.Text = "Phòng trống: " + listPhongTrong.Count;
        }

        public void loadBangGia()
        {
            List<LOAIPHONG> listLoaiPhong = context.LOAIPHONG.ToList();

            dgvBangGia.Rows.Clear();
            foreach (LOAIPHONG item in listLoaiPhong)
            {
                int index = dgvBangGia.Rows.Add();
                dgvBangGia.Rows[index].Cells[0].Value = item.tenLoai;
                dgvBangGia.Rows[index].Cells[1].Value = item.giaThue;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<TAIKHOAN> listTaiKhoan = context.TAIKHOAN.ToList();
            TAIKHOAN taiKhoan = listTaiKhoan.FirstOrDefault(p => p.tenDangNhap == tenDangNhap);

            NHANVIEN nhanVien = context.NHANVIEN.FirstOrDefault(p => p.maNhanVien == taiKhoan.maNhanVien);
            MessageBox.Show("XIN CHÀO " + nhanVien.tenNhanVien + "", "WELCOME TO HAUNTED HOTEL", MessageBoxButtons.OK);
            lbNhanVienHienTai.Text = nhanVien.tenNhanVien;

            loadHienTrang();
            loadBangGia();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult re = MessageBox.Show("Ban Muon Thoat?", "Xac Nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (re == DialogResult.Yes)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Exit();
            }  
        }
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TAIKHOAN tk = context.TAIKHOAN.FirstOrDefault(p => p.tenDangNhap == tenDangNhap);
            if (tk.PHANQUYEN.tenQuyen == "Quản Lý")
            {
                frmNhanVien frmNhanVien = new frmNhanVien();
                frmNhanVien.ShowDialog();
            }
            else
            {
                MessageBox.Show("BẠN KHÔNG CÓ QUYỀN TRUY CẬP!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tHANHTOÁNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frmHoaDon = new frmHoaDon();
            frmHoaDon.tenDangNhap = tenDangNhap;
            frmHoaDon.matKhau = matKhau;
            frmHoaDon.ShowDialog();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TAIKHOAN tk = context.TAIKHOAN.FirstOrDefault(p => p.tenDangNhap == tenDangNhap);
            if (tk.PHANQUYEN.tenQuyen == "Quản Lý")
            {
                frmTaiKhoan frmTaiKhoan = new frmTaiKhoan();
                frmTaiKhoan.ShowDialog();
            }
            else
            {
                MessageBox.Show("BẠN KHÔNG CÓ QUYỀN TRUY CẬP!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = String.Format("Bây giờ là {0}",DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            frmDatPhong frmdatPhong = new frmDatPhong();
            frmdatPhong.tenDangNhap = tenDangNhap;
            frmdatPhong.matKhau = matKhau;
            frmdatPhong.ShowDialog();
            loadHienTrang();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            frmHoaDon frmHoaDon = new frmHoaDon();
            frmHoaDon.tenDangNhap = tenDangNhap;
            frmHoaDon.matKhau = matKhau;
            frmHoaDon.ShowDialog();
            loadHienTrang();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang themkh = new frmKhachHang();
            themkh.ShowDialog();
            loadHienTrang();
        }

        private void btnPhongTrong_Click(object sender, EventArgs e)
        {
            frmPhongTrong frmHienTrangPhong = new frmPhongTrong();
            frmHienTrangPhong.ShowDialog();
        }

        private void btnPhongDaThue_Click(object sender, EventArgs e)
        {
            frmPhongDangThue frmPhongDaThue = new frmPhongDangThue();
            frmPhongDaThue.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe frmThongKe = new frmThongKe();
            frmThongKe.tendangnhap = tenDangNhap;
            frmThongKe.ShowDialog();
        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TAIKHOAN tk = context.TAIKHOAN.FirstOrDefault(p => p.tenDangNhap == tenDangNhap);
            if (tk.PHANQUYEN.tenQuyen == "Quản Lý")
            {
                frmQuanLyPhong frmQLPhong = new frmQuanLyPhong();
                frmQLPhong.ShowDialog();

                loadHienTrang();
                loadBangGia();
            }
            else
            {
                MessageBox.Show("BẠN KHÔNG CÓ QUYỀN TRUY CẬP!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void tRỢGIÚPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nhóm 02\nThành Viên:\nTrần Hoàng Khải - 2011060423\nNguyễn Ngọc Huy - 2011065181\nBùi Bá Quảng - 2011065302","THÔNG TIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tHỐNGKÊToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe frmThongKe = new frmThongKe();
            frmThongKe.tendangnhap = tenDangNhap;
            frmThongKe.ShowDialog();
        }
    }
}