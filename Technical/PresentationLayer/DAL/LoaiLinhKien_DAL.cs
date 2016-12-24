using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class LoaiLinhKien_DAL
    {
        public static List<LoaiLinhKien_View> getAll_ThuongHieu()
        {
            var temp = from item in Context.getInstance().db.THUONGHIEUs
                       where item.TrangThai == 1
                       select new LoaiLinhKien_View
                       {
                           MaThuongHieu = item.MaThuongHieu,
                           TenThuongHieu = item.TenThuongHieu,               
                           TrangThai = item.TrangThai,
                           MoTa = item.MoTa
                       };
            var khp = temp.ToList();
            khp.ForEach(k => k.InitOldData());
            return khp;
        }

        public static LoaiLinhKien_View get_TH_By_MaTH(string maTH)
        {
            var th1 = from th in Context.getInstance().db.THUONGHIEUs
                       where th.MaThuongHieu == maTH
                       select new LoaiLinhKien_View()
                       {
                           MaThuongHieu = th.MaThuongHieu,
                           TenThuongHieu = th.TenThuongHieu,
                           TrangThai = th.TrangThai,
                           MoTa = th.MoTa,
                       };
            return th1.ToList()[0];
        }

        public static bool add(LoaiLinhKien_View ncc)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    Context.getInstance().db.Entry(ncc.toThuongHieu()).State = System.Data.Entity.EntityState.Added;

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
        public static bool saves(DataUpdate<LoaiLinhKien_View> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    list.Inserts.ForEach(x =>
                    {
                        x.TrangThai = 1;
                        Context.getInstance().db.Entry(x.toThuongHieu()).State = System.Data.Entity.EntityState.Added;
                    });

                    list.Updates.ForEach(x =>
                    {
                        x.TrangThai = 1;
                        Context.getInstance().db.Entry(x.toThuongHieu()).State = System.Data.Entity.EntityState.Modified;
                    });

                    list.Deletes.ForEach(x =>
                    {
                        x.TrangThai = 0;
                        Context.getInstance().db.Entry(x.toThuongHieu()).State = System.Data.Entity.EntityState.Modified;
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
