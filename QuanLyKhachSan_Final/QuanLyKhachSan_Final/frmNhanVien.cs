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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyKhachSan_Final
{
    public partial class frmNhanVien : Form
    {
        KhachSanDBContext context = new KhachSanDBContext();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                List<NHANVIEN> nhanVien = context.NHANVIEN.ToList();

                BrindGrid(nhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BrindGrid(List<NHANVIEN> nhanVien)
        {
            dgvNhanVien.Rows.Clear();
            foreach (var item in nhanVien)
            {
                int index = dgvNhanVien.Rows.Add();
                dgvNhanVien.Rows[index].Cells[0].Value = item.maNhanVien;
                dgvNhanVien.Rows[index].Cells[1].Value = item.tenNhanVien;
                dgvNhanVien.Rows[index].Cells[2].Value = item.gioiTinh;
                dgvNhanVien.Rows[index].Cells[3].Value = item.soCCCD;
                dgvNhanVien.Rows[index].Cells[4].Value = item.diaChi;
                dgvNhanVien.Rows[index].Cells[5].Value = item.soDienThoai;
            }
        }

        public bool kiemTraMaVN(string ma)
        {
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                if (dgvNhanVien.Rows[i].Cells[0].Value.ToString().CompareTo(ma) == 0)
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
                if (txtMaNV.Text != "" && txtTenNV.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "" && txtCCCD.Text != "")
                {
                    if (kiemTraMaVN(txtMaNV.Text) == true)
                    {
                        NHANVIEN nhanVien = new NHANVIEN() { maNhanVien = txtMaNV.Text, tenNhanVien = txtTenNV.Text, gioiTinh = radioNam.Checked == true ? "Nam" : "Nữ", soCCCD = txtCCCD.Text, diaChi = txtDiaChi.Text, soDienThoai = txtSDT.Text };
                        context.NHANVIEN.Add(nhanVien);
                        context.SaveChanges();
                        List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();
                        BrindGrid(listNhanVien);
                        MessageBox.Show("Thêm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();
                        NHANVIEN nhanVienUpdate = listNhanVien.FirstOrDefault(p => p.maNhanVien == txtMaNV.Text);
                        nhanVienUpdate.maNhanVien = txtMaNV.Text;
                        nhanVienUpdate.tenNhanVien = txtTenNV.Text;
                        nhanVienUpdate.gioiTinh = radioNam.Checked == true ? "Nam" : "Nữ";
                        nhanVienUpdate.soCCCD = txtCCCD.Text;
                        nhanVienUpdate.diaChi = txtDiaChi.Text;
                        nhanVienUpdate.soDienThoai = txtSDT.Text;
                        context.SaveChanges();
                        listNhanVien = context.NHANVIEN.ToList();
                        BrindGrid(listNhanVien);
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

            txtMaNV.Clear();
            txtTenNV.Clear();
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
                NHANVIEN dbDelete = context.NHANVIEN.FirstOrDefault(p => p.maNhanVien == txtMaNV.Text);
                if (dbDelete != null)
                {
                    if (txtMaNV.Text != "")
                    {
                        DialogResult re = MessageBox.Show("Bạn Có Muốn Xóa?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (re == DialogResult.Yes)
                        {
                            context.NHANVIEN.Remove(dbDelete);
                            context.SaveChanges();
                            List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();
                            BrindGrid(listNhanVien);
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
                    MessageBox.Show("Không tìm thấy khách hàng có mã: " + txtMaNV.Text);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                txtMaNV.Text = (string)dgvNhanVien.SelectedRows[0].Cells[0].Value;
                txtTenNV.Text = (string)dgvNhanVien.SelectedRows[0].Cells[1].Value;
                if (Convert.ToString(dgvNhanVien.SelectedRows[0].Cells[2].Value) != "Nữ")
                {
                    radioNam.Checked = true;
                    
                }
                else
                {
                    radioNu.Checked = true;
                }
                txtCCCD.Text = (string)dgvNhanVien.SelectedRows[0].Cells[3].Value;
                txtDiaChi.Text = (string)dgvNhanVien.SelectedRows[0].Cells[4].Value;
                txtSDT.Text = (string)dgvNhanVien.SelectedRows[0].Cells[5].Value;
            }
        }


        private void btnTatCaNhanVien_Click(object sender, EventArgs e)
        {
            List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();

            BrindGrid(listNhanVien);
        }

        private void txtTimNhanVien_TextChanged(object sender, EventArgs e)
        {
            List<NHANVIEN> nhanVien = context.NHANVIEN.ToList();
            dgvNhanVien.Rows.Clear();
            foreach (var item in nhanVien)
            {
                if (item.soCCCD.Contains(txtTimNhanVien.Text))
                {
                    int index = dgvNhanVien.Rows.Add();
                    dgvNhanVien.Rows[index].Cells[0].Value = item.maNhanVien;
                    dgvNhanVien.Rows[index].Cells[1].Value = item.tenNhanVien;
                    dgvNhanVien.Rows[index].Cells[2].Value = item.gioiTinh;
                    dgvNhanVien.Rows[index].Cells[3].Value = item.soCCCD;
                    dgvNhanVien.Rows[index].Cells[4].Value = item.diaChi;
                    dgvNhanVien.Rows[index].Cells[5].Value = item.soDienThoai;
                } 
            }
        }
    }
}