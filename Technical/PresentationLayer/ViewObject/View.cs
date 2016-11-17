using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.View
{
    public class KhachHang_View : CGrid
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string TenLoaiKhachHang { get; set; }
        public string MaLoaiKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }

        public override String ToString()
        {
           return TenKhachHang.Trim() + "   (" + MaKhachHang.Trim() + ")";
        }

        public KhachHang_View():base()
        {
            MaKhachHang = KhachHang_DAL.get_KhachHangMax();
        }

        public KHACHHANG toKhachHang()
        {
            KHACHHANG kh = Context.getInstance().db.KHACHHANGs.Where(key => key.MaKhachHang == MaKhachHang).FirstOrDefault();
            if (kh==null)
            {
                kh = new KHACHHANG();
                kh.MaKhachHang = MaKhachHang;
            }
            kh.TenKhachHang = TenKhachHang;
            kh.MaLoai = MaLoaiKhachHang;
            kh.SoDienThoai = SoDienThoai;
            kh.DiaChi = DiaChi;
            kh.GhiChu = GhiChu;
            return kh;
        }
    }

    public class LoaiKhachHang_View
    {
        [IdSelection]
        public string MaLoai { get; set; }
        [DisplaySelection("Loại Khách Hàng")]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }

    }

    public class Kho_View
    {
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public int SoLuong { get; set; }
        public string ThuongHieu { get; set; }
        public string NhaCungCap { get; set; }
        public Decimal GiaBanSi { get; set; }
        public Decimal GiaBanLe { get; set; }
        public string DonViTinh { get; set; }
        public int TinhTrangLK { get; set; }
        public string MoTaLK { get; set; }
        public string ThoiGianBaoHanh { get; set; }
    }

    public class NguoiDung_View
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
    }

    public class HoaDon_View
    {
        public string MaHoaDon { get; set; }
        public string MaPhieu { get; set; }
        public DateTime NgayLap { get; set; }
        public string  MaNhanVien { get; set; }
        public string NhanVien { get; set; }
        public Decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public string KhachHang { get; set; }
        public string MaKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string GhiChu { get; set; }
        public List<CT_HoaDon_View> list_CT_HoaDon { get; set; }

        public HOADON toHoaDon()
        {
            HOADON hd = Context.getInstance().db.HOADONs.Where(key => key.MaHoaDon == MaHoaDon).FirstOrDefault();
            if (hd == null)
            {
                hd = new HOADON();
                hd.MaHoaDon = MaHoaDon;
            }
            hd.MaPhieu = "maphieu";
            hd.NgayLap = NgayLap;
            hd.MaNguoiLap = MaNhanVien;
            hd.TongTien = TongTien;
            hd.GhiChu = GhiChu;
            hd.MaKhachHang = MaKhachHang;

            return hd;
        }
    }

    public class CT_HoaDon_View
    {
        public string MaHoaDon { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string LoaiLinhLien { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public Decimal GiaBan { get; set; }
        public Decimal ThanhTien { get; set; }
        public string GhiChu { get; set; }
        public int SoLuong_TrongKho { get; set; }

        public CT_HOADON toCT_HoaDon()
        {
            CT_HOADON cthd = new CT_HOADON();
            cthd.MaHoaDon = MaHoaDon;
            cthd.MaLinhKien = MaLinhKien;
            cthd.SoLuong = SoLuong;
            cthd.ThanhTien = ThanhTien;
            cthd.GhiChu = GhiChu;

            return cthd;
        }
    }

    public class LinhKien_View : CGrid
    {
        public string MaLinhKien { get; set; }
        public string TenThuongHieu { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DonViTinh { get; set; }
        public string TenLinhKien { get; set; }
        public string GiaNhap { get; set; }
        public Decimal  GiaBanSi { get; set; }
        public Decimal GiaBanLe { get; set; }
        public int TinhTrang { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public LINHKIEN toLinhKien()
        {
            LINHKIEN lk = new LINHKIEN();
            lk.MaLinhKien = MaLinhKien;
            lk.TenLinhKien = TenLinhKien;
            lk.MaNhaCungCap = TenNhaCungCap;
            lk.MaThuongHieu = TenThuongHieu;
            lk.MaDonViTinh = DonViTinh;
            lk.GiaBanSi = GiaBanSi;
            lk.GiaBanLe = GiaBanLe;
            lk.TinhTrang = TinhTrang;
            lk.ThoiGianBaoHanh = ThoiGianBaoHanh;
            
            return lk;
        }
    }

    public class NhaCungCap_View : CGrid
    {
        [IdSelection]
        public string MaNhaCungCap { get; set; }
        [DisplaySelection("Nhà Cung Cấp")]
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string MoTa { get; set; }

        public int TrangThai { get; set; }

        public NhaCungCap_View() : base()
        {
            MaNhaCungCap = NhaCungCap_DAL.get_NCCMax();
        }

        public NHACUNGCAP toNhaCungCap()
        {
            NHACUNGCAP ncc = Context.getInstance().db.NHACUNGCAPs.Where(key => key.MaNhaCungCap == MaNhaCungCap).FirstOrDefault();
            if (ncc == null)
            {
                ncc = new NHACUNGCAP();
                ncc.MaNhaCungCap = MaNhaCungCap;
            }
            ncc.MaNhaCungCap = MaNhaCungCap;
            ncc.TenNhaCungCap = TenNhaCungCap;
            ncc.DiaChi = DiaChi;
            ncc.SoDienThoai = SoDienThoai;
            ncc.MoTa = MoTa;
            ncc.TrangThai = TrangThai;
            return ncc;
        }
    }

    public class ThuongHieu_View
    {
        [IdSelection]
        public string MaThuongHieu { get; set; }
        [DisplaySelection("Thương Hiệu")]
        public string TenThuongHieu { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public THUONGHIEU toTHUONG_HIEU()
        {
            THUONGHIEU table = new THUONGHIEU();
            table.MaThuongHieu = MaThuongHieu;
            table.TenThuongHieu = TenThuongHieu;
            table.MoTa = MoTa;
            table.TrangThai = TrangThai;
            return table;
        }
    }
    public class DonViTinh_View
    {
        [IdSelection]
        public string MaDonViTinh { get; set; }

        [DisplaySelection("Đơn Vị Tính")]
        public string TenDonViTinh { get; set; }
        public string MoTa { get; set; }

        public int TrangThai { get; set; }
        public DONVITINH toDONVITINH()
        {
            DONVITINH table = new DONVITINH();
            table.MaDonViTinh = MaDonViTinh;
            table.TenDonViTinh = TenDonViTinh;
            table.MoTa = MoTa;
            
            return table;
        }
    }
}
