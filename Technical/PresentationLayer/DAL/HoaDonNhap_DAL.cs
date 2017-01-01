using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class HoaDonNhap_DAL
    {
        public static List<HoaDonNhap_View> getAll_HoaDonNhap()
        {
            var hd = from hoadon in Context.getInstance().db.HOADON_NHAPHANG
                     select new HoaDonNhap_View
                       {
                           MaHoaDon = hoadon.MaHoaDon,
                           NgayLap = hoadon.NgayLap,
                           NhanVien = hoadon.NHANVIEN.TenNhanVien,
                           MaNhanVien = hoadon.MaNguoiLap,
                           TongTien = hoadon.TongTien,
                           TrangThai = hoadon.TrangThai,
                           NhaCungCap = hoadon.NHACUNGCAP.TenNhaCungCap,
                           MaNhaCungCap = hoadon.MaNhaCungCap,
                           SoDienThoai = hoadon.NHACUNGCAP.SoDienThoai
                       };
            return hd.ToList();
        }

        public static HoaDonNhap_View get_HoaDonNhap_By_MaHD(string maHD)
        {
            var hd = from hoadon in Context.getInstance().db.HOADON_NHAPHANG
                     where hoadon.MaHoaDon == maHD
                     select new HoaDonNhap_View
                     {
                         MaHoaDon = hoadon.MaHoaDon,
                         NgayLap = hoadon.NgayLap,
                         NhanVien = hoadon.NHANVIEN.TenNhanVien,
                         MaNhanVien = hoadon.MaNguoiLap,
                         TongTien = hoadon.TongTien,
                         TrangThai = hoadon.TrangThai,
                         NhaCungCap = hoadon.NHACUNGCAP.TenNhaCungCap,
                         MaNhaCungCap = hoadon.MaNhaCungCap,
                         SoDienThoai = hoadon.NHACUNGCAP.SoDienThoai,
                         GhiChu = hoadon.GhiChu
                     };
            HoaDonNhap_View hdV = hd.ToList()[0];
            hdV.ChiTietHoaDon = CT_HoaDonNhap_DAL.get_CTHoaDonNhap_By_MaHD(hdV.MaHoaDon);
            return hdV;
        }

        public static string get_HoaDonNhapMax()
        {
            try
            {
                string result = Context.getInstance().db.HOADON_NHAPHANG.OrderByDescending(x => x.MaHoaDon).First().MaHoaDon;
                int index = (Convert.ToInt16((result).Substring(2)) + 1);
                if (index < 10)
                    return "HD00" + index;
                else if (index < 100)
                    return "HD0" + index;
                return "HD" + index;
            }
            catch (Exception)
            {
                return "HD001";
            }
        }

        public static HoaDonNhap_View get_HoaDonNhap_By_Seri(string seri)
        {
            var hd = from hoadon in Context.getInstance().db.CT_HOADON_NHAPHANG
                     where hoadon.Seri == seri
                     select new HoaDonNhap_View
                     {
                         MaHoaDon = hoadon.MaHoaDon
                     };
            
            return get_HoaDonNhap_By_MaHD(hd.ToList()[0].MaHoaDon);
        }

        public static bool add_HoaDonNhap(HoaDonNhap_View hd, List<CT_HoaDonNhap_View> ct_hds)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    decimal phanTramLoiNhuanBanLe = decimal.Parse(HeThong_DAL.getHeThongByMa("HT002").GiaTri);
                    decimal phanTramLoiNhuanBanBuon = decimal.Parse(HeThong_DAL.getHeThongByMa("HT003").GiaTri);

                    Context.getInstance().db.Entry(hd.toHoaDonNhap()).State = System.Data.Entity.EntityState.Added;
                    Context.getInstance().db.SaveChanges();
                    LINHKIEN lk;
                    ct_hds.ForEach(x =>
                    {
                        foreach (var seri in x.SoSeri)
                        {
                            Context.getInstance().db.Entry(x.toCT_HoaDonNhap(seri)).State = System.Data.Entity.EntityState.Added;
                            //nhap kho
                            KHO myK = new KHO();
                            myK.MaLinhKien = x.MaLinhKien;
                            myK.Seri = seri;
                            myK.NgayNhap = hd.NgayLap;
                            myK.TrangThai = 1;
                            Context.getInstance().db.Entry(myK).State = System.Data.Entity.EntityState.Added;
                        }
                        lk = Context.getInstance().db.LINHKIENs.Where(key => key.MaLinhKien == x.MaLinhKien).FirstOrDefault();
                        if (lk.GiaNhap != x.GiaNhap)
                        {
                            lk.GiaNhap = x.GiaNhap;
                            lk.GiaBanLe = x.GiaNhap + (x.GiaNhap * phanTramLoiNhuanBanLe / 100);
                            lk.GiaBanSi = x.GiaNhap + (x.GiaNhap * phanTramLoiNhuanBanBuon / 100);
                            Context.getInstance().db.Entry(lk).State = System.Data.Entity.EntityState.Modified;
                        }
                    });
                    //update so tien nhap hang cua nha cc
                    NHACUNGCAP ncc = Context.getInstance().db.NHACUNGCAPs.Where(key => key.MaNhaCungCap == hd.MaNhaCungCap).FirstOrDefault();
                    ncc.Tong += hd.TongTien;
                    Context.getInstance().db.Entry(ncc).State = System.Data.Entity.EntityState.Modified;

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------" + ex.Message);
                    return false;
                }

            }
            return true;
        }

        public static bool del_HoaDon(List<HOADON> hds)
        {
            try
            {
                foreach (HOADON hd in hds)
                {
                    Context.getInstance().db.HOADONs.Remove(hd);
                }
                Context.getInstance().db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public static bool update_HoaDon(HoaDon_View hd, List<CT_HoaDon_View> ct_hds)
        {

            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(hd.toHoaDon()).State = System.Data.Entity.EntityState.Modified;

                    ct_hds.ForEach(x =>
                    {
                        Context.getInstance().db.CT_HOADON.Add(x.toCT_HoaDon());
                    });

                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Context.getInstance().db.HOADONs.Local.Clear();
                    Context.getInstance().db.CT_HOADON.Local.Clear();
                    transaction.Rollback();
                    return false;
                }
            }
            return true;
        }

        internal static object getAll_HoaDonNhap_TheoThoiGian(DateTime startD, DateTime endD)
        {
            var hd = from hoadon in Context.getInstance().db.HOADON_NHAPHANG
                     where hoadon.NgayLap >= startD.Date
                     where hoadon.NgayLap <= endD.Date
                     select new HoaDonNhap_View
                     {
                         MaHoaDon = hoadon.MaHoaDon,
                         NgayLap = hoadon.NgayLap,
                         NhanVien = hoadon.NHANVIEN.TenNhanVien,
                         MaNhanVien = hoadon.MaNguoiLap,
                         TongTien = hoadon.TongTien,
                         TrangThai = hoadon.TrangThai,
                         NhaCungCap = hoadon.NHACUNGCAP.TenNhaCungCap,
                         MaNhaCungCap = hoadon.MaNhaCungCap,
                         SoDienThoai = hoadon.NHACUNGCAP.SoDienThoai,
                         GhiChu = hoadon.GhiChu
                     };
            var khp = hd.ToList();
            khp.ForEach(k => k.ChiTietHoaDon = CT_HoaDonNhap_DAL.get_CTHoaDonNhap_By_MaHD(k.MaHoaDon));
            return khp.ToList();
        }
    }
}
