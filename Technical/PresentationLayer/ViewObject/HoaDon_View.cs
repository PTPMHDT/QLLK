﻿using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class HoaDon_View : CGrid
    {
        public string MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNhanVien { get; set; }
        public string NhanVien { get; set; }
        public Decimal TongTien { get; set; }
        public Decimal TongLoiNhuan { get; set; }
        public Decimal ChietKhau { get; set; }
        public int TrangThai { get; set; }
        public string KhachHang { get; set; }
        public string MaKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string GhiChu { get; set; }
        public string MaNhanVienSua { get; set; }
        public string TenNhanVienSua { get; set; }
        public DateTime NgaySua { get; set; }
        public List<CT_HoaDon_View> ChiTietHoaDon { get; set; }

        public HoaDon_View()
            : base()
        {
        }

        public HOADON toHoaDon()
        {
            HOADON hd = Context.getInstance().db.HOADONs.Where(key => key.MaHoaDon == MaHoaDon).FirstOrDefault();
            if (hd == null)
            {
                hd = new HOADON();
                hd.MaHoaDon = MaHoaDon;
            }
            hd.NgayLap = NgayLap;
            hd.MaNguoiLap = MaNhanVien;
            hd.TongTien = TongTien;
            hd.TongLoiNhuan = TongLoiNhuan;
            hd.GhiChu = GhiChu;
            hd.MaKhachHang = MaKhachHang;
            hd.MaNguoiSua = MaNhanVienSua;
            hd.NgaySua = NgaySua;
            hd.TrangThai = TrangThai;
            return hd;
        }
    }
}
