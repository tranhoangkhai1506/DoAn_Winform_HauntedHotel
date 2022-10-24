using QuanLyKhachSan_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan_Final
{
    public partial class frmKhachHang : Form
    {
        KhachSanDBContext context = new KhachSanDBContext();

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            try
            {

                List<KHACHHANG> khachHang = context.KHACHHANG.ToList();

                BrindGrid(khachHang);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BrindGrid(List<KHACHHANG> khachHang)
        {
            dgvKhachHang.Rows.Clear();
            foreach (var item in khachHang)
            {
                int index = dgvKhachHang.Rows.Add();
                dgvKhachHang.Rows[index].Cells[0].Value = item.maKhachHang;
                dgvKhachHang.Rows[index].Cells[1].Value = item.tenKhachHang;
                dgvKhachHang.Rows[index].Cells[2].Value = item.gioiTinh;
                dgvKhachHang.Rows[index].Cells[3].Value = item.soCCCD;
                dgvKhachHang.Rows[index].Cells[4].Value = item.diaChi;
                dgvKhachHang.Rows[index].Cells[5].Value = item.soDienThoai;
            }
        }

        public bool kiemTraMaKH(string ma)
        {
            for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
            {
                if (dgvKhachHang.Rows[i].Cells[0].Value.ToString().CompareTo(ma) == 0)
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
                if (txtMaKH.Text != "" && txtTenKH.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "" && txtCCCD.Text != "")
                {
                    if (kiemTraMaKH(txtMaKH.Text) == true)
                    {
                        KHACHHANG KhachHang = new KHACHHANG() { maKhachHang = txtMaKH.Text, tenKhachHang = txtTenKH.Text, gioiTinh = radioNam.Checked == true ? "Nam" : "Nữ", soCCCD = txtCCCD.Text, diaChi = txtDiaChi.Text, soDienThoai = txtSDT.Text };
                        context.KHACHHANG.Add(KhachHang);
                        context.SaveChanges();
                        List<KHACHHANG> listKhachHang = context.KHACHHANG.ToList();
                        BrindGrid(listKhachHang);
                        MessageBox.Show("Thêm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        List<KHACHHANG> listKhachHang = context.KHACHHANG.ToList();
                        KHACHHANG khachHangUpdate = listKhachHang.FirstOrDefault(p => p.maKhachHang == txtMaKH.Text);
                        khachHangUpdate.maKhachHang = txtMaKH.Text;
                        khachHangUpdate.tenKhachHang = txtTenKH.Text;
                        khachHangUpdate.gioiTinh = radioNam.Checked == true ? "Nam" : "Nữ";
                        khachHangUpdate.soCCCD = txtCCCD.Text;
                        khachHangUpdate.diaChi = txtDiaChi.Text;
                        khachHangUpdate.soDienThoai = txtSDT.Text;
                        context.SaveChanges();
                        listKhachHang = context.KHACHHANG.ToList();
                        BrindGrid(listKhachHang);
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

            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtCCCD.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaKH.Text != "")
                {
                    KHACHHANG dbDelete = context.KHACHHANG.FirstOrDefault(p => p.maKhachHang == txtMaKH.Text);
                    if (dbDelete != null)
                    {
                        List<PHIEUTHUEPHONG> listPhieuThue = context.PHIEUTHUEPHONG.ToList();
                        PHIEUTHUEPHONG khachHangCoPhieuThue = listPhieuThue.FirstOrDefault(p => p.maKhachHang == dbDelete.maKhachHang);
                        if (khachHangCoPhieuThue != null)
                        {
                            MessageBox.Show("BẠN CẦN XÓA PHIẾU THUÊ CỦA KHÁCH HÀNG: " + dbDelete.tenKhachHang + "\nCÓ MÃ KHÁCH HÀNG: " + dbDelete.maKhachHang + "!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            frmDatPhong frmDatPhong = new frmDatPhong();
                            frmDatPhong.ShowDialog();
                            context.SaveChanges();
                        }
                        else
                        {
                            try
                            {
                                DialogResult re = MessageBox.Show("Bạn Có Muốn Xóa?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (re == DialogResult.Yes)
                                {
                                    context.KHACHHANG.Remove(dbDelete);
                                    context.SaveChanges();
                                    List<KHACHHANG> listKhachHang = context.KHACHHANG.ToList();
                                    BrindGrid(listKhachHang);
                                    MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (DbUpdateConcurrencyException ex)
                            {
                                ex.Entries.Single().Reload();
                                context.KHACHHANG.Remove(dbDelete);
                                context.SaveChanges();
                                List<KHACHHANG> listKhachHang = context.KHACHHANG.ToList();
                                BrindGrid(listKhachHang);
                                MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng có mã: " + txtMaKH.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa!", "CHÚ Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                txtMaKH.Text = (string)dgvKhachHang.SelectedRows[0].Cells[0].Value;
                txtTenKH.Text = (string)dgvKhachHang.SelectedRows[0].Cells[1].Value;
                if (Convert.ToString(dgvKhachHang.SelectedRows[0].Cells[2].Value) != "Nam")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioNam.Checked = true;
                }
                txtCCCD.Text = (string)dgvKhachHang.SelectedRows[0].Cells[3].Value;
                txtDiaChi.Text = (string)dgvKhachHang.SelectedRows[0].Cells[4].Value;
                txtSDT.Text = (string)dgvKhachHang.SelectedRows[0].Cells[5].Value;
            }
        }

        private void btnTatCaKhachHang_Click(object sender, EventArgs e)
        {
            List<KHACHHANG> khachHang = context.KHACHHANG.ToList();

            BrindGrid(khachHang);
        }


        private void txtTimKhachHang_TextChanged(object sender, EventArgs e)
        {
            List<KHACHHANG> listKhachHang = context.KHACHHANG.ToList();
            dgvKhachHang.Rows.Clear();
            foreach (KHACHHANG item in listKhachHang)
            {
                if (item.soCCCD.Contains(txtTimKhachHang.Text))
                {
                    int index = dgvKhachHang.Rows.Add();
                    dgvKhachHang.Rows[index].Cells[0].Value = item.maKhachHang;
                    dgvKhachHang.Rows[index].Cells[1].Value = item.tenKhachHang;
                    dgvKhachHang.Rows[index].Cells[2].Value = item.gioiTinh;
                    dgvKhachHang.Rows[index].Cells[3].Value = item.soCCCD;
                    dgvKhachHang.Rows[index].Cells[4].Value = item.diaChi;
                    dgvKhachHang.Rows[index].Cells[5].Value = item.soDienThoai;
                }
            }

        }
    }
}