USE [master]
GO
/****** Object:  Database [QLLK]    Script Date: 02/01/2017 4:34:23 PM ******/
CREATE DATABASE [QLLK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLLK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLLK.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLLK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLLK_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[BAOCAO_TONKHO]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[CT_BAOCAO_TONKHO]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[CT_HOADON]    Script Date: 02/01/2017 4:34:23 PM ******/
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
	[TinhTrang] [int] NULL,
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
/****** Object:  Table [dbo].[CT_HOADON_NHAPHANG]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[CT_KIEMKHO]    Script Date: 02/01/2017 4:34:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_KIEMKHO](
	[MaKiemKho] [varchar](10) NOT NULL,
	[MaLinhKien] [varchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_CT_KIEMKHO] PRIMARY KEY CLUSTERED 
(
	[MaKiemKho] ASC,
	[MaLinhKien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DONVITINH]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[HETHONG]    Script Date: 02/01/2017 4:34:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HETHONG](
	[Ten] [nvarchar](500) NOT NULL,
	[GiaTri] [nvarchar](500) NOT NULL,
	[Ma] [nchar](10) NOT NULL,
 CONSTRAINT [PK_HETHONG] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 02/01/2017 4:34:23 PM ******/
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
	[NgaySua] [date] NULL,
	[MaNguoiSua] [varchar](10) NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HOADON_NHAPHANG]    Script Date: 02/01/2017 4:34:23 PM ******/
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
	[NgaySua] [date] NULL,
	[MaNguoiSua] [varchar](10) NULL,
 CONSTRAINT [PK_HOADON_NHAPHANG] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[KHO]    Script Date: 02/01/2017 4:34:23 PM ******/
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
	[TrangThai] [int] NULL,
 CONSTRAINT [PK_KHO] PRIMARY KEY CLUSTERED 
(
	[MaLinhKien] ASC,
	[Seri] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KIEMKHO]    Script Date: 02/01/2017 4:34:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KIEMKHO](
	[MaKiemKho] [varchar](10) NOT NULL,
	[NgayKiem] [date] NOT NULL,
	[MaNhanVien] [varchar](10) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_KIEMKHO] PRIMARY KEY CLUSTERED 
