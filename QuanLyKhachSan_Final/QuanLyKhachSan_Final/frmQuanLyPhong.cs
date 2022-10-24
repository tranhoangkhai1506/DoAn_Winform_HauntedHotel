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
    public partial class frmQuanLyPhong : Form
    {

        KhachSanDBContext context = new KhachSanDBContext();
        public frmQuanLyPhong()
        {
            InitializeComponent();
        }

        private void BrindGridLoaiPhong(List<LOAIPHONG> listLoaiPhong)
        {
            dgvLoaiPhong.Rows.Clear();
            foreach (var item in listLoaiPhong)
            {
                int index = dgvLoaiPhong.Rows.Add();
                dgvLoaiPhong.Rows[index].Cells[0].Value = item.maLoai;
                dgvLoaiPhong.Rows[index].Cells[1].Value = item.tenLoai;
                dgvLoaiPhong.Rows[index].Cells[2].Value = item.giaThue;
            }
        }

        private void BrindGridPhong(List<PHONG> listPhong)
        {
            dgvPhong.Rows.Clear();
            foreach (var item in listPhong)
            {
                int index = dgvPhong.Rows.Add();
                dgvPhong.Rows[index].Cells[0].Value = item.maPhong;
                dgvPhong.Rows[index].Cells[1].Value = item.tenPhong;
                dgvPhong.Rows[index].Cells[2].Value = item.maLoai;
                dgvPhong.Rows[index].Cells[3].Value = item.soKhachToiDa;
            }
        }
        public bool kiemTraMaLoaiPhong(string ma)
        {
            for (int i = 0; i < dgvLoaiPhong.Rows.Count; i++)
            {
                if (dgvLoaiPhong.Rows[i].Cells[0].Value.ToString().CompareTo(ma) == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            List<LOAIPHONG> listLoaiPhong = context.LOAIPHONG.ToList();
            List<PHONG> listPhong = context.PHONG.ToList();
            BrindGridLoaiPhong(listLoaiPhong);
            BrindGridPhong(listPhong);


            cmbMaLoai.DataSource = listLoaiPhong;
            cmbMaLoai.DisplayMember = "maLoai";
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool kiemTraMaLoai(string ma)
        {
            for (int i = 0; i < dgvLoaiPhong.Rows.Count; i++)
            {
                if (dgvLoaiPhong.Rows[i].Cells[0].Value.ToString().CompareTo(ma) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool kiemTraMaPhong(string ma)
        {
            for (int i = 0; i < dgvPhong.Rows.Count; i++)
            {
                if (dgvPhong.Rows[i].Cells[0].Value.ToString().CompareTo(ma) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtMaLoai.Text != "" && txtTenLoai.Text != "" && txtGiaThue.Text != "")
                {
                    if (kiemTraMaLoai(txtMaLoai.Text) == true)
                    {
                        LOAIPHONG loaiPhong = new LOAIPHONG()
                        {
                            maLoai = txtMaLoai.Text,
                            tenLoai = txtTenLoai.Text,
                            giaThue = double.Parse(txtGiaThue.Text)
                        };
                        context.LOAIPHONG.Add(loaiPhong);
                        context.SaveChanges();
                        List<LOAIPHONG> listLoaiPhong = context.LOAIPHONG.ToList();
                        BrindGridLoaiPhong(listLoaiPhong);
                        MessageBox.Show("Thêm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        cmbMaLoai.DataSource = listLoaiPhong;
                        cmbMaLoai.DisplayMember = "maLoai";

                    }
                    else
                    {
                        LOAIPHONG loaiPhong = context.LOAIPHONG.FirstOrDefault(p => p.maLoai == txtMaLoai.Text);
                        
                        loaiPhong.maLoai = txtMaLoai.Text;
                        loaiPhong.tenLoai = txtTenLoai.Text;
                        loaiPhong.giaThue = double.Parse(txtGiaThue.Text);

                        context.SaveChanges();
                        List<LOAIPHONG> listLoai = context.LOAIPHONG.ToList();
                        BrindGridLoaiPhong(listLoai);
                        MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        cmbMaLoai.DataSource = listLoai;
                        cmbMaLoai.DisplayMember = "maLoai";
                    }
                }
                else
                {
                    MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            LOAIPHONG loaiPhongDelete = context.LOAIPHONG.FirstOrDefault(p => p.maLoai == txtMaLoai.Text);


            if (loaiPhongDelete != null)
            {
                PHONG phongCoMaPhong = context.PHONG.FirstOrDefault(p => p.maLoai == txtMaLoai.Text);
                if (phongCoMaPhong != null)
                {
                    MessageBox.Show("BẠN CẦN XÓA PHÒNG CÓ MÃ LÀ: " + loaiPhongDelete.maLoai + "!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        DialogResult re = MessageBox.Show("Bạn Có Muốn Xóa?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (re == DialogResult.Yes)
                        {
                            context.LOAIPHONG.Remove(loaiPhongDelete);
                            context.SaveChanges();
                            List<LOAIPHONG> listloaiPhong = context.LOAIPHONG.ToList();
                            BrindGridLoaiPhong(listloaiPhong);
                            MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cmbMaLoai.DataSource = listloaiPhong;
                            cmbMaLoai.DisplayMember = "maLoai";
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    } 
                }
                
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPhong.Text != "" && txtTenPhong.Text != "" && txtSoKhachToiDa.Text != "")
                {
                    if (kiemTraMaPhong(txtMaPhong.Text) == true)
                    {
                        PHONG Phong = new PHONG()
                        {
                            maPhong = txtMaPhong.Text,
                            tenPhong = txtTenPhong.Text,
                            maLoai = cmbMaLoai.Text,
                            soKhachToiDa = int.Parse(txtSoKhachToiDa.Text)
                        };
                        context.PHONG.Add(Phong);
                        context.SaveChanges();
                        List<PHONG> listPhong = context.PHONG.ToList();
                        BrindGridPhong(listPhong);
                        MessageBox.Show("Thêm thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        PHONG Phong = context.PHONG.FirstOrDefault(p => p.maPhong == txtMaPhong.Text);

                        Phong.maPhong = txtMaPhong.Text;
                        Phong.tenPhong = txtTenPhong.Text;
                        Phong.maLoai = cmbMaLoai.Text;
                        Phong.soKhachToiDa = int.Parse(txtSoKhachToiDa.Text);

                        context.SaveChanges();
                        List<PHONG> listPhong = context.PHONG.ToList();
                        BrindGridPhong(listPhong);
                        MessageBox.Show("Sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            PHONG PhongDelete = context.PHONG.FirstOrDefault(p => p.maPhong == txtMaPhong.Text);

            if (PhongDelete != null)
            {
                PHIEUTHUEPHONG phieuThue = context.PHIEUTHUEPHONG.FirstOrDefault(p => p.maPhong == txtMaPhong.Text);
                if(phieuThue == null) 
                {
                    try
                    {
                        DialogResult re = MessageBox.Show("Bạn Có Muốn Xóa?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (re == DialogResult.Yes)
                        {
                            context.PHONG.Remove(PhongDelete);
                            context.SaveChanges();
                            List<PHONG> listPhong = context.PHONG.ToList();
                            BrindGridPhong(listPhong);
                            MessageBox.Show("Xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Phòng đang được thuê!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvLoaiPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLoaiPhong.SelectedRows.Count > 0)
            {
                txtMaLoai.Text = (string)dgvLoaiPhong.SelectedRows[0].Cells[0].Value;
                txtTenLoai.Text = (string)dgvLoaiPhong.SelectedRows[0].Cells[1].Value;                
                txtGiaThue.Text = Convert.ToString(dgvLoaiPhong.SelectedRows[0].Cells[2].Value);
            }
        }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhong.SelectedRows.Count > 0)
            {
                txtMaPhong.Text = (string)dgvPhong.SelectedRows[0].Cells[0].Value;
                txtTenPhong.Text = (string)dgvPhong.SelectedRows[0].Cells[1].Value;
                cmbMaLoai.Text = (string)dgvPhong.SelectedRows[0].Cells[2].Value;
                txtSoKhachToiDa.Text = Convert.ToString(dgvPhong.SelectedRows[0].Cells[3].Value);
            }
        }
    }
}