USE [master]
GO
/****** Object:  Database [QLLK]    Script Date: 12/15/2016 3:13:46 PM ******/
CREATE DATABASE [QLLK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLLK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLLK.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLLK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLLK_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLLK] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLLK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLLK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLLK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLLK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLLK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLLK] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLLK] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLLK] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLLK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLLK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLLK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLLK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLLK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLLK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLLK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLLK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLLK] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLLK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLLK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLLK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLLK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLLK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLLK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLLK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLLK] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLLK] SET  MULTI_USER 
GO
ALTER DATABASE [QLLK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLLK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLLK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLLK] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLLK]
GO
/****** Object:  Table [dbo].[BAOCAO_TONKHO]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BAOCAO_TONKHO](
	[MaBaoCao] [varchar](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[NguoiLap] [varchar](10) NOT NULL,
	[TrangThai] [int] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_BAOCAO_TONKHO] PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_BAOCAO_TONKHO]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_BAOCAO_TONKHO](
	[MaBaoCao] [varchar](10) NOT NULL,
	[MaLinhKien] [varchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [money] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC,
	[MaLinhKien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_HOADON]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_HOADON](
	[MaHoaDon] [varchar](10) NOT NULL,
	[MaLinhKien] [varchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [money] NOT NULL,
	[GiaBan] [money] NOT NULL,
	[Thue] [float] NOT NULL,
	[LoiNhuan] [money] NOT NULL,
	[Seri] [varchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaLinhKien] ASC,
	[Seri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_HOADON_NHAPHANG]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_HOADON_NHAPHANG](
	[MaHoaDon] [varchar](10) NOT NULL,
	[MaLinhKien] [varchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[ThanhTien] [money] NOT NULL,
	[GiaNhap] [money] NOT NULL,
	[Thue] [float] NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
	[Seri] [varchar](50) NOT NULL,
	[TinhTrang] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaLinhKien] ASC,
	[Seri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DONVITINH]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DONVITINH](
	[MaDonViTinh] [varchar](10) NOT NULL,
	[TenDonViTinh] [nvarchar](50) NOT NULL,
	[TrangThai] [int] NOT NULL,
	[MoTa] [nvarchar](50) NULL,
 CONSTRAINT [PK_DONVITINH] PRIMARY KEY CLUSTERED 
(
	[MaDonViTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HETHONG]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HETHONG](
	[Ten] [varchar](10) NOT NULL,
	[GiaTri] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADON](
	[MaHoaDon] [varchar](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[MaNguoiLap] [varchar](10) NOT NULL,
	[MaKhachHang] [varchar](10) NOT NULL,
	[TongLoiNhuan] [money] NOT NULL,
	[TongTien] [money] NOT NULL,
	[TrangThai] [int] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADON_NHAPHANG]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HOADON_NHAPHANG](
	[MaHoaDon] [varchar](10) NOT NULL,
	[MaNhaCungCap] [varchar](10) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[MaNguoiLap] [varchar](10) NOT NULL,
	[TongTien] [money] NOT NULL,
	[TrangThai] [int] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_HOADON_NHAPHANG] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKhachHang] [varchar](10) NOT NULL,
	[TenKhachHang] [nvarchar](200) NOT NULL,
	[SoDienThoai] [varchar](20) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[GhiChu] [nvarchar](200) NULL,
	[TrangThai] [int] NULL,
	[MaLoai] [varchar](50) NOT NULL,
	[Tong] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHO]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHO](
	[MaLinhKien] [varchar](10) NOT NULL,
	[Seri] [varchar](50) NOT NULL,
	[NgayNhap] [date] NOT NULL,
 CONSTRAINT [PK_KHO] PRIMARY KEY CLUSTERED 
(
	[MaLinhKien] ASC,
	[Seri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LINHKIEN]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LINHKIEN](
	[MaLinhKien] [varchar](10) NOT NULL,
	[MaThuongHieu] [varchar](10) NOT NULL,
	[MaNhaCungCap] [varchar](10) NOT NULL,
	[TenLinhKien] [nvarchar](50) NOT NULL,
	[MaDonViTinh] [varchar](10) NOT NULL,
	[ThoiGianBaoHanh] [int] NOT NULL,
	[GiaNhap] [money] NOT NULL,
	[GiaBanSi] [money] NOT NULL,
	[GiaBanLe] [money] NOT NULL,
	[MoTa] [nvarchar](50) NULL,
	[TinhTrang] [int] NOT NULL,
 CONSTRAINT [PK_LINHKIEN] PRIMARY KEY CLUSTERED 
(
	[MaLinhKien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAIKHACHHANG]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAIKHACHHANG](
	[MaLoaiKhachHang] [varchar](50) NOT NULL,
	[TenLoaiKhachHang] [nvarchar](50) NOT NULL,
	[MoTa] [nchar](10) NULL,
 CONSTRAINT [PK_LOAI] PRIMARY KEY CLUSTERED 
(
	[MaLoaiKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOAINHANVIEN]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOAINHANVIEN](
	[MaLoaiNhanVien] [varchar](50) NOT NULL,
	[TenLoaiNhanVien] [nvarchar](50) NOT NULL,
	[IsQuanLyNhanVien] [int] NOT NULL,
	[IsQuanLyKhachHang] [int] NOT NULL,
	[IsQuanLyLinhKien] [int] NOT NULL,
	[IsQuanLyKho] [int] NOT NULL,
	[IsQuanLyHeThong] [int] NOT NULL,
	[IsQuanLyBanHang] [int] NOT NULL,
	[MoTa] [nchar](10) NULL,
 CONSTRAINT [PK_LOAINV] PRIMARY KEY CLUSTERED 
(
	[MaLoaiNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MaNhaCungCap] [varchar](10) NOT NULL,
	[TenNhaCungCap] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[TrangThai] [int] NOT NULL,
	[MoTa] [nvarchar](50) NULL,
	[Tong] [money] NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNhanVien] [varchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[TenDangNhap] [varchar](10) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[SoDienThoai] [varchar](50) NULL,
	[MaLoai] [varchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THUONGHIEU]    Script Date: 12/15/2016 3:13:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THUONGHIEU](
	[MaThuongHieu] [varchar](10) NOT NULL,
	[TenThuongHieu] [nvarchar](50) NOT NULL,
	[TrangThai] [int] NOT NULL,
	[MoTa] [nvarchar](50) NULL,
 CONSTRAINT [PK_THUONGHIEU] PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh], [TrangThai], [MoTa]) VALUES (N'DVT001', N'Cái', 1, NULL)
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh], [TrangThai], [MoTa]) VALUES (N'DVT002', N'Chiếc', 1, NULL)
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh], [TrangThai], [MoTa]) VALUES (N'DVT003', N'Bộ', 1, NULL)
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [GhiChu], [TrangThai], [MaLoai], [Tong]) VALUES (N'KH000', N'Khách Mua Lẻ', N'', N'', NULL, 1, N'L001', 0.0000)
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [GhiChu], [TrangThai], [MaLoai], [Tong]) VALUES (N'KH001', N'Nguyễn Văn Toàn', N'01345-454-543', N'Tp HCM', N'', 1, N'L002', 2100000.0000)

INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK001', N'APPLE', N'CC001', N'Tai nghe IP', N'DVT001', 12, 200000.0000, 210000.0000, 220000.0000, NULL, 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK002', N'APPLE', N'CC001', N'Man Hinh IP', N'DVT001', 12, 500000.0000, 525000.0000, 550000.0000, N'', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK003', N'APPLE', N'CC002', N'Chip cam ung IP', N'DVT001', 6, 0.0000, 0.0000, 0.0000, NULL, 0)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK004', N'APPLE', N'CC003', N'Loa Ip', N'DVT001', 6, 0.0000, 0.0000, 0.0000, NULL, 0)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK006', N'APPLE', N'CC002', N'Chip loa ip', N'DVT001', 6, 0.0000, 0.0000, 0.0000, NULL, 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK007', N'APPLE', N'CC001', N'Chip cam ung ip', N'DVT001', 6, 0.0000, 0.0000, 0.0000, NULL, 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK008', N'APPLE', N'CC001', N'Chip Cam Ung IP', N'DVT001', 12, 0.0000, 0.0000, 0.0000, NULL, 1)
INSERT [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang], [TenLoaiKhachHang], [MoTa]) VALUES (N'L001', N'Khách Lẻ', NULL)
INSERT [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang], [TenLoaiKhachHang], [MoTa]) VALUES (N'L002', N'Khách Bán Buôn', NULL)
INSERT [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang], [TenLoaiKhachHang], [MoTa]) VALUES (N'L003', N'Khách VIP', NULL)
INSERT [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang], [TenLoaiKhachHang], [MoTa]) VALUES (N'L004', N'Khách Quen', NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L001', N'Admin', 1, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L002', N'Nhân Viên Kế Toán', 0, 0, 0, 0, 0, 0, NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L003', N'Nhân Viên Kho', 0, 0, 0, 0, 0, 0, NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L004', N'Nhân Viên Bán Hàng', 0, 0, 0, 0, 0, 0, NULL)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC001', N'Nguyễn Kim', N'hcm', N'0125242245', 1, NULL, 3400000.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC002', N'Siêu Thị Điện Máy', N'Đồng Nai', N'13232324234', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC003', N'Thế Giới Di Động', N'Bình Dương', N'1212121212', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC004', N'FPT Shop', N'hcm', N'16556565656', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC005', N'dfasdf', N'fasdf', N'234234234', 1, NULL, 0.0000)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai]) VALUES (N'NV001', N'Nguyễn Thanh Cao', N'caont', N'caont', N'0986807296', N'L001', N'hcm', NULL, 1)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai]) VALUES (N'NV002', N'Nguyễn Văn Hùng', N'hungnv', N'hungnv', N'0124535688', N'L001', N'hcm', NULL, 1)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai]) VALUES (N'NV003', N'Nguyễn Tuấn Đạt', N'datnt', N'datnt', N'0168828296', N'L001', N'hcm', NULL, 1)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai]) VALUES (N'NV004', N'Cao Văn Thuấn', N'thuancv', N'thuancv', N'0124665666', N'L001', N'hcm', NULL, 1)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'APPLE', N'Apple', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'LG', N'GL', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'NOKIA', N'Nokia', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'SAMSUNG', N'SamSung', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'SONY', N'Sony', 1, NULL)
ALTER TABLE [dbo].[CT_HOADON]  WITH CHECK ADD  CONSTRAINT [FK_CT_HOADON_LINHKIEN] FOREIGN KEY([MaLinhKien])
REFERENCES [dbo].[LINHKIEN] ([MaLinhKien])
GO
ALTER TABLE [dbo].[CT_HOADON] CHECK CONSTRAINT [FK_CT_HOADON_LINHKIEN]
GO
ALTER TABLE [dbo].[CT_HOADON_NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_CT_HOADON_HOADON_NHAPHANG] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HOADON_NHAPHANG] ([MaHoaDon])
GO
ALTER TABLE [dbo].[CT_HOADON_NHAPHANG] CHECK CONSTRAINT [FK_CT_HOADON_HOADON_NHAPHANG]
GO
ALTER TABLE [dbo].[CT_HOADON_NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_CT_HOADON_NHAPHANG_LINHKIEN] FOREIGN KEY([MaLinhKien])
REFERENCES [dbo].[LINHKIEN] ([MaLinhKien])
GO
ALTER TABLE [dbo].[CT_HOADON_NHAPHANG] CHECK CONSTRAINT [FK_CT_HOADON_NHAPHANG_LINHKIEN]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHACHHANG] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KHACHHANG] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_KHACHHANG]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHANVIEN] FOREIGN KEY([MaNguoiLap])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NHANVIEN]
GO
ALTER TABLE [dbo].[HOADON_NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHAPHANG_NHACUNGCAP] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NHACUNGCAP] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[HOADON_NHAPHANG] CHECK CONSTRAINT [FK_HOADON_NHAPHANG_NHACUNGCAP]
GO
ALTER TABLE [dbo].[HOADON_NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NHAPHANG_NHANVIEN] FOREIGN KEY([MaNguoiLap])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HOADON_NHAPHANG] CHECK CONSTRAINT [FK_HOADON_NHAPHANG_NHANVIEN]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [FK_KHACHHANG_LOAIKHACHHANG] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang])
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [FK_KHACHHANG_LOAIKHACHHANG]
GO
ALTER TABLE [dbo].[KHO]  WITH CHECK ADD  CONSTRAINT [FK_KHO_LINHKIEN] FOREIGN KEY([MaLinhKien])
REFERENCES [dbo].[LINHKIEN] ([MaLinhKien])
GO
ALTER TABLE [dbo].[KHO] CHECK CONSTRAINT [FK_KHO_LINHKIEN]
GO
ALTER TABLE [dbo].[LINHKIEN]  WITH CHECK ADD  CONSTRAINT [FK_LINHKIEN_DONVITINH] FOREIGN KEY([MaDonViTinh])
REFERENCES [dbo].[DONVITINH] ([MaDonViTinh])
GO
ALTER TABLE [dbo].[LINHKIEN] CHECK CONSTRAINT [FK_LINHKIEN_DONVITINH]
GO
ALTER TABLE [dbo].[LINHKIEN]  WITH CHECK ADD  CONSTRAINT [FK_LINHKIEN_NHACUNGCAP] FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NHACUNGCAP] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[LINHKIEN] CHECK CONSTRAINT [FK_LINHKIEN_NHACUNGCAP]
GO
ALTER TABLE [dbo].[LINHKIEN]  WITH CHECK ADD  CONSTRAINT [FK_LINHKIEN_THUONGHIEU] FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[THUONGHIEU] ([MaThuongHieu])
GO
ALTER TABLE [dbo].[LINHKIEN] CHECK CONSTRAINT [FK_LINHKIEN_THUONGHIEU]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_LOAINHANVIEN] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_LOAINHANVIEN]
GO
USE [master]
GO
ALTER DATABASE [QLLK] SET  READ_WRITE 
GO
