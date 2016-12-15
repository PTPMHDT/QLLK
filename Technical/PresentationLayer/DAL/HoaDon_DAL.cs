using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
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

        internal static object getAll_HoaDon_TheoThoiGian(DateTime startD, DateTime endD)
        {
            var hd = from hoadon in Context.getInstance().db.HOADONs
                     where hoadon.NgayLap >= startD.Date 
                     where hoadon.NgayLap <= endD.Date
                     select new HoaDon_View
                     {
                         MaHoaDon = hoadon.MaHoaDon,
                         NgayLap = hoadon.NgayLap,
                         NhanVien = hoadon.NHANVIEN.TenNhanVien,
                         MaNhanVien = hoadon.MaNguoiLap,
                         TongTien = hoadon.TongTien,
                         TrangThai = hoadon.TrangThai,
                         KhachHang = hoadon.KHACHHANG.TenKhachHang,
                         MaKhachHang = hoadon.MaKhachHang,
                         SoDienThoai = hoadon.KHACHHANG.SoDienThoai
                     };
            var khp = hd.ToList();
            khp.ForEach(k => k.ChiTietHoaDon = CT_HoaDon_DAL.get_CTHoaDon_By_MaHD(k.MaHoaDon));
            return khp.ToList();
        }

        public static bool add_HoaDon( HoaDon_View hd, List<CT_HoaDon_View> ct_hds)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(hd.toHoaDon()).State = System.Data.Entity.EntityState.Added;
                    KHO kho;
                    ct_hds.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toCT_HoaDon()).State = System.Data.Entity.EntityState.Added;
                        //giam so luong trong kho
                        kho = Context.getInstance().db.KHOes.Where(key => key.MaLinhKien == x.MaLinhKien).FirstOrDefault();
                        Context.getInstance().db.Entry(kho).State = System.Data.Entity.EntityState.Modified;
                    });
                    //update so tien mua hang cua khach hang
                    KHACHHANG kh = Context.getInstance().db.KHACHHANGs.Where(key => key.MaKhachHang == hd.MaKhachHang).FirstOrDefault();
                    kh.Tong += hd.TongTien;
                    Context.getInstance().db.Entry(kh).State = System.Data.Entity.EntityState.Modified;

                    //update so luong ban hang cua nhan vien
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


    }
}
