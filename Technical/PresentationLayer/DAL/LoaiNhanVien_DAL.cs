using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.DAL
{
    public class LoaiNhanVien_DAL
    {
        public static List<LoaiNhanVien_ViewBoolen> getAll_LoaiNhanVien()
        {
            var kh1 = from kh in Context.getInstance().db.LOAINHANVIENs
                      select new LoaiNhanVien_View
                      {
                          MaLoaiNhanVien = kh.MaLoaiNhanVien,
                          TenLoaiNhanVien = kh.TenLoaiNhanVien,
                          IsQuanLyNhanVien =  kh.IsQuanLyNhanVien,
                          IsQuanLyKhachHang = kh.IsQuanLyKhachHang,
                          IsQuanLyLinhKien = kh.IsQuanLyLinhKien,
                          IsQuanLyKho = kh.IsQuanLyKho,
                          IsQuanLyHeThong = kh.IsQuanLyHeThong,
                          IsQuanLyBanHang = kh.IsQuanLyBanHang,
                          MoTa = kh.MoTa
                      };
            var khp = kh1.ToList();
            List<LoaiNhanVien_ViewBoolen> lst = new List<LoaiNhanVien_ViewBoolen>();
            foreach (var item in khp)
            {
                LoaiNhanVien_ViewBoolen lnv = item.Change();
                lst.Add(lnv);
            }

            lst.ForEach(k => k.InitOldData());
            return lst;
        }

        public static LoaiNhanVien_ViewBoolen get_LoaiNhanVien_ByMaLoaiNV(string maLNV)
        {
            var kh1 = from kh in Context.getInstance().db.LOAINHANVIENs
                      where kh.MaLoaiNhanVien == maLNV
                      select new LoaiNhanVien_View
                      {
                          MaLoaiNhanVien = kh.MaLoaiNhanVien,
                          TenLoaiNhanVien = kh.TenLoaiNhanVien,
                          IsQuanLyNhanVien =  kh.IsQuanLyNhanVien,
                          IsQuanLyKhachHang = kh.IsQuanLyKhachHang,
                          IsQuanLyLinhKien = kh.IsQuanLyLinhKien,
                          IsQuanLyKho = kh.IsQuanLyKho,
                          IsQuanLyHeThong = kh.IsQuanLyHeThong,
                          IsQuanLyBanHang = kh.IsQuanLyBanHang,
                          MoTa = kh.MoTa
                      };
            var khp = kh1.ToList();
            List<LoaiNhanVien_ViewBoolen> lst = new List<LoaiNhanVien_ViewBoolen>();
            foreach (var item in khp)
            {
                LoaiNhanVien_ViewBoolen lnv = item.Change();
                lst.Add(lnv);
            }

            return lst[0];
        }

        public static string get_LoaiNhanVienMax(int c)
        {
            try
            {
                string result = Context.getInstance().db.LOAINHANVIENs.OrderByDescending(x => x.MaLoaiNhanVien).First().MaLoaiNhanVien;
                int index = (Convert.ToInt16((result).Substring(2)) + 1) + c;
                if (index < 10)
                    return "L00" + index;
                else if (index < 100)
                    return "L0" + index;
                return "L" + index;
            }
            catch (Exception)
            {
                return "L001";
            }
        }

        public static bool saves(DataUpdate<LoaiNhanVien_ViewBoolen> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    list.Inserts.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toLOAINHANVIEN()).State = System.Data.Entity.EntityState.Added;
                    });

                    list.Updates.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toLOAINHANVIEN()).State = System.Data.Entity.EntityState.Modified;
                    });

                    list.Deletes.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toLOAINHANVIEN()).State = System.Data.Entity.EntityState.Deleted;
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
    
    
    }
}