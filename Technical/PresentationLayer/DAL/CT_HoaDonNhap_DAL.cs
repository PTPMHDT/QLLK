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
        public static List<CT_HoaDonNhap_View> get_CTHoaDonNhap_By_MaHD_TT1(string maHD)
        {
            var hd = from ct_hoadon in Context.getInstance().db.CT_HOADON_NHAPHANG
                     where ct_hoadon.MaHoaDon == maHD
                     where ct_hoadon.TinhTrang == 1
                     select new CT_HoaDonNhap_View
                     {
                         MaHoaDon = ct_hoadon.MaHoaDon,
                         MaLinhKien = ct_hoadon.MaLinhKien,
                         TenLinhKien = ct_hoadon.LINHKIEN.TenLinhKien,
                         LoaiLinhLien = ct_hoadon.LINHKIEN.THUONGHIEU.TenThuongHieu,
                         DonViTinh = ct_hoadon.LINHKIEN.DONVITINH.TenDonViTinh,
                         SoLuong = ct_hoadon.SoLuong,
                         GiaNhap = ct_hoadon.GiaNhap,
                         Thue = (float)ct_hoadon.Thue,
                         ThanhTien = ct_hoadon.ThanhTien,
                         Seri = ct_hoadon.Seri,
                         GhiChu = ct_hoadon.GhiChu
                     };
            List<CT_HoaDonNhap_View> myHD = new List<CT_HoaDonNhap_View>();
            bool isHave = false;
            foreach (var item in hd.ToList())
            {
                if (myHD.Count > 0)
                {
                    isHave = false;
                    foreach (var item1 in myHD)
                    {
                        if (item.MaLinhKien == item1.MaLinhKien)
                        {
                            item1.SoSeri.Add(item.Seri);
                            isHave = true;
                            break;
                        }
                    }
                    if (!isHave)
                    {
                        item.SoSeri = new List<string>();
                        item.SoSeri.Add(item.Seri);
                        myHD.Add(item);
                    }

                }
                else
                {
                    item.SoSeri = new List<string>();
                    item.SoSeri.Add(item.Seri);
                    myHD.Add(item);
                }

            }
            return myHD;
        }

        public static List<CT_HoaDonNhap_View> get_CTHoaDonNhap_By_MaHD_TT01(string maHD)
        {
            var hd = from ct_hoadon in Context.getInstance().db.CT_HOADON_NHAPHANG
                     where ct_hoadon.MaHoaDon == maHD
                     select new CT_HoaDonNhap_View
                     {
                         MaHoaDon = ct_hoadon.MaHoaDon,
                         MaLinhKien = ct_hoadon.MaLinhKien,
                         TenLinhKien = ct_hoadon.LINHKIEN.TenLinhKien,
                         LoaiLinhLien = ct_hoadon.LINHKIEN.THUONGHIEU.TenThuongHieu,
                         DonViTinh = ct_hoadon.LINHKIEN.DONVITINH.TenDonViTinh,
                         SoLuong = ct_hoadon.SoLuong,
                         GiaNhap = ct_hoadon.GiaNhap,
                         Thue = (float)ct_hoadon.Thue,
                         ThanhTien = ct_hoadon.ThanhTien,
                         Seri = ct_hoadon.Seri,
                         GhiChu = ct_hoadon.GhiChu
                     };
            List<CT_HoaDonNhap_View> myHD = new List<CT_HoaDonNhap_View>();
            bool isHave = false;
            foreach (var item in hd.ToList())
            {
                if (myHD.Count > 0)
                {
                    isHave = false;
                    foreach (var item1 in myHD)
                    {
                        if (item.MaLinhKien == item1.MaLinhKien)
                        {
                            item1.SoSeri.Add(item.Seri);
                            isHave = true;
                            break;
                        }
                    }
                    if (!isHave)
                    {
                        item.SoSeri = new List<string>();
                        item.SoSeri.Add(item.Seri);
                        myHD.Add(item);
                    }

                }
                else
                {
                    item.SoSeri = new List<string>();
                    item.SoSeri.Add(item.Seri);
                    myHD.Add(item);
                }

            }
            return myHD;
        }
    }
}
