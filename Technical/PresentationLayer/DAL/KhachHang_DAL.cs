using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PresentationLayer.DAL
{
    public class KhachHang_DAL
    {
        public static List<KhachHang_View> getAll_KhachHang()
        {
            var kh1 = from kh in Context.getInstance().db.KHACHHANGs
                      where kh.TrangThai == 1
                      select new KhachHang_View
                      {
                          MaKhachHang = kh.MaKhachHang,
                          TenKhachHang = kh.TenKhachHang,
                          TenKhachHangShow = kh.TenKhachHang + "  (" + kh.SoDienThoai+")",
                          TenLoaiKhachHang = kh.LOAI.TenLoai,
                          MaLoaiKhachHang = kh.LOAI.MaLoai,
                          SoDienThoai = kh.SoDienThoai,
                          DiaChi = kh.DiaChi,
                          GhiChu = kh.GhiChu
                      };
            var khp = kh1.ToList();
            khp.ForEach(k => k.InitOldData());
            return khp;
        }

        public static KhachHang_View get_KhachHang_By_MaKhachHang(string maKhachHang)
        {
            var kh1 = from kh in Context.getInstance().db.KHACHHANGs
                      where kh.MaKhachHang == maKhachHang
                      select new KhachHang_View()
                      {
                          MaKhachHang = kh.MaKhachHang,
                          TenKhachHang = kh.TenKhachHang,
                          TenLoaiKhachHang = kh.LOAI.TenLoai,
                          MaLoaiKhachHang = kh.LOAI.MaLoai,
                          SoDienThoai = kh.SoDienThoai,
                          DiaChi = kh.DiaChi,
                          GhiChu = kh.GhiChu
                      };
            return kh1.ToList()[0];
        }

        public static KhachHang_View get_KhachHang_VangLai()
        {
            var kh1 = from kh in Context.getInstance().db.KHACHHANGs
                      where kh.MaKhachHang == "KH000"
                      select new KhachHang_View()
                      {
                          MaKhachHang = kh.MaKhachHang,
                          TenKhachHang = kh.TenKhachHang,
                          TenLoaiKhachHang = kh.LOAI.TenLoai,
                          SoDienThoai = kh.SoDienThoai,
                          MaLoaiKhachHang = kh.LOAI.MaLoai,
                          DiaChi = kh.DiaChi,
                          GhiChu = kh.GhiChu
                      };
            return kh1.ToList()[0];
        }

        public static string get_KhachHangMax()
        {
            try
            {
                string result = Context.getInstance().db.KHACHHANGs.OrderByDescending(x => x.MaKhachHang).First().MaKhachHang;
                int index = (Convert.ToInt16((result).Substring(2)) + 1);
                if (index < 10)
                    return "KH00" + index;
                else if (index < 100)
                    return "KH0" + index;
                return "KH" + index;
            }
            catch (Exception)
            {
                return "KH000";
            }
        }

        public static bool saves(DataUpdate<KhachHang_View> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    list.Inserts.ForEach(x =>
                    {
                        //Context.getInstance().db.KHACHHANGs.Add(x.toKhachHang());
                        Context.getInstance().db.Entry(x.toKhachHang()).State = System.Data.Entity.EntityState.Added;
                    });

                    list.Updates.ForEach(x =>
                    {
                        Context.getInstance().db.Entry( x.toKhachHang()).State = System.Data.Entity.EntityState.Modified;
                    });

                    list.Deletes.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toKhachHang_Del()).State = System.Data.Entity.EntityState.Modified;
                    });
                  
                    Context.getInstance().db.SaveChanges();
                      
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Context.Refresh();
                    Console.WriteLine("ERROR--------------------------------------"+ex.Message);
                    return false;
                }
            }

            return true;
        }

        public static bool add(KhachHang_View kh)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(kh.toKhachHang()).State = System.Data.Entity.EntityState.Added;
                    
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
    }

 
}
