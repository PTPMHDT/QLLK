using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
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
                       where item.TrangThai == 1
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

        public static NhaCungCap_View get_NCC_By_MaNCC(string maNCC)
        {
            var ncc1 = from ncc in Context.getInstance().db.NHACUNGCAPs
                      where ncc.MaNhaCungCap == maNCC
                      select new NhaCungCap_View()
                      {
                          MaNhaCungCap = ncc.MaNhaCungCap,
                          TenNhaCungCap = ncc.TenNhaCungCap,
                          SoDienThoai = ncc.SoDienThoai,
                          DiaChi = ncc.DiaChi,
                          MoTa = ncc.MoTa,
                          TrangThai = (int)ncc.TrangThai
                      };
            return ncc1.ToList()[0];
        }

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

        public static bool add(NhaCungCap_View ncc)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(ncc.toNhaCungCap()).State = System.Data.Entity.EntityState.Added;

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
                        Context.getInstance().db.Entry(x.toNhaCungCap_Del()).State = System.Data.Entity.EntityState.Modified;
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
