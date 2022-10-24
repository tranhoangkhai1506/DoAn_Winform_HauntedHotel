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
    public partial class frmPhongTrong : Form
    {
        KhachSanDBContext context = new KhachSanDBContext();
        public frmPhongTrong()
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

        private void frmHienTrangPhong_Load(object sender, EventArgs e)
        {
            List<PHIEUTHUEPHONG> listPhieuThue = context.PHIEUTHUEPHONG.ToList();
            List<string> listMaPhongDaThue = new List<string>();

            foreach (PHIEUTHUEPHONG item in listPhieuThue)
            {
                listMaPhongDaThue.Add(item.maPhong);
            }
            // Phong chua thue
            List<HOADON> listHoaDon = context.HOADON.ToList();
            List<PHONG> listPhong = context.PHONG.ToList();
            dgvHienTrangPhong.Rows.Clear();
            foreach (PHONG item in listPhong)
            {
                if (kiemtraPhongTrongHD(item.tenPhong, listHoaDon, listPhieuThue))
                {
                    int index = dgvHienTrangPhong.Rows.Add();
                    dgvHienTrangPhong.Rows[index].Cells[0].Value = item.tenPhong;
                }
            }          
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}