(
	[MaKiemKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LINHKIEN]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[LOAIKHACHHANG]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[LOAINHANVIEN]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 02/01/2017 4:34:23 PM ******/
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
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 02/01/2017 4:34:23 PM ******/
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
	[TongTien] [money] NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THUONGHIEU]    Script Date: 02/01/2017 4:34:23 PM ******/
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
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD001', N'LK001', 1, 550000.0000, 550000.0000, 0, 50000.0000, N'Abc0123', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD001', N'LK002', 1, 616000.0000, 616000.0000, 0, 56000.0000, N'Def0124', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD001', N'LK002', 2, 1232000.0000, 616000.0000, 0, 112000.0000, N'Def0125', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD001', N'LK003', 3, 1980000.0000, 660000.0000, 0, 180000.0000, N'Htn001', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD001', N'LK003', 3, 1980000.0000, 660000.0000, 0, 180000.0000, N'Htn002', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD001', N'LK003', 3, 1980000.0000, 660000.0000, 0, 180000.0000, N'Htn003', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD001', N'LK003', 4, 2640000.0000, 660000.0000, 0, 240000.0000, N'Htn004', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD002', N'LK001', 1, 550000.0000, 550000.0000, 0, 50000.0000, N'Abc0123', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD003', N'LK001', 1, 525000.0000, 550000.0000, 0, 25000.0000, N'Abc0123', NULL, 0)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD004', N'LK001', 2, 1100000.0000, 550000.0000, 0, 90000.0000, N'Abc0123', NULL, 1)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD004', N'LK001', 2, 1100000.0000, 550000.0000, 0, 90000.0000, N'Abc0124', NULL, 1)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD004', N'LK002', 1, 616000.0000, 616000.0000, 0, 50400.0000, N'Def0124', NULL, 1)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD005', N'LK010', 2, 6000000.0000, 3000000.0000, 0, 5000000.0000, N'DDD001', NULL, 1)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD005', N'LK010', 2, 6000000.0000, 3000000.0000, 0, 5000000.0000, N'DDD002', NULL, 1)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD006', N'LK011', 2, 1320000.0000, 600000.0000, 10, 180000.0000, N'III0001', NULL, 1)
INSERT [dbo].[CT_HOADON] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaBan], [Thue], [LoiNhuan], [Seri], [GhiChu], [TinhTrang]) VALUES (N'HD006', N'LK011', 2, 1320000.0000, 600000.0000, 10, 180000.0000, N'III0002', NULL, 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK001', 2, 1000000.0000, 500000.0000, 0, NULL, N'Abc0123', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK001', 2, 1000000.0000, 500000.0000, 0, NULL, N'Abc0124', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK002', 3, 1680000.0000, 560000.0000, 0, NULL, N'Def0124', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK002', 3, 1680000.0000, 560000.0000, 0, NULL, N'Def0125', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK002', 3, 1680000.0000, 560000.0000, 0, NULL, N'Def0126', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK003', 5, 3000000.0000, 600000.0000, 0, NULL, N'Htn001', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK003', 5, 3000000.0000, 600000.0000, 0, NULL, N'Htn002', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK003', 5, 3000000.0000, 600000.0000, 0, NULL, N'Htn003', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK003', 5, 3000000.0000, 600000.0000, 0, NULL, N'Htn004', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD001', N'LK003', 5, 3000000.0000, 600000.0000, 0, NULL, N'Htn005', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD002', N'LK001', 5, 2500000.0000, 500000.0000, 0, NULL, N'BN001', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD002', N'LK001', 5, 2500000.0000, 500000.0000, 0, NULL, N'BN002', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD002', N'LK001', 5, 2500000.0000, 500000.0000, 0, NULL, N'BN003', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD002', N'LK001', 5, 2500000.0000, 500000.0000, 0, NULL, N'BN004', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD002', N'LK001', 5, 2500000.0000, 500000.0000, 0, NULL, N'BN005', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD003', N'LK010', 2, 1000000.0000, 500000.0000, 0, NULL, N'DDD001', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD003', N'LK010', 2, 1000000.0000, 500000.0000, 0, NULL, N'DDD002', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD004', N'LK006', 4, 800000.0000, 200000.0000, 0, NULL, N'UUU0001', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD004', N'LK006', 4, 800000.0000, 200000.0000, 0, NULL, N'UUU0002', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD004', N'LK006', 4, 800000.0000, 200000.0000, 0, NULL, N'UUU0003', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD004', N'LK006', 4, 800000.0000, 200000.0000, 0, NULL, N'UUU0004', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD005', N'LK011', 2, 1000000.0000, 500000.0000, 0, NULL, N'III0001', 1)
INSERT [dbo].[CT_HOADON_NHAPHANG] ([MaHoaDon], [MaLinhKien], [SoLuong], [ThanhTien], [GiaNhap], [Thue], [GhiChu], [Seri], [TinhTrang]) VALUES (N'HD005', N'LK011', 2, 1000000.0000, 500000.0000, 0, NULL, N'III0002', 1)
INSERT [dbo].[CT_KIEMKHO] ([MaKiemKho], [MaLinhKien], [SoLuong], [GhiChu]) VALUES (N'KK001', N'LK009', 3, NULL)
INSERT [dbo].[CT_KIEMKHO] ([MaKiemKho], [MaLinhKien], [SoLuong], [GhiChu]) VALUES (N'KK003', N'LK009', 3, NULL)
INSERT [dbo].[CT_KIEMKHO] ([MaKiemKho], [MaLinhKien], [SoLuong], [GhiChu]) VALUES (N'KK005', N'LK009', 3, NULL)
INSERT [dbo].[CT_KIEMKHO] ([MaKiemKho], [MaLinhKien], [SoLuong], [GhiChu]) VALUES (N'KK007', N'LK001', 2, NULL)
INSERT [dbo].[CT_KIEMKHO] ([MaKiemKho], [MaLinhKien], [SoLuong], [GhiChu]) VALUES (N'KK007', N'LK002', 2, N'')
INSERT [dbo].[CT_KIEMKHO] ([MaKiemKho], [MaLinhKien], [SoLuong], [GhiChu]) VALUES (N'KK009', N'LK001', 2, NULL)
INSERT [dbo].[CT_KIEMKHO] ([MaKiemKho], [MaLinhKien], [SoLuong], [GhiChu]) VALUES (N'KK009', N'LK002', 3, N'')
INSERT [dbo].[CT_KIEMKHO] ([MaKiemKho], [MaLinhKien], [SoLuong], [GhiChu]) VALUES (N'KK011', N'LK009', 4, NULL)
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh], [TrangThai], [MoTa]) VALUES (N'DVT001', N'Cái', 1, NULL)
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh], [TrangThai], [MoTa]) VALUES (N'DVT002', N'Chiếc', 1, NULL)
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh], [TrangThai], [MoTa]) VALUES (N'DVT003', N'Bộ', 1, NULL)
INSERT [dbo].[HETHONG] ([Ten], [GiaTri], [Ma]) VALUES (N'Phần trăm chiết khấu khách hàng VIP', N'10', N'HT001     ')
INSERT [dbo].[HETHONG] ([Ten], [GiaTri], [Ma]) VALUES (N'Phần trăm lợi nhuận khách hàng lẻ', N'5', N'HT002     ')
INSERT [dbo].[HETHONG] ([Ten], [GiaTri], [Ma]) VALUES (N'Phần trăm lợi nhuận khách hàng bán buôn', N'3', N'HT003     ')
INSERT [dbo].[HOADON] ([MaHoaDon], [NgayLap], [MaNguoiLap], [MaKhachHang], [TongLoiNhuan], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD001', CAST(0x423C0B00 AS Date), N'NV002', N'KH000', 0.0000, 2596000.0000, 0, N'', CAST(0x493C0B00 AS Date), N'NV002')
INSERT [dbo].[HOADON] ([MaHoaDon], [NgayLap], [MaNguoiLap], [MaKhachHang], [TongLoiNhuan], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD002', CAST(0x483C0B00 AS Date), N'NV002', N'KH000', 0.0000, 550000.0000, 0, N'', CAST(0x483C0B00 AS Date), N'NV002')
INSERT [dbo].[HOADON] ([MaHoaDon], [NgayLap], [MaNguoiLap], [MaKhachHang], [TongLoiNhuan], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD003', CAST(0x493C0B00 AS Date), N'NV002', N'KH001', 0.0000, 525000.0000, 0, N'', CAST(0x493C0B00 AS Date), N'NV002')
INSERT [dbo].[HOADON] ([MaHoaDon], [NgayLap], [MaNguoiLap], [MaKhachHang], [TongLoiNhuan], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD004', CAST(0x493C0B00 AS Date), N'NV002', N'KH002', 140400.0000, 1544400.0000, 1, N'', CAST(0x493C0B00 AS Date), N'NV002')
INSERT [dbo].[HOADON] ([MaHoaDon], [NgayLap], [MaNguoiLap], [MaKhachHang], [TongLoiNhuan], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD005', CAST(0x493C0B00 AS Date), N'NV002', N'KH000', 5000000.0000, 6000000.0000, 1, N'', CAST(0x493C0B00 AS Date), N'NV002')
INSERT [dbo].[HOADON] ([MaHoaDon], [NgayLap], [MaNguoiLap], [MaKhachHang], [TongLoiNhuan], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD006', CAST(0x493C0B00 AS Date), N'NV002', N'KH002', 180000.0000, 1188000.0000, 1, N'', CAST(0x493C0B00 AS Date), N'NV002')
INSERT [dbo].[HOADON_NHAPHANG] ([MaHoaDon], [MaNhaCungCap], [NgayLap], [MaNguoiLap], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD001', N'CC001', CAST(0x423C0B00 AS Date), N'NV002', 5680000.0000, 1, N'', NULL, NULL)
INSERT [dbo].[HOADON_NHAPHANG] ([MaHoaDon], [MaNhaCungCap], [NgayLap], [MaNguoiLap], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD002', N'CC001', CAST(0x463C0B00 AS Date), N'NV002', 2500000.0000, 1, N'', NULL, NULL)
INSERT [dbo].[HOADON_NHAPHANG] ([MaHoaDon], [MaNhaCungCap], [NgayLap], [MaNguoiLap], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD003', N'CC002', CAST(0x493C0B00 AS Date), N'NV002', 1000000.0000, 1, N'', NULL, NULL)
INSERT [dbo].[HOADON_NHAPHANG] ([MaHoaDon], [MaNhaCungCap], [NgayLap], [MaNguoiLap], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD004', N'CC002', CAST(0x493C0B00 AS Date), N'NV002', 800000.0000, 1, N'', NULL, NULL)
INSERT [dbo].[HOADON_NHAPHANG] ([MaHoaDon], [MaNhaCungCap], [NgayLap], [MaNguoiLap], [TongTien], [TrangThai], [GhiChu], [NgaySua], [MaNguoiSua]) VALUES (N'HD005', N'CC001', CAST(0x493C0B00 AS Date), N'NV002', 1000000.0000, 1, N'', NULL, NULL)
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [GhiChu], [TrangThai], [MaLoai], [Tong]) VALUES (N'KH000', N'Khách Mua Lẻ', N'', N'', NULL, 1, N'L001', 6000000.0000)
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [GhiChu], [TrangThai], [MaLoai], [Tong]) VALUES (N'KH001', N'Nguyễn Văn Toàn', N'01345-454-543', N'Tp HCM', N'', 1, N'L002', 0.0000)
INSERT [dbo].[KHACHHANG] ([MaKhachHang], [TenKhachHang], [SoDienThoai], [DiaChi], [GhiChu], [TrangThai], [MaLoai], [Tong]) VALUES (N'KH002', N'So Tuan Hoang', N'04234-234-344', N'Binh Duong', N'', 1, N'L003', 2732400.0000)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK001', N'Abc0123', CAST(0x423C0B00 AS Date), 0)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK001', N'Abc0124', CAST(0x423C0B00 AS Date), 0)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK001', N'BN001', CAST(0x463C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK001', N'BN002', CAST(0x463C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK001', N'BN003', CAST(0x463C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK001', N'BN004', CAST(0x463C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK001', N'BN005', CAST(0x463C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK002', N'Def0124', CAST(0x423C0B00 AS Date), 0)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK002', N'Def0125', CAST(0x423C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK002', N'Def0126', CAST(0x423C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK003', N'Htn001', CAST(0x423C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK003', N'Htn002', CAST(0x423C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK003', N'Htn003', CAST(0x423C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK003', N'Htn004', CAST(0x423C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK003', N'Htn005', CAST(0x423C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK006', N'UUU0001', CAST(0x493C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK006', N'UUU0002', CAST(0x493C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK006', N'UUU0003', CAST(0x493C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK006', N'UUU0004', CAST(0x493C0B00 AS Date), 1)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK010', N'DDD001', CAST(0x493C0B00 AS Date), 0)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK010', N'DDD002', CAST(0x493C0B00 AS Date), 0)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK011', N'III0001', CAST(0x493C0B00 AS Date), 0)
INSERT [dbo].[KHO] ([MaLinhKien], [Seri], [NgayNhap], [TrangThai]) VALUES (N'LK011', N'III0002', CAST(0x493C0B00 AS Date), 0)
INSERT [dbo].[KIEMKHO] ([MaKiemKho], [NgayKiem], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'KK001', CAST(0x413C0B00 AS Date), N'NV002', NULL, 1)
INSERT [dbo].[KIEMKHO] ([MaKiemKho], [NgayKiem], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'KK003', CAST(0x413C0B00 AS Date), N'NV002', NULL, 1)
INSERT [dbo].[KIEMKHO] ([MaKiemKho], [NgayKiem], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'KK005', CAST(0x413C0B00 AS Date), N'NV002', NULL, 1)
INSERT [dbo].[KIEMKHO] ([MaKiemKho], [NgayKiem], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'KK007', CAST(0x413C0B00 AS Date), N'NV002', NULL, 1)
INSERT [dbo].[KIEMKHO] ([MaKiemKho], [NgayKiem], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'KK009', CAST(0x413C0B00 AS Date), N'NV002', NULL, 1)
INSERT [dbo].[KIEMKHO] ([MaKiemKho], [NgayKiem], [MaNhanVien], [GhiChu], [TrangThai]) VALUES (N'KK011', CAST(0x413C0B00 AS Date), N'NV002', NULL, 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK001', N'APPLE', N'CC001', N'Tai nghe IP', N'DVT001', 12, 500000.0000, 525000.0000, 550000.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK002', N'APPLE', N'CC001', N'Màn Hình IP', N'DVT001', 12, 560000.0000, 588000.0000, 616000.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK003', N'APPLE', N'CC002', N'Chip cảm ứng IP', N'DVT001', 6, 600000.0000, 630000.0000, 660000.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK004', N'APPLE', N'CC003', N'Loa IP', N'DVT001', 6, 0.0000, 0.0000, 0.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK006', N'APPLE', N'CC002', N'Main IP', N'DVT003', 6, 200000.0000, 206000.0000, 210000.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK007', N'APPLE', N'CC001', N'Nút nguồn IP', N'DVT001', 6, 0.0000, 0.0000, 0.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK008', N'APPLE', N'CC001', N'Pin IP', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK009', N'SONY', N'CC004', N'Màn hình Sony', N'DVT001', 6, 450000.0000, 480000.0000, 490000.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK010', N'APPLE', N'CC002', N'Dây Nguồn IP', N'DVT001', 6, 500000.0000, 2000000.0000, 3000000.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK011', N'LG', N'CC001', N'Màn Hình LG', N'DVT001', 12, 500000.0000, 550000.0000, 600000.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK012', N'LG', N'CC005', N'Pin LG', N'DVT001', 6, 400000.0000, 0.0000, 0.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK013', N'LG', N'CC005', N'Cảm ứng LG', N'DVT001', 12, 600000.0000, 0.0000, 0.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK014', N'SONY', N'CC004', N'Màn hình cảm ứng Sony', N'DVT001', 18, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK015', N'SONY', N'CC004', N'Tai nghe Sony', N'DVT001', 18, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK016', N'APPLE', N'CC003', N'Củ sac IP', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK017', N'APPLE', N'CC003', N'Dây sạc IP', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK018', N'SONY', N'CC005', N'Doc sạc Sony', N'DVT003', 18, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK019', N'OPPO', N'CC007', N'Màn hình Oppo', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK020', N'SONY', N'CC003', N'Main Sony', N'DVT003', 12, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK021', N'SONY', N'CC006', N'Ốp lưng Sony', N'DVT002', 6, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK022', N'SAMSUNG', N'CC008', N'Main SamSung J5', N'DVT003', 12, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK023', N'SAMSUNG', N'CC009', N'Màn hình Samsung Note 5', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK024', N'MOBELL', N'CC008', N'Main Mobell', N'DVT003', 6, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK025', N'VIVO', N'CC009', N'Main Vivo', N'DVT003', 12, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK026', N'ASUS', N'CC004', N'Main Asus', N'DVT003', 12, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK027', N'GIONEE', N'CC008', N'Màn hình Gionee', N'DVT001', 6, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK028', N'HUEWEI', N'CC009', N'Pin Huewei', N'DVT001', 6, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK029', N'PHILIPS', N'CC006', N'Camera Philips', N'DVT001', 6, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK030', N'HTC', N'CC002', N'Main HTC', N'DVT003', 12, 0.0000, 0.0000, 0.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK031', N'XIAOMI', N'CC005', N'Màn hình XiaoMi Red5', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK032', N'BLACKBERRY', N'CC008', N'Vỏ BlackBerry', N'DVT001', 3, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK033', N'LENOVO', N'CC001', N'Màn hình Lenovo', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK034', N'VIVO', N'CC003', N'Pin Vivo', N'DVT001', 6, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK035', N'NOKIA', N'CC004', N'Camera Nokia', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Xách tay', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK036', N'LENOVO', N'CC004', N'Main Lenovo', N'DVT003', 12, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK037', N'OPPO', N'CC007', N'Main Oppo', N'DVT003', 18, 0.0000, 0.0000, 0.0000, N'Chính hãng', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK038', N'GIONEE', N'CC006', N'Pin Gionee', N'DVT001', 6, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK039', N'HUEWEI', N'CC005', N'Màn hình Huewei', N'DVT001', 12, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LINHKIEN] ([MaLinhKien], [MaThuongHieu], [MaNhaCungCap], [TenLinhKien], [MaDonViTinh], [ThoiGianBaoHanh], [GiaNhap], [GiaBanSi], [GiaBanLe], [MoTa], [TinhTrang]) VALUES (N'LK040', N'XIAOMI', N'CC008', N'Pin XiaoMi', N'DVT001', 6, 0.0000, 0.0000, 0.0000, N'Giá tốt', 1)
INSERT [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang], [TenLoaiKhachHang], [MoTa]) VALUES (N'L001', N'Khách Lẻ', NULL)
INSERT [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang], [TenLoaiKhachHang], [MoTa]) VALUES (N'L002', N'Khách Bán Buôn', NULL)
INSERT [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang], [TenLoaiKhachHang], [MoTa]) VALUES (N'L003', N'Khách VIP', NULL)
INSERT [dbo].[LOAIKHACHHANG] ([MaLoaiKhachHang], [TenLoaiKhachHang], [MoTa]) VALUES (N'L004', N'Khách Quen', NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L001', N'Admin', 1, 1, 1, 1, 1, 1, NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L002', N'Nhân Viên Kế Toán', 0, 0, 0, 0, 0, 0, NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L003', N'Nhân Viên Kho', 0, 0, 0, 1, 0, 0, NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L004', N'Nhân Viên Bán Hàng', 0, 0, 0, 0, 0, 1, NULL)
INSERT [dbo].[LOAINHANVIEN] ([MaLoaiNhanVien], [TenLoaiNhanVien], [IsQuanLyNhanVien], [IsQuanLyKhachHang], [IsQuanLyLinhKien], [IsQuanLyKho], [IsQuanLyHeThong], [IsQuanLyBanHang], [MoTa]) VALUES (N'L005', N'Nhân Viên Quản lý', 1, 1, 1, 0, 0, 0, NULL)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC001', N'Nguyễn Kim', N'HCMC', N'01252422452', 1, NULL, 9180000.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC002', N'Siêu Thị Điện Máy', N'Đồng Nai', N'01323232423', 1, NULL, 1800000.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC003', N'Thế Giới Di Động', N'Bình Dương', N'01212121212', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC004', N'FPT Shop', N'HCMC', N'01655656565', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC005', N'Chợ Lớn', N'HCMC', N'0123423423', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC006', N'Bách Khoa', N'HCMC', N'0987678909', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC007', N'OPPO', N'Hà Nội', N'0973424323', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC008', N'Nhật Tảo', N'HCMC', N'0834736873', 1, NULL, 0.0000)
INSERT [dbo].[NHACUNGCAP] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [SoDienThoai], [TrangThai], [MoTa], [Tong]) VALUES (N'CC009', N'Linh Kiện Sỉ', N'Đà Nẵng', N'0933492742', 1, NULL, 0.0000)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai], [TongTien]) VALUES (N'NV001', N'Nguyễn Thanh Cao', N'caont', N'caont', N'0986807296', N'L001', N'hcm', NULL, 1, 0.0000)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai], [TongTien]) VALUES (N'NV002', N'Nguyễn Văn Hùng', N'hungnv', N'hungnv', N'01245356880', N'L001', N'hcm', NULL, 1, 6136400.0000)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai], [TongTien]) VALUES (N'NV003', N'Nguyễn Tuấn Đạt', N'datnt', N'datnt', N'0168828296', N'L001', N'hcm', NULL, 1, 0.0000)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai], [TongTien]) VALUES (N'NV004', N'Cao Văn Thuấn', N'thuancv', N'thuancv', N'0124665666', N'L001', N'hcm', NULL, 1, 0.0000)
INSERT [dbo].[NHANVIEN] ([MaNhanVien], [TenNhanVien], [TenDangNhap], [MatKhau], [SoDienThoai], [MaLoai], [DiaChi], [GhiChu], [TrangThai], [TongTien]) VALUES (N'NV005', N'Tran Van Dung', N'NV005', N'123', N'9823472', N'L002', N'Binh Duong', NULL, 1, 0.0000)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'APPLE', N'Apple', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'ASUS', N'Asus', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'BLACKBERRY', N'Black Berry', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'GIONEE', N'Gionee', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'HTC', N'HTC', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'HUEWEI', N'Huewei', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'LENOVO', N'Lenovo', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'LG', N'GL', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'MOBELL', N'Mobell', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'NOKIA', N'Nokia', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'OPPO', N'Oppo', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'PHILIPS', N'Philips', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'SAMSUNG', N'SamSung', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'SONY', N'Sony', 1, NULL)
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'VIVO', N'ViVo', 1, N'LK tốt')
INSERT [dbo].[THUONGHIEU] ([MaThuongHieu], [TenThuongHieu], [TrangThai], [MoTa]) VALUES (N'XIAOMI', N'XiaoMi', 1, NULL)
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
ALTER TABLE [dbo].[CT_KIEMKHO]  WITH CHECK ADD  CONSTRAINT [FK_CT_KIEMKHO_KIEMKHO] FOREIGN KEY([MaKiemKho])
REFERENCES [dbo].[KIEMKHO] ([MaKiemKho])
GO
ALTER TABLE [dbo].[CT_KIEMKHO] CHECK CONSTRAINT [FK_CT_KIEMKHO_KIEMKHO]
GO
ALTER TABLE [dbo].[CT_KIEMKHO]  WITH CHECK ADD  CONSTRAINT [FK_CT_KIEMKHO_LINHKIEN] FOREIGN KEY([MaLinhKien])
REFERENCES [dbo].[LINHKIEN] ([MaLinhKien])
GO
ALTER TABLE [dbo].[CT_KIEMKHO] CHECK CONSTRAINT [FK_CT_KIEMKHO_LINHKIEN]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KHACHHANG] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KHACHHANG] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_KHACHHANG]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NGUOISUA_NHANVIEN] FOREIGN KEY([MaNguoiSua])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NGUOISUA_NHANVIEN]
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
ALTER TABLE [dbo].[HOADON_NHAPHANG]  WITH CHECK ADD  CONSTRAINT [FK_HOADONNH_NGUOISUA_NHANVIEN] FOREIGN KEY([MaNguoiSua])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HOADON_NHAPHANG] CHECK CONSTRAINT [FK_HOADONNH_NGUOISUA_NHANVIEN]
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
ALTER TABLE [dbo].[KIEMKHO]  WITH CHECK ADD  CONSTRAINT [FK_KIEMKHO_NHANVIEN] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNhanVien])
GO
ALTER TABLE [dbo].[KIEMKHO] CHECK CONSTRAINT [FK_KIEMKHO_NHANVIEN]
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
