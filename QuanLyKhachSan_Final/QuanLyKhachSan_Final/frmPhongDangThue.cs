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
    public partial class frmPhongDangThue : Form
    {
        KhachSanDBContext context = new KhachSanDBContext();
        public frmPhongDangThue()
        {
            InitializeComponent();
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
                        //else
                        //{
                        //    return false;
                        //}
                    }
                }
            }
            return true;
        }

        private void frmPhongDaThue_Load(object sender, EventArgs e)
        {
            List<PHIEUTHUEPHONG> listPhieuThue = context.PHIEUTHUEPHONG.ToList();
            List<HOADON> listHoaDon = context.HOADON.ToList();
            List<PHONG> listPhong = context.PHONG.ToList();
            List<KHACHHANG> listKhachHang = context.KHACHHANG.ToList();
            dgvHienTrangPhong.Rows.Clear();
            foreach (var item in listPhong)
            {
                if (kiemtraPhongTrongHD(item.tenPhong, listHoaDon, listPhieuThue) == false)
                {
                    PHIEUTHUEPHONG phieukhachThue = listPhieuThue.FirstOrDefault(p => p.PHONG.maPhong == item.maPhong); ;
                    
                    
                    int index = dgvHienTrangPhong.Rows.Add();
                    dgvHienTrangPhong.Rows[index].Cells[0].Value = phieukhachThue.maPhieuThue;
                    dgvHienTrangPhong.Rows[index].Cells[1].Value = item.tenPhong;
                    dgvHienTrangPhong.Rows[index].Cells[2].Value = phieukhachThue.KHACHHANG.tenKhachHang;
                    dgvHienTrangPhong.Rows[index].Cells[3].Value = phieukhachThue.ngayDen;
                }
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}