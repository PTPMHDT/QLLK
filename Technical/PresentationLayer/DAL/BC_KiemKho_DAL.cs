using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PresentationLayer.DAL
{
    public class BC_KiemKho_DAL
    {
        public static List<CT_KiemKho_View> get_CTHoaDon_By_MaHD_TT01(string maHD)
        {
            var hd = from ct in Context.getInstance().db.CT_KIEMKHO
                     where ct.MaKiemKho == maHD
                     select new CT_KiemKho_View
                     {
                         MaKiemKho = ct.MaKiemKho,
                         MaLinhKien = ct.MaLinhKien,
                         MaNhanVien = ct.KIEMKHO.NHANVIEN.TenNhanVien,
                         TenLinhKien = ct.LINHKIEN.TenLinhKien,
                         MaDonViTinh = ct.LINHKIEN.DONVITINH.MaDonViTinh,
                         DonViTinh = ct.LINHKIEN.DONVITINH.TenDonViTinh,
                         SoLuong = ct.SoLuong,
                         TonSoSach = ct.TonSoSach,
                         ChenhLech = ct.ChenhLech,
                         GhiChu = ct.GhiChu
                     };
            #region 
            //List<CT_KiemKho_View> myHD = new List<CT_KiemKho_View>();
            //bool isHave = false;
            //foreach (var item in hd.ToList())
            //{
            //    if (myHD.Count > 0)
            //    {
            //        isHave = false;
            //        foreach (var item1 in myHD)
            //        {
            //            if (item.MaLinhKien == item1.MaLinhKien)
            //            {                            
            //                isHave = true;
            //                item1.SoLuong++;
            //                break;
            //            }
            //        }
            //        if (!isHave)
            //        {
            //            item.SoLuong++;
            //            myHD.Add(item);
            //        }

            //    }
            //    else
            //    {
            //        myHD.Add(item);
            //    }

            //}
            #endregion
            return hd.ToList();
        }
        public static CT_KiemKho_View get_CTHoaDon_By_MaHD_MaLK(string maHD, string maLK)
        {
            var hd = from ct in Context.getInstance().db.CT_KIEMKHO
                     where ct.MaKiemKho == maHD
                     where ct.MaLinhKien == maLK
                     select new CT_KiemKho_View
                     {
                        MaKiemKho = ct.MaKiemKho,
                        MaLinhKien = ct.MaLinhKien,
                        SoLuong = ct.SoLuong,
                        TonSoSach = ct.TonSoSach,
                        ChenhLech = ct.ChenhLech,
                        GhiChu = ct.GhiChu
                     };

            CT_KiemKho_View myHD = new CT_KiemKho_View();
            if (hd.ToList().Count > 0)
            {
                myHD = hd.ToList()[0];
            }
           
            return myHD;
        }

        internal static List<KiemKho_View> getAll_BaoCaoKiemKho(DateTime startD, DateTime endD)
        {
            var hd = from kiemkho in Context.getInstance().db.KIEMKHOes
                     //where kiemkho.NgayKiem >= startD.Date
                     select new KiemKho_View
                     {
                         MaKiemKho = kiemkho.MaKiemKho,
                         MaNhanVien = kiemkho.NHANVIEN.MaNhanVien,
                         TenNhanVien = kiemkho.NHANVIEN.TenNhanVien,
                         NgayKiem = kiemkho.NgayKiem,
                         TrangThai = kiemkho.TrangThai,
                         GhiChu= kiemkho.GhiChu
                     };
            var khp = hd.ToList();
            khp.ForEach(k => k.ChiTietKiemKho = BC_KiemKho_DAL.get_CTHoaDon_By_MaHD_TT01(k.MaKiemKho));
            return khp.ToList();
        }
    }
}
