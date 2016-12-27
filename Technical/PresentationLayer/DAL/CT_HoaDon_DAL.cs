using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
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
                     where ct_hoadon.TinhTrang == 1
                     select new CT_HoaDon_View
                     {
                         MaHoaDon = ct_hoadon.MaHoaDon,
                         MaLinhKien = ct_hoadon.MaLinhKien,
                         TenLinhKien = ct_hoadon.LINHKIEN.TenLinhKien,
                         LoaiLinhKien = ct_hoadon.LINHKIEN.THUONGHIEU.TenThuongHieu,
                         DonViTinh = ct_hoadon.LINHKIEN.DONVITINH.TenDonViTinh,
                         SoLuong = ct_hoadon.SoLuong,
                         GiaBan = ct_hoadon.LINHKIEN.GiaBanLe,
                         ThanhTien = ct_hoadon.ThanhTien,
                         ThoiGianBaoHanh = ct_hoadon.LINHKIEN.ThoiGianBaoHanh,
                         Thue = (float)ct_hoadon.Thue,
                         LoiNhuan = ct_hoadon.LoiNhuan,
                         Seri = ct_hoadon.Seri,
                         GhiChu = ct_hoadon.GhiChu
                     };

            List<CT_HoaDon_View> myHD = new List<CT_HoaDon_View>();
            bool isHave = false;
            foreach (var item in hd.ToList())
            {
                if(myHD.Count > 0)
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

        public static CT_HoaDon_View get_CTHoaDon_By_MaHD_MaLK(string maHD, string maLK)
        {
            var hd = from ct_hoadon in Context.getInstance().db.CT_HOADON
                     where ct_hoadon.MaHoaDon == maHD
                     where ct_hoadon.MaLinhKien == maLK
                     where ct_hoadon.TinhTrang == 1
                     select new CT_HoaDon_View
                     {
                         MaHoaDon = ct_hoadon.MaHoaDon,
                         MaLinhKien = ct_hoadon.MaLinhKien,
                         TenLinhKien = ct_hoadon.LINHKIEN.TenLinhKien,
                         LoaiLinhKien = ct_hoadon.LINHKIEN.THUONGHIEU.TenThuongHieu,
                         DonViTinh = ct_hoadon.LINHKIEN.DONVITINH.TenDonViTinh,
                         SoLuong = ct_hoadon.SoLuong,
                         GiaBan = ct_hoadon.LINHKIEN.GiaBanLe,
                         ThanhTien = ct_hoadon.ThanhTien,
                         ThoiGianBaoHanh = ct_hoadon.LINHKIEN.ThoiGianBaoHanh,
                         Thue = (float)ct_hoadon.Thue,
                         LoiNhuan = ct_hoadon.LoiNhuan,
                         Seri = ct_hoadon.Seri,
                         GhiChu = ct_hoadon.GhiChu
                     };

            CT_HoaDon_View myHD = new CT_HoaDon_View();
            if(hd.ToList().Count > 0)
            {
                myHD = hd.ToList()[0];
            }
            myHD.SoSeri = new List<string>();
            foreach (var item in hd.ToList())
            {
                myHD.SoSeri.Add(item.Seri);
            }
            return myHD;
        }
    }
}
