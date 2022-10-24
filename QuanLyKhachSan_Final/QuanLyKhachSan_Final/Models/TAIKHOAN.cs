namespace QuanLyKhachSan_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [StringLength(50)]
        public string tenDangNhap { get; set; }

        [StringLength(50)]
        public string matKhau { get; set; }

        [StringLength(50)]
        public string maNhanVien { get; set; }

        [StringLength(50)]
        public string maQuyen { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHANQUYEN PHANQUYEN { get; set; }
    }
}
