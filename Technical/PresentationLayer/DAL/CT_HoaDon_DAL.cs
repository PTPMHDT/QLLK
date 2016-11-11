using PresentationLayer.GlobalVariable;
using PresentationLayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class CT_HoaDon_DAL
    {
        public static List<CT_HoaDon_View> get_CTHoaDon_By_MaHD(string maHD)
        {
            var hd = from ct_hoadon in Context.getInstance().db.CT_HOADON
                     where ct_hoadon.MaHoaDon == maHD
                     select new CT_HoaDon_View
                     {
                         MaHoaDon = ct_hoadon.MaHoaDon,
                         MaLinhKien = ct_hoadon.MaLinhKien,
                         TenLinhKien = ct_hoadon.LINHKIEN.TenLinhKien,
                         LoaiLinhLien = "",
                         DonViTinh = ct_hoadon.LINHKIEN.DONVITINH.TenDonViTinh,
                         SoLuong = ct_hoadon.SoLuong,
                         GiaBan = ct_hoadon.LINHKIEN.GiaBanLe,
                         ThanhTien = ct_hoadon.ThanhTien,
                         GhiChu = ct_hoadon.GhiChu
                     };
            return hd.ToList();
        }
    }
}
