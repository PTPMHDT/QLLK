using PresentationLayer.GlobalVariable;
using PresentationLayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class HoaDon_DAL
    {
        public static List<HoaDon_View> getAll_HoaDon()
        {
            var hd = from hoadon in Context.getInstance().db.HOADONs
                       select new HoaDon_View
                       {
                           MaHoaDon = hoadon.MaHoaDon,
                           MaPhieu = hoadon.MaPhieu,
                           NgayLap = hoadon.NgayLap,
                           NhanVien = hoadon.NHANVIEN.TenNhanVien,
                           MaNhanVien = hoadon.MaNguoiLap,
                           TongTien = hoadon.TongTien,
                           TrangThai = hoadon.TrangThai,
                           KhachHang = hoadon.KHACHHANG.TenKhachHang,
                           MaKhachHang = hoadon.MaKhachHang,
                           SoDienThoai = hoadon.KHACHHANG.SoDienThoai
                       };
            return hd.ToList();
        }

        public static HoaDon_View get_HoaDon_By_MaHD(string maHD)
        {
            var hd = from hoadon in Context.getInstance().db.HOADONs
                     where hoadon.MaHoaDon == maHD
                     select new HoaDon_View
                     {
                         MaHoaDon = hoadon.MaHoaDon,
                         MaPhieu = hoadon.MaPhieu,
                         NgayLap = hoadon.NgayLap,
                         NhanVien = hoadon.NHANVIEN.TenNhanVien,
                         MaNhanVien = hoadon.MaNguoiLap,
                         TongTien = hoadon.TongTien,
                         TrangThai = hoadon.TrangThai,
                         KhachHang = hoadon.KHACHHANG.TenKhachHang,
                         MaKhachHang = hoadon.MaKhachHang,
                         SoDienThoai = hoadon.KHACHHANG.SoDienThoai,
                         GhiChu = hoadon.GhiChu
                     };
            return hd.ToList()[0];
        }

        public static string get_HoaDonMax()
        {
            try
            {
                string result = Context.getInstance().db.HOADONs.OrderByDescending(x => x.MaHoaDon).First().MaHoaDon;
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

        public static bool add_HoaDon( HoaDon_View hd, List<CT_HoaDon_View> ct_hds)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.HOADONs.Add(hd.toHoaDon());
                    Context.getInstance().db.SaveChanges();

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
    }
}
