namespace QuanLyKhachSan_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTHUEPHONG")]
    public partial class PHIEUTHUEPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTHUEPHONG()
        {
            HOADON = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(50)]
        public string maPhieuThue { get; set; }

        [StringLength(50)]
        public string maPhong { get; set; }

        [StringLength(50)]
        public string maKhachHang { get; set; }

        [StringLength(50)]
        public string maNhanVien { get; set; }

        public int? soNguoi { get; set; }

        public DateTime? ngayDen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
