using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class CT_HoaDonNhap_View
    {
        public string MaHoaDon { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string LoaiLinhLien { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public Decimal GiaNhap { get; set; }
        public Decimal ThanhTien { get; set; }
        public string GhiChu { get; set; }
        public int TinhTrang { get; set; }

        public CT_HOADON_NHAPHANG toCT_HoaDonNhap()
        {
            CT_HOADON_NHAPHANG cthd = Context.getInstance().db.CT_HOADON_NHAPHANG.Where(key => key.MaHoaDon == MaHoaDon).Where(key => key.MaLinhKien == MaLinhKien).FirstOrDefault();
            if (cthd == null)
            {
                cthd = new CT_HOADON_NHAPHANG();
                cthd.MaHoaDon = MaHoaDon;
                cthd.MaLinhKien = MaLinhKien;
            }
            cthd.SoLuong = SoLuong;
            cthd.ThanhTien = ThanhTien;
            cthd.GhiChu = GhiChu;
            cthd.TinhTrang = TinhTrang;
            return cthd;
        }
    }
}
