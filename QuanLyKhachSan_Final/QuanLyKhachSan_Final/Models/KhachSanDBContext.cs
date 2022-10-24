using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyKhachSan_Final.Models
{
    public partial class KhachSanDBContext : DbContext
    {
        public KhachSanDBContext()
            : base("name=KhachSanDBContext")
        {
        }

        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONG { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYEN { get; set; }
        public virtual DbSet<PHIEUTHUEPHONG> PHIEUTHUEPHONG { get; set; }
        public virtual DbSet<PHONG> PHONG { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
