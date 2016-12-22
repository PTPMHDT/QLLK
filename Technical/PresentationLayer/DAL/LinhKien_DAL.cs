using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class LinhKien_DAL
    {
        public static List<LinhKien_View> getAll_LinhKien()
        {
            var lk1 = from lk in Context.getInstance().db.LINHKIENs
                      where lk.TinhTrang == 1
                       select new LinhKien_View()
                       {
                           MaLinhKien = lk.MaLinhKien,
                           TenLinhKien = lk.TenLinhKien,
                           MaDonViTinh = lk.DONVITINH.MaDonViTinh,
                           TenDonViTinh = lk.DONVITINH.TenDonViTinh,
                           MaNhaCungCap = lk.NHACUNGCAP.MaNhaCungCap,
                           TenNhaCungCap = lk.NHACUNGCAP.TenNhaCungCap,
                           MaThuongHieu = lk.THUONGHIEU.MaThuongHieu,
                           TenThuongHieu = lk.THUONGHIEU.TenThuongHieu,
                           GiaBanLe = lk.GiaBanLe,
                           GiaBanSi = lk.GiaBanSi,
                           GiaNhap = lk.GiaNhap,
                           TinhTrang = lk.TinhTrang,
                           ThoiGianBaoHanh = lk.ThoiGianBaoHanh,
                           MoTa = lk.MoTa
                       };
            var lks= lk1.ToList();
            lks.ForEach(x =>  x.InitOldData());
            return lks;
        }

        public static List<LinhKien_View> getAll_LinhKien_ByNCC(string MaNCC)
        {
            var lk1 = from lk in Context.getInstance().db.LINHKIENs
                      where lk.MaNhaCungCap == MaNCC
                      select new LinhKien_View()
                      {
                          MaLinhKien = lk.MaLinhKien,
                          TenLinhKien = lk.TenLinhKien,
                          TenDonViTinh = lk.DONVITINH.TenDonViTinh,
                          TenNhaCungCap = lk.NHACUNGCAP.TenNhaCungCap,
                          TenThuongHieu = lk.THUONGHIEU.TenThuongHieu,
                          GiaBanLe = lk.GiaBanLe,
                          GiaBanSi = lk.GiaBanSi,
                          GiaNhap = (decimal)lk.GiaNhap,
                          TinhTrang = lk.TinhTrang,
                          ThoiGianBaoHanh = (int)lk.ThoiGianBaoHanh,
                          MoTa = lk.MoTa
                      };
            return lk1.ToList();
        }

        public static LinhKien_View get_LinhKien_ByMaLK(string MaLK)
        {
            var lk1 = from lk in Context.getInstance().db.LINHKIENs
                      where lk.MaLinhKien == MaLK
                      select new LinhKien_View()
                      {
                          MaLinhKien = lk.MaLinhKien,
                          TenLinhKien = lk.TenLinhKien,
                          TenDonViTinh = lk.DONVITINH.TenDonViTinh,
                          TenNhaCungCap = lk.NHACUNGCAP.TenNhaCungCap,
                          TenThuongHieu = lk.THUONGHIEU.TenThuongHieu,
                          GiaBanLe = lk.GiaBanLe,
                          GiaBanSi = lk.GiaBanSi,
                          GiaNhap = (decimal)lk.GiaNhap,
                          TinhTrang = lk.TinhTrang,
                          ThoiGianBaoHanh = (int)lk.ThoiGianBaoHanh,
                          MoTa = lk.MoTa
                      };
            if (lk1 != null)
                return lk1.ToList()[0];
            return null;
        }

        public static bool saves(DataUpdate<LinhKien_View> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    list.Inserts.ForEach(x =>
                    {
                        x.TinhTrang = 1;
                        Context.getInstance().db.Entry(x.toLinhKien()).State = System.Data.Entity.EntityState.Added;
                    });

                    list.Updates.ForEach(x =>
                    {
                        x.TinhTrang = 1;
                        Context.getInstance().db.Entry(x.toLinhKien()).State = System.Data.Entity.EntityState.Modified;
                    });

                    list.Deletes.ForEach(x =>
                    {
                        x.TinhTrang = 0;
                        Context.getInstance().db.Entry(x.toLinhKien()).State = System.Data.Entity.EntityState.Modified;
                    });

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

        public static bool Add_LinhKien(LinhKien_View item)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.LINHKIENs.Add(item.toLinhKien());
                    Context.getInstance().db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Context.getInstance().db.LINHKIENs.Local.Clear();
                    transaction.Rollback();
                    return false;
                }
            }
            return true;
        }

        public static string get_LinhKienMax(int c)
        {
            try
            {
                string result = Context.getInstance().db.LINHKIENs.OrderByDescending(x => x.MaLinhKien).First().MaLinhKien;
                int index = (Convert.ToInt16((result).Substring(2)) + 1);
                if (c != 0)
                    index += c;
                if (index < 10)
                    return "LK00" + index;
                else if (index < 100)
                    return "LK0" + index;
                return "LK" + index;
            }
            catch (Exception)
            {
                return "LK001";
            }
        }

    }
}
