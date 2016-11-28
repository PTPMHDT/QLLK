using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class CT_HoaDonNhap_DAL
    {
        public static List<CT_HoaDonNhap_View> get_CTHoaDonNhap_By_MaHD(string maHD)
        {
            var hd = from ct_hoadon in Context.getInstance().db.CT_HOADON_NHAPHANG
                     where ct_hoadon.MaHoaDon == maHD
                     select new CT_HoaDonNhap_View
                     {
                         MaHoaDon = ct_hoadon.MaHoaDon,
                         MaLinhKien = ct_hoadon.MaLinhKien,
                         TenLinhKien = ct_hoadon.LINHKIEN.TenLinhKien,
                         LoaiLinhLien = "",
                         DonViTinh = ct_hoadon.LINHKIEN.DONVITINH.TenDonViTinh,
                         SoLuong = ct_hoadon.SoLuong,
                         GiaNhap = ct_hoadon.LINHKIEN.GiaNhap,
                         ThanhTien = ct_hoadon.ThanhTien,
                         GhiChu = ct_hoadon.GhiChu
                     };
            return hd.ToList();
        }
    }
}
