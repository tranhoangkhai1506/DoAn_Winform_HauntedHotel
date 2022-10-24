namespace QuanLyKhachSan_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [StringLength(50)]
        public string maHoaDon { get; set; }

        [StringLength(50)]
        public string maPhieuThue { get; set; }

        [StringLength(50)]
        public string maNhanVien { get; set; }

        public DateTime? ngayThanhToan { get; set; }

        public double? thanhTien { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHIEUTHUEPHONG PHIEUTHUEPHONG { get; set; }
    }
}
