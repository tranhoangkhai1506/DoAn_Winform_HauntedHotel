using QuanLyKhachSan_Final.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace QuanLyKhachSan_Final
{
    public partial class frmThongKe : Form
    {
        public string tendangnhap;
        KhachSanDBContext context = new KhachSanDBContext();

        double tongTien = 0;
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void btnXuatReport_Click(object sender, EventArgs e)
        {
            TAIKHOAN nhanVienHienHanh = context.TAIKHOAN.FirstOrDefault(p => p.tenDangNhap == tendangnhap);
            if (rdoXuatTatCa.Checked == true)
            {
                List<HOADON> listHoaDon = context.HOADON.ToList();
                List<classBaoCao> listBaoCao = new List<classBaoCao>();
                ReportParameter[] param = new ReportParameter[2];
                if (listHoaDon != null)
                {
                    foreach (HOADON item in listHoaDon)
                    {
                        PHIEUTHUEPHONG phieutemp = context.PHIEUTHUEPHONG.FirstOrDefault(p => p.maPhieuThue == item.maPhieuThue);
                        classBaoCao temp = new classBaoCao();
                        temp.maHoaDon = item.maHoaDon;
                        temp.tenKhachHang = phieutemp.KHACHHANG.tenKhachHang;
                        temp.tenPhong = phieutemp.PHONG.tenPhong;
                        temp.ngayThue = phieutemp.ngayDen.ToString();
                        temp.ngayThanhToan = item.ngayThanhToan.ToString();
                        temp.thanhTien = item.thanhTien.ToString();
                        tongTien = tongTien + (double)item.thanhTien;
                        listBaoCao.Add(temp);
                    }
                }
                else
                {
                    MessageBox.Show("Khong tim thay hoa don nao");
                }
                this.reportViewer1.LocalReport.ReportPath = "D:\\TaiLieuDaiHoc\\WinFormC#\\DoAn-QuanLyKhachSan\\QuanLyKhachSan_Final\\QuanLyKhachSan_Final\\rptHoaDonReport.rdlc";
                param[0] = new ReportParameter("tongTien", tongTien.ToString());
                param[1] = new ReportParameter("tenNhanVien", nhanVienHienHanh.NHANVIEN.tenNhanVien);
                this.reportViewer1.LocalReport.SetParameters(param);
                var reportDataSource = new ReportDataSource("HoaDonDataSet", listBaoCao);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();

                tongTien = 0;
            }else if (rdoTheoThang.Checked == true)
            {
                var listHoaDon = context.HOADON.Where(p => p.ngayThanhToan.Value.Month == dateTimePickerThang.Value.Month && p.ngayThanhToan.Value.Year == dateTimePickerThang.Value.Year);


                List<classBaoCao> listBaoCao = new List<classBaoCao>();
                ReportParameter[] param = new ReportParameter[2];

                if (listHoaDon != null)
                {
                    foreach (HOADON item in listHoaDon)
                    {
                        PHIEUTHUEPHONG phieutemp = context.PHIEUTHUEPHONG.FirstOrDefault(p => p.maPhieuThue == item.maPhieuThue);
                        classBaoCao temp = new classBaoCao();
                        temp.maHoaDon = item.maHoaDon;
                        temp.tenKhachHang = phieutemp.KHACHHANG.tenKhachHang;
                        temp.tenPhong = phieutemp.PHONG.tenPhong;
                        temp.ngayThue = phieutemp.ngayDen.ToString();
                        temp.ngayThanhToan = item.ngayThanhToan.ToString();
                        temp.thanhTien = item.thanhTien.ToString();
                        tongTien = tongTien + (double)item.thanhTien;
                        listBaoCao.Add(temp);
                    }
                }
                else
                {
                    MessageBox.Show("Khong tim thay hoa don nao");
                }
                this.reportViewer1.LocalReport.ReportPath = "D:\\TaiLieuDaiHoc\\WinFormC#\\DoAn-QuanLyKhachSan\\QuanLyKhachSan_Final\\QuanLyKhachSan_Final\\rptHoaDonReport.rdlc";
                param[0] = new ReportParameter("tongTien", tongTien.ToString());
                param[1] = new ReportParameter("tenNhanVien", nhanVienHienHanh.NHANVIEN.tenNhanVien);
                this.reportViewer1.LocalReport.SetParameters(param);
                var reportDataSource = new ReportDataSource("HoaDonDataSet", listBaoCao);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();

                tongTien = 0;
            }
            else
            {
                List<HOADON> listHoaDon = context.HOADON.Where(p => DbFunctions.TruncateTime(p.ngayThanhToan) >= DbFunctions.TruncateTime(dateTimePickerNgay1.Value) && 
                                                                    DbFunctions.TruncateTime(p.ngayThanhToan) <= DbFunctions.TruncateTime(dateTimePickerNgay2.Value)).ToList();
                List<classBaoCao> listBaoCao = new List<classBaoCao>();
                ReportParameter[] param = new ReportParameter[2];

                if (listHoaDon != null)
                {
                    foreach (HOADON item in listHoaDon)
                    {
                        PHIEUTHUEPHONG phieutemp = context.PHIEUTHUEPHONG.FirstOrDefault(p => p.maPhieuThue == item.maPhieuThue);
                        classBaoCao temp = new classBaoCao();
                        temp.maHoaDon = item.maHoaDon;
                        temp.tenKhachHang = phieutemp.KHACHHANG.tenKhachHang;
                        temp.tenPhong = phieutemp.PHONG.tenPhong;
                        temp.ngayThue = phieutemp.ngayDen.ToString();
                        temp.ngayThanhToan = item.ngayThanhToan.ToString();
                        temp.thanhTien = item.thanhTien.ToString();
                        tongTien = tongTien + (double)item.thanhTien;
                        listBaoCao.Add(temp);
                    }
                }
                else
                {
                    MessageBox.Show("Khong tim thay hoa don nao");
                }
                this.reportViewer1.LocalReport.ReportPath = "D:\\TaiLieuDaiHoc\\WinFormC#\\DoAn-QuanLyKhachSan\\QuanLyKhachSan_Final\\QuanLyKhachSan_Final\\rptHoaDonReport.rdlc";
                param[0] = new ReportParameter("tongTien", tongTien.ToString());
                param[1] = new ReportParameter("tenNhanVien", nhanVienHienHanh.NHANVIEN.tenNhanVien);
                this.reportViewer1.LocalReport.SetParameters(param);
                var reportDataSource = new ReportDataSource("HoaDonDataSet", listBaoCao);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();

                tongTien = 0;
            }         
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}