using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class CT_HoaDon_View 
    {
        public string MaHoaDon { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string LoaiLinhKien { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public Decimal GiaBan { get; set; }
        public float Thue { get; set; }
        public Decimal ThanhTien { get; set; }
        public Decimal LoiNhuan { get; set; }
        public string GhiChu { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public string Seri { get; set; }
        public List<string> SoSeri { get; set; }
        public int TinhTrang { get; set; }

        public CT_HoaDon_View(int c)
            : base()
        {
        }

        public CT_HoaDon_View()
            : base()
        {
        }

        public CT_HOADON toCT_HoaDon()
        {
            CT_HOADON cthd = Context.getInstance().db.CT_HOADON.Where(key => key.MaHoaDon == MaHoaDon).Where(key => key.MaLinhKien == MaLinhKien).FirstOrDefault();
            if (cthd == null)
            {
                cthd = new CT_HOADON();
                cthd.MaHoaDon = MaHoaDon;
                cthd.MaLinhKien = MaLinhKien;
            }
            cthd.SoLuong = SoLuong;
            cthd.ThanhTien = ThanhTien;
            cthd.GhiChu = GhiChu;
            return cthd;
        }
        public CT_HOADON toCT_HoaDon(string seri)
        {
            CT_HOADON cthd = Context.getInstance().db.CT_HOADON.Where(key => key.MaHoaDon == MaHoaDon).Where(key => key.MaLinhKien == MaLinhKien).FirstOrDefault();
            if (cthd == null)
            {
                cthd = new CT_HOADON();
                cthd.MaHoaDon = MaHoaDon;
                cthd.MaLinhKien = MaLinhKien;
            }
            cthd.SoLuong = SoLuong;
            cthd.ThanhTien = ThanhTien;
            cthd.GhiChu = GhiChu;
            cthd.Seri = seri;
            cthd.Thue = Thue;
            cthd.LoiNhuan = LoiNhuan;
            cthd.GiaBan = GiaBan;
            cthd.TinhTrang = TinhTrang;
            return cthd;
        }
        public List<CT_HOADON> toList_CT_HoaDon()
        {
            List<CT_HOADON> lst = new List<CT_HOADON>();

            foreach (var item in SoSeri)
            {
                CT_HOADON cthd = new CT_HOADON();
                cthd.MaHoaDon = MaHoaDon;
                cthd.MaLinhKien = MaLinhKien;
                cthd.SoLuong = SoLuong;
                cthd.ThanhTien = ThanhTien;
                cthd.GhiChu = GhiChu;
                cthd.Seri = item;
                cthd.Thue = Thue;
                cthd.LoiNhuan = LoiNhuan;
                cthd.GiaBan = GiaBan;
                cthd.TinhTrang = TinhTrang;
                lst.Add(cthd);
            }

            return lst;
        }
    }

}
