using PresentationLayer.GlobalVariable;
using PresentationLayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class NhaCungCap_DAL
    {
        public static List<NhaCungCap_View> getAll_NhaCungCap()
        {
            var temp = from item in Context.getInstance().db.NHACUNGCAPs
                      select new NhaCungCap_View
                      {
                          MaNhaCungCap = item.MaNhaCungCap,
                          TenNhaCungCap = item.TenNhaCungCap,
                          DiaChi = item.DiaChi,
                          SoDienThoai = item.SoDienThoai,
                          MoTa = item.MoTa,
                          TrangThai = (int)item.TrangThai
                      };
            var khp = temp.ToList();
            return khp;
        }

        //public static NhaCungCap_View get_KhachHang_By_MaKhachHang(string maKhachHang)
        //{
        //    var kh1 = from kh in Context.getInstance().db.KHACHHANGs
        //              where kh.MaKhachHang == maKhachHang
        //              select new KhachHang_View()
        //              {
        //                  MaKhachHang = kh.MaKhachHang,
        //                  TenKhachHang = kh.TenKhachHang,
        //                  TenLoaiKhachHang = kh.LOAI.TenLoai,
        //                  SoDienThoai = kh.SoDienThoai,
        //                  DiaChi = kh.DiaChi,
        //                  GhiChu = kh.GhiChu
        //              };
        //    return kh1.ToList()[0];
        //}

        public static string get_NCCMax()
        {
            try
            {
                string result = Context.getInstance().db.NHACUNGCAPs.OrderByDescending(x => x.MaNhaCungCap).First().MaNhaCungCap;
                int index = (Convert.ToInt16((result).Substring(2)) + 1);
                if (index < 10)
                    return "CC00" + index;
                else if (index < 100)
                    return "CC0" + index;
                return "CC" + index;
            }
            catch (Exception)
            {
                return "CC001";
            }
        }

        public static bool saves(DataUpdate<NhaCungCap_View> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    list.Inserts.ForEach(x =>
                    {
                        Context.getInstance().db.NHACUNGCAPs.Add(x.toNhaCungCap());
                    });

                    list.Updates.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toNhaCungCap()).State = System.Data.Entity.EntityState.Modified;
                    });

                    list.Deletes.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toNhaCungCap()).State = System.Data.Entity.EntityState.Deleted;
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
