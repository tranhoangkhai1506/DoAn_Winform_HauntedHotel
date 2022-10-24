USE [QUANLYKHACHSAN]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 15/10/2022 12:19:42 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[maHoaDon] [nvarchar](50) NOT NULL,
	[maPhieuThue] [nvarchar](50) NULL,
	[maNhanVien] [nvarchar](50) NULL,
	[ngayThanhToan] [datetime] NULL,
	[thanhTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[maHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 15/10/2022 12:19:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[maKhachHang] [nvarchar](50) NOT NULL,
	[tenKhachHang] [nvarchar](50) NULL,
	[gioiTinh] [nvarchar](50) NULL,
	[soCCCD] [nvarchar](50) NULL,
	[diaChi] [nvarchar](50) NULL,
	[soDienThoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIPHONG]    Script Date: 15/10/2022 12:19:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIPHONG](
	[maLoai] [nvarchar](50) NOT NULL,
	[tenLoai] [nvarchar](50) NULL,
	[giaThue] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[maLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 15/10/2022 12:19:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[maNhanVien] [nvarchar](50) NOT NULL,
	[tenNhanVien] [nvarchar](50) NULL,
	[gioiTinh] [nvarchar](50) NULL,
	[soCCCD] [nvarchar](50) NULL,
	[diaChi] [nvarchar](50) NULL,
	[soDienThoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 15/10/2022 12:19:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[maQuyen] [nvarchar](50) NOT NULL,
	[tenQuyen] [nvarchar](50) NULL,
	[quyenHan] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[maQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUTHUEPHONG]    Script Date: 15/10/2022 12:19:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUTHUEPHONG](
	[maPhieuThue] [nvarchar](50) NOT NULL,
	[maPhong] [nvarchar](50) NULL,
	[maKhachHang] [nvarchar](50) NULL,
	[maNhanVien] [nvarchar](50) NULL,
	[soNguoi] [int] NULL,
	[ngayDen] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhieuThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG]    Script Date: 15/10/2022 12:19:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG](
	[maPhong] [nvarchar](50) NOT NULL,
	[tenPhong] [nvarchar](50) NULL,
	[maLoai] [nvarchar](50) NULL,
	[soKhachToiDa] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 15/10/2022 12:19:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[tenDangNhap] [nvarchar](50) NOT NULL,
	[matKhau] [nvarchar](50) NULL,
	[maNhanVien] [nvarchar](50) NULL,
	[maQuyen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[tenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NHANVIEN] ([maNhanVien])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([maPhieuThue])
REFERENCES [dbo].[PHIEUTHUEPHONG] ([maPhieuThue])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PHIEUTHUEPHONG]  WITH CHECK ADD FOREIGN KEY([maKhachHang])
REFERENCES [dbo].[KHACHHANG] ([maKhachHang])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PHIEUTHUEPHONG]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NHANVIEN] ([maNhanVien])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PHIEUTHUEPHONG]  WITH CHECK ADD FOREIGN KEY([maPhong])
REFERENCES [dbo].[PHONG] ([maPhong])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[PHONG]  WITH CHECK ADD FOREIGN KEY([maLoai])
REFERENCES [dbo].[LOAIPHONG] ([maLoai])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD FOREIGN KEY([maNhanVien])
REFERENCES [dbo].[NHANVIEN] ([maNhanVien])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD FOREIGN KEY([maQuyen])
REFERENCES [dbo].[PHANQUYEN] ([maQuyen])
ON UPDATE CASCADE
GO
