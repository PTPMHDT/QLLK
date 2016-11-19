using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class HoaDonNhap_View
    {
        public string MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNhanVien { get; set; }
        public string NhanVien { get; set; }
        public Decimal TongTien { get; set; }
        public int TrangThai { get; set; }
        public string NhaCungCap { get; set; }
        public string MaNhaCungCap { get; set; }
        public string SoDienThoai { get; set; }
        public string GhiChu { get; set; }

        public HOADON_NHAPHANG toHoaDonNhap()
        {
            HOADON_NHAPHANG hd = Context.getInstance().db.HOADON_NHAPHANG.Where(key => key.MaHoaDon == MaHoaDon).FirstOrDefault();
            if (hd == null)
            {
                hd = new HOADON_NHAPHANG();
                hd.MaHoaDon = MaHoaDon;
            }
            hd.NgayLap = NgayLap;
            hd.MaNguoiLap = MaNhanVien;
            hd.TongTien = TongTien;
            hd.GhiChu = GhiChu;
            hd.MaNhaCungCap = MaNhaCungCap;
            hd.TrangThai = TrangThai;
            return hd;
        }
    }
}
