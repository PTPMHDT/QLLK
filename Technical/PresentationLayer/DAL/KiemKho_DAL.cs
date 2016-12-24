using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace PresentationLayer.DAL
{
    public class KiemKho_DAL
    {
        public static List<KiemKho_View> getAll_KiemKho()
        {
            var kho1 = from kho in Context.getInstance().db.KIEMKHOes
                       select new KiemKho_View
                       {
                           MaKiemKho = kho.MaKiemKho,
                           NgayKiem = kho.NgayKiem,
                           NhanVien = kho.NHANVIEN.MaNhanVien,
                           TenNhanVien = kho.NHANVIEN.TenNhanVien,
                           //TenNhanVien = kho.NHANVIEN.TenNhanVien,
                           //MaLinhKien = kho.MaLinhKien,
                           //TenLinhKien = kho.LINHKIEN.TenLinhKien,
                           //MaDonViTinh = kho.LINHKIEN.MaDonViTinh,
                           //DonViTinh = kho.LINHKIEN.DONVITINH.TenDonViTinh,
                           
                           GhiChu = kho.GhiChu,
                           TrangThai = kho.TrangThai

                       };
            return kho1.ToList();
        }
        public static List<KiemKho_View> getAll_KiemKho(string maKiemKho)
        {
            var kho1 = from kho in Context.getInstance().db.KIEMKHOes
                       where kho.MaKiemKho == maKiemKho
                       select new KiemKho_View
                       {
                           MaKiemKho = kho.MaKiemKho,
                           NgayKiem = kho.NgayKiem,
                           NhanVien = kho.NHANVIEN.MaNhanVien,
                           TenNhanVien = kho.NHANVIEN.TenNhanVien,
                           //TenNhanVien = kho.NHANVIEN.TenNhanVien,
                           //MaLinhKien = kho.MaLinhKien,
                           //TenLinhKien = kho.LINHKIEN.TenLinhKien,
                           //MaDonViTinh = kho.LINHKIEN.MaDonViTinh,
                           //DonViTinh = kho.LINHKIEN.DONVITINH.TenDonViTinh,

                           GhiChu = kho.GhiChu,
                           TrangThai = kho.TrangThai

                       };
            return kho1.ToList();
        }
        public static bool add(KiemKho_View item)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(item.toKiemKho()).State = System.Data.Entity.EntityState.Added;

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

        public static string getMaxKiemKho(int c)
        {
            try
            {
                string result = Context.getInstance().db.KIEMKHOes.OrderByDescending(x => x.MaKiemKho).First().MaKiemKho;
                int index = (Convert.ToInt16((result).Substring(2)) + 1) + c;
                if (index < 10)
                    return "KK00" + index;
                else if (index < 100)
                    return "KK0" + index;
                return "KK" + index;
            }
            catch (Exception)
            {
                return "KK001";
            }
        }
        public static List<CT_KiemKho_View> get_AllLinhKien(string maThuongHieu)
        {
            //int soluong = (from p in Context.getInstance().db.KHOes
            //               where p.LINHKIEN.THUONGHIEU.MaThuongHieu == maThuongHieu
            //               select p).Count();
            var kho1 = from kho in Context.getInstance().db.KHOes
                       where kho.LINHKIEN.THUONGHIEU.MaThuongHieu == maThuongHieu
                       select new CT_KiemKho_View
                       {
                           //MaKiemKho = kho.MaKiemKho,
                           //NgayKiem = kho.NgayKiem,
                           //NhanVien = kho.MaNhanVien,
                           //GhiChu = kho.GhiChu,
                           //TrangThai = kho.TrangThai
                           //MaKiemKho = Context.getInstance().nv.MaNhanVien,
                           MaLinhKien = kho.MaLinhKien,
                           TenLinhKien = kho.LINHKIEN.TenLinhKien,
                           MaDonViTinh = kho.LINHKIEN.DONVITINH.MaDonViTinh,
                           DonViTinh = kho.LINHKIEN.DONVITINH.TenDonViTinh,
                           GhiChu = kho.LINHKIEN.MoTa

                       };

            List<CT_KiemKho_View> myHD = new List<CT_KiemKho_View>();
            bool isHave = false;
            foreach (var item in kho1.ToList())
            {
                if (myHD.Count > 0)
                {
                    isHave = false;
                    foreach (var item1 in myHD)
                    {
                        if (item.MaLinhKien == item1.MaLinhKien)
                        {
                            item1.SoLuong += 1;
                            isHave = true;
                            break;
                        }
                    }
                    if (!isHave)
                    {
                        item.SoLuong += 1;
                        myHD.Add(item);
                    }

                }
                else
                {
                    
                    item.SoLuong += 1;
                    myHD.Add(item);
                }

            }
            return myHD;// kho1.ToList();

        }

        public static bool add(CT_KiemKho_View item)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(item.toCT_KiemKho()).State = System.Data.Entity.EntityState.Added;

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
        public static bool add(KiemKho_View kiemKho, List<CT_KiemKho_View> ctKiemKho)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(kiemKho.toKiemKho()).State = System.Data.Entity.EntityState.Added;
                    Context.getInstance().db.SaveChanges();

                    foreach(CT_KiemKho_View item in ctKiemKho)
                    {
                        try
                        {
                            Context.getInstance().db.Entry(item.toCT_KiemKho()).State = System.Data.Entity.EntityState.Added;

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
                    
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------" + ex.Message);
                    return false;
                }
            }
            return true;
        }

    }
}
