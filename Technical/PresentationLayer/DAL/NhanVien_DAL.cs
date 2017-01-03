using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.DAL
{
    public class NhanVien_DAL
    {
        public static List<NhanVien_View> getAll_NhanVien()
        {
            var nv1 = from nv in Context.getInstance().db.NHANVIENs
                      where nv.TrangThai == 1
                      select new NhanVien_View
                      {
                          MaNhanVien = nv.MaNhanVien,
                          TenNhanVien = nv.TenNhanVien,
                          TenDangNhap = nv.TenDangNhap,
                          MatKhau = nv.MatKhau,
                          MaLoaiNhanVien = nv.LOAINHANVIEN.MaLoaiNhanVien,
                          TenLoaiNhanVien = nv.LOAINHANVIEN.TenLoaiNhanVien,
                          SoDienThoai = nv.SoDienThoai,
                          DiaChi = nv.DiaChi,
                          Tong = (decimal) nv.TongTien,
                          GhiChu = nv.GhiChu,
                          TrangThai = 1
                      };
            var khp = nv1.ToList();
            khp.ForEach(k => k.InitOldData());
            return khp;
        }

        public static NhanVien_View get_NhanVien_By_TenDN_And_Pass(string tenDN, string pass)
        {
            var nv1 = from nv in Context.getInstance().db.NHANVIENs
                      where nv.TenDangNhap == tenDN
                      where nv.MatKhau == pass
                      select new NhanVien_View
                      {
                          MaNhanVien = nv.MaNhanVien,
                          TenNhanVien = nv.TenNhanVien,
                          TenDangNhap = nv.TenDangNhap,
                          MatKhau = nv.MatKhau,
                          MaLoaiNhanVien = nv.LOAINHANVIEN.MaLoaiNhanVien,
                          SoDienThoai = nv.SoDienThoai,
                          DiaChi = nv.DiaChi,
                          //Tong = kh.Tong,
                          GhiChu = nv.GhiChu,
                          TrangThai = 1
                      };
            var l = nv1.ToList();
            if (l.Count > 0)
                return l[0];
            return null;
        }

        public static string get_NhanVienMax(int c)
        {
            try
            {
                string result = Context.getInstance().db.NHANVIENs.OrderByDescending(x => x.MaNhanVien).First().MaNhanVien;
                int index = (Convert.ToInt16((result).Substring(2)) + 1) + c;
                if (index < 10)
                    return "NV00" + index;
                else if (index < 100)
                    return "NV0" + index;
                return "NV" + index;
            }
            catch (Exception)
            {
                return "NV001";
            }
        }

        public static bool saves(DataUpdate<NhanVien_View> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    list.Inserts.ForEach(x =>
                    {
                        x.TrangThai = 1;
                        x.TenDangNhap = x.MaNhanVien;
                        x.MatKhau = "123";
                        Context.getInstance().db.Entry(x.toNhanVien()).State = System.Data.Entity.EntityState.Added;
                    });

                    list.Updates.ForEach(x =>
                    {
                        x.TrangThai = 1;
                        Context.getInstance().db.Entry(x.toNhanVien()).State = System.Data.Entity.EntityState.Modified;
                    });

                    list.Deletes.ForEach(x =>
                    {
                        x.TrangThai = 0;
                        Context.getInstance().db.Entry(x.toNhanVien()).State = System.Data.Entity.EntityState.Modified;
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

        public static bool add(NhanVien_View nv)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(nv.toNhanVien()).State = System.Data.Entity.EntityState.Added;

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
