namespace QuanLyKhachSan_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            PHIEUTHUEPHONG = new HashSet<PHIEUTHUEPHONG>();
        }

        [Key]
        [StringLength(50)]
        public string maPhong { get; set; }

        [StringLength(50)]
        public string tenPhong { get; set; }

        [StringLength(50)]
        public string maLoai { get; set; }

        public int? soKhachToiDa { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHUEPHONG> PHIEUTHUEPHONG { get; set; }
    }
}
