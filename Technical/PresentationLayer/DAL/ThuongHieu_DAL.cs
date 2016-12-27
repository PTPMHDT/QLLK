using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PresentationLayer.DAL
{
    public class ThuongHieu_DAL
    {
        public static List<ThuongHieu_View> getAll_ThuongHieu()
        {
            var lk1 = from lk in Context.getInstance().db.THUONGHIEUx
                      select new ThuongHieu_View()
                      {
                         MaThuongHieu = lk.MaThuongHieu,
                         TenThuongHieu = lk.TenThuongHieu,
                         MoTa = lk.MoTa,
                         TrangThai = (int)lk.TrangThai,
                      };
            var khp = lk1.ToList();
            khp.ForEach(k => k.InitOldData());
            return khp;
        }

        public static bool saves(DataUpdate<ThuongHieu_View> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    list.Inserts.ForEach(x =>
                    {
                        x.TrangThai = 1;
                        Context.getInstance().db.Entry(x.toTHUONG_HIEU()).State = System.Data.Entity.EntityState.Added;
                    });

                    list.Updates.ForEach(x =>
                    {
                        x.TrangThai = 1;
                        Context.getInstance().db.Entry(x.toTHUONG_HIEU()).State = System.Data.Entity.EntityState.Modified;
                    });

                    list.Deletes.ForEach(x =>
                    {
                        x.TrangThai = 0;
                        Context.getInstance().db.Entry(x.toTHUONG_HIEU()).State = System.Data.Entity.EntityState.Modified;
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
