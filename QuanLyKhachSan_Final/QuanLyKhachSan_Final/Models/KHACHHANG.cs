namespace QuanLyKhachSan_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            PHIEUTHUEPHONG = new HashSet<PHIEUTHUEPHONG>();
        }

        [Key]
        [StringLength(50)]
        public string maKhachHang { get; set; }

        [StringLength(50)]
        public string tenKhachHang { get; set; }

        [StringLength(50)]
        public string gioiTinh { get; set; }

        [StringLength(50)]
        public string soCCCD { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        [StringLength(50)]
        public string soDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHUEPHONG> PHIEUTHUEPHONG { get; set; }
    }
}
