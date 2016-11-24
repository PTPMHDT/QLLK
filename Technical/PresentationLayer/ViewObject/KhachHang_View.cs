
using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
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
        public string TenKhachHangShow { get; set; }

        public override String ToString()
        {
            return TenKhachHang.Trim() + "   (" + MaKhachHang.Trim() + ")";
        }

        public KhachHang_View()
            : base()
        {
            //MaKhachHang = KhachHang_DAL.get_KhachHangMax();
        }

        public KHACHHANG toKhachHang()
        {
            KHACHHANG kh = Context.getInstance().db.KHACHHANGs.Where(key => key.MaKhachHang == MaKhachHang).FirstOrDefault();
            if (kh == null)
            {
                kh = new KHACHHANG();
                kh.MaKhachHang = MaKhachHang;
            }
            kh.TenKhachHang = TenKhachHang;
            kh.MaLoai = MaLoaiKhachHang;
            kh.SoDienThoai = SoDienThoai;
            kh.DiaChi = DiaChi;
            kh.GhiChu = GhiChu;
            kh.TrangThai = 1;
            return kh;
        }

        public KHACHHANG toKhachHang_Del()
        {
            KHACHHANG kh = Context.getInstance().db.KHACHHANGs.Where(key => key.MaKhachHang == MaKhachHang).FirstOrDefault();
            if (kh == null)
            {
                kh = new KHACHHANG();
                kh.MaKhachHang = MaKhachHang;
            }
            kh.TenKhachHang = TenKhachHang;
            kh.MaLoai = MaLoaiKhachHang;
            kh.SoDienThoai = SoDienThoai;
            kh.DiaChi = DiaChi;
            kh.GhiChu = GhiChu;
            kh.TrangThai = 0;
            return kh;
        }
    }
}
