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
            return hd.ToList()[0];
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

        public static bool add_HoaDonNhap(HoaDonNhap_View hd, List<CT_HoaDonNhap_View> ct_hds)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(hd.toHoaDonNhap()).State = System.Data.Entity.EntityState.Added;
                    KHO kho;
                    LINHKIEN lk;
                    ct_hds.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toCT_HoaDonNhap()).State = System.Data.Entity.EntityState.Added;
                        lk = Context.getInstance().db.LINHKIENs.Where(key => key.MaLinhKien == x.MaLinhKien).FirstOrDefault();
                        if (!(lk.GiaNhap == x.GiaNhap))
                        {
                            lk.GiaNhap = x.GiaNhap;
                            lk.GiaBanLe = x.GiaNhap + (x.GiaNhap * Context.getInstance().phanTram_LoiNhuan_BanLe);
                            lk.GiaBanSi = x.GiaNhap + (x.GiaNhap * Context.getInstance().phanTram_LoiNhuan_BanBuon);
                        }
                        Context.getInstance().db.Entry(lk).State = System.Data.Entity.EntityState.Modified;

                        //neu da co san trong kho roi
                        kho = Context.getInstance().db.KHOes.Where(key => key.MaLinhKien == x.MaLinhKien).FirstOrDefault();
                        if (kho != null)
                        {
                            kho.SoLuong = kho.SoLuong + x.SoLuong;
                            Context.getInstance().db.Entry(kho).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            kho = new KHO();
                            kho.MaLinhKien = x.MaLinhKien;
                            kho.MaKho = "KHO001";
                            kho.SoLuong = x.SoLuong;
                            kho.TenKho = "Kho chung";
                            kho.TrangThai = 1;
                            Context.getInstance().db.Entry(kho).State = System.Data.Entity.EntityState.Added;
                        }

                    });
                    //update so tien nhap hang cua nha cc
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
