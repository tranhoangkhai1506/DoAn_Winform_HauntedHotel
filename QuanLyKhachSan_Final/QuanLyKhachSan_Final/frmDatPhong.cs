using QuanLyKhachSan_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan_Final
{
    public partial class frmDatPhong : Form
    {
        public string tenDangNhap;
        public string matKhau;  

        KhachSanDBContext context = new KhachSanDBContext();

        public frmDatPhong()
        {
            InitializeComponent();
        }

        private void BrindGrid(List<PHIEUTHUEPHONG> listPhieuDat)
        {
            dgvPhieuDatPhong.Rows.Clear();
            foreach (var item in listPhieuDat)
            {
                int index = dgvPhieuDatPhong.Rows.Add();
                dgvPhieuDatPhong.Rows[index].Cells[0].Value = item.maPhieuThue;
                dgvPhieuDatPhong.Rows[index].Cells[1].Value = item.maPhong;
                dgvPhieuDatPhong.Rows[index].Cells[2].Value = item.maKhachHang;
                dgvPhieuDatPhong.Rows[index].Cells[3].Value = item.maNhanVien;
                dgvPhieuDatPhong.Rows[index].Cells[4].Value = item.soNguoi;
                dgvPhieuDatPhong.Rows[index].Cells[5].Value = item.ngayDen;
            }
        }

        public bool kiemTraMaKH(string ma)
        {
            List<KHACHHANG> listKhachHang = context.KHACHHANG.ToList();
            foreach (var item in listKhachHang)
            {
                if (item.maKhachHang == txtMaKH.Text)
                {
                    return false;
                }
            }
            return true;
        }

        public bool kiemTraMaPhieuThue(string ma, List<PHIEUTHUEPHONG> listPhieuThue)
        {
            foreach (var item in listPhieuThue)
            {
                if (item.maPhieuThue == ma)
                {
                    return false;
                }
            }
            return true;
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            List<PHIEUTHUEPHONG> listPhieuDat = context.PHIEUTHUEPHONG.ToList();
            BrindGrid(listPhieuDat);
            List<LOAIPHONG> listLoaiPhong = context.LOAIPHONG.ToList();
            cmbLoaiPhong.DataSource = listLoaiPhong;
            cmbLoaiPhong.DisplayMember = "tenLoai";

            List<PHONG> listPhong = context.PHONG.Where(p => p.LOAIPHONG.tenLoai == cmbLoaiPhong.Text).ToList();
            cmbPhong.DataSource = listPhong;
            cmbPhong.DisplayMember = "tenPhong";
        }

        private void cmbLoaiPhong_TextChanged(object sender, EventArgs e)
        {
            List<PHONG> listPhong = context.PHONG.Where(p => p.LOAIPHONG.tenLoai == cmbLoaiPhong.Text).ToList();
            cmbPhong.DataSource = listPhong;
            cmbPhong.DisplayMember = "tenPhong";
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
                        if(hoaDon == null)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<PHIEUTHUEPHONG> listPhieuThue = context.PHIEUTHUEPHONG.ToList();
            List<HOADON> listHoaDon = context.HOADON.ToList();

            try
            {
                if (txtMaPhieuThue.Text != "" && txtMaKH.Text != "" && txtTenKH.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "" && txtCCCD.Text != "")
                {
                    // Kiem Tra
                    if (kiemTraMaPhieuThue(txtMaPhieuThue.Text, listPhieuThue) != true)
                    {
                        MessageBox.Show("Mã phiếu thuê đã có, vui lòng nhập lại!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (kiemTraSoNguoiO(txtSoNguoi.Text) != true)
                    {
                        MessageBox.Show("Vượt quá số người tối đa!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (kiemtraPhongTrongHD(cmbPhong.Text, listHoaDon, listPhieuThue) != true)
                    {
                        MessageBox.Show("Phòng đã được đặt, vui lòng chọn phòng khác!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (kiemTraMaKH(txtMaKH.Text) == true)
                    {
                        // Them Nhan Vien
                        KHACHHANG KhachHang = new KHACHHANG()
                        {
                            maKhachHang = txtMaKH.Text,
                            tenKhachHang = txtTenKH.Text,
                            gioiTinh = radioNam.Checked == true ? "Nam" : "Nữ",
                            soCCCD = txtCCCD.Text,
                            diaChi = txtDiaChi.Text,
                            soDienThoai = txtSDT.Text
                        };
                        context.KHACHHANG.Add(KhachHang);
                        context.SaveChanges();

                        // Chuyen doi tu string sang Datatime
                        string stringngayThue = dtpNgayDen.Value.ToString("dd-MM-yyyy");
                        DateTime datatimeNgayThue = DateTime.Parse(stringngayThue);

                        // Them Phieu Dat
                        TAIKHOAN nhanVienTruyCap = context.TAIKHOAN.FirstOrDefault(p => p.tenDangNhap == tenDangNhap);
                        string maNhanVienTruyCap = (string)nhanVienTruyCap.maNhanVien;


                        PHIEUTHUEPHONG newPhieuThemPhong = new PHIEUTHUEPHONG()
                        {
                            maPhieuThue = txtMaPhieuThue.Text,
                            maPhong = layMaPhong(cmbPhong.Text),
                            maKhachHang = txtMaKH.Text,
                            //Ma Nhan Vien ? Dang Nhap
                            maNhanVien = maNhanVienTruyCap,
                            soNguoi = int.Parse(txtSoNguoi.Text),
                            ngayDen = datatimeNgayThue
                        };
                        context.PHIEUTHUEPHONG.Add(newPhieuThemPhong);
                        context.SaveChanges();

                        MessageBox.Show("Thêm phiếu thuê phòng thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Mã khách hàng đã có, vui lòng nhập lại!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            List<PHIEUTHUEPHONG> listPhieuDat = context.PHIEUTHUEPHONG.ToList();
            BrindGrid(listPhieuDat);

        }

        private string layMaPhong(string tenPhong)
        {
            PHONG i = (PHONG)context.PHONG.FirstOrDefault(p => p.tenPhong == cmbPhong.Text);
            return i.maPhong;
        }

        private bool kiemTraSoNguoiO(string soNguoi)
        {
            PHONG phongChon = context.PHONG.FirstOrDefault(p => p.tenPhong == cmbPhong.Text);

            if (int.Parse(txtSoNguoi.Text) > phongChon.soKhachToiDa)
            {
                return false;
            }
            return true;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnXoaPTP_Click(object sender, EventArgs e)
        {
            try
            {   
                if (txtMaPhieuThue.Text != "")
                {
                    PHIEUTHUEPHONG dbDelete = context.PHIEUTHUEPHONG.FirstOrDefault(p => p.maPhieuThue == txtMaPhieuThue.Text);
                    HOADON maPhieuinHoaDon = context.HOADON.FirstOrDefault(p => p.maPhieuThue == txtMaPhieuThue.Text);
                    if (dbDelete != null)
                    {
                        if (maPhieuinHoaDon != null)
                        {
                            txtMaPhieuThue.Clear();
                            MessageBox.Show("BẠN CẦN XÓA HÓA ĐƠN CỦA KHÁCH HÀNG: "+dbDelete.KHACHHANG.tenKhachHang+"\nCÓ MÃ KHÁCH HÀNG: "+dbDelete.maKhachHang+"!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmHoaDon frmHoaDon = new frmHoaDon();
                            frmHoaDon.ShowDialog();
                            context.SaveChanges();
                            
                        }
                        else
                        {
                            try
                            {
                                DialogResult re = MessageBox.Show("Bạn Có Muốn Xóa?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (re == DialogResult.Yes)
                                {
                                    context.PHIEUTHUEPHONG.Remove(dbDelete);
                                    context.SaveChanges();
                                    List<PHIEUTHUEPHONG> listPhieuThue = context.PHIEUTHUEPHONG.ToList();                                   
                                    BrindGrid(listPhieuThue);
                                    MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (DbUpdateConcurrencyException ex)
                            {
                                ex.Entries.Single().Reload();
                                context.PHIEUTHUEPHONG.Remove(dbDelete);
                                context.SaveChanges();
                                List<PHIEUTHUEPHONG> listPhieuThue = context.PHIEUTHUEPHONG.ToList();
                                BrindGrid(listPhieuThue);
                                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu thuê!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã phiếu thuê  cần xóa!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPhieuDatPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuDatPhong.SelectedRows.Count > 0)
            {
                txtMaPhieuThue.Text = (string)dgvPhieuDatPhong.SelectedRows[0].Cells[0].Value;
                txtSoNguoi.Text = dgvPhieuDatPhong.SelectedRows[0].Cells[4].Value.ToString();

                List<PHONG> listPhong = context.PHONG.ToList();
                List<KHACHHANG> listKhachHang = context.KHACHHANG.ToList();

                PHONG phongChon = listPhong.FirstOrDefault(p => p.maPhong == (string)dgvPhieuDatPhong.SelectedRows[0].Cells[1].Value);
                cmbPhong.Text = phongChon.tenPhong;
                cmbLoaiPhong.Text = phongChon.LOAIPHONG.tenLoai;

                KHACHHANG khachHangChon = listKhachHang.FirstOrDefault(p => p.maKhachHang == (string)dgvPhieuDatPhong.SelectedRows[0].Cells[2].Value);
                txtMaKH.Text = khachHangChon.maKhachHang;
                txtTenKH.Text = khachHangChon.tenKhachHang;
                if (khachHangChon.gioiTinh != "Nam")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioNam.Checked = true;
                }
                txtCCCD.Text = khachHangChon.soCCCD;
                txtDiaChi.Text = khachHangChon.diaChi;
                txtSDT.Text = khachHangChon.soDienThoai;

                dtpNgayDen.Value = DateTime.Parse(dgvPhieuDatPhong.SelectedRows[0].Cells[5].Value.ToString());
            }
        }
    }
}