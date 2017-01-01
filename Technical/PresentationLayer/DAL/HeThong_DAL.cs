using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.DAL
{
    public class HeThong_DAL
    {
        public static List<HeThong_View> getAll()
        {
            var kh1 = from kh in Context.getInstance().db.HETHONGs
                      select new HeThong_View
                      {
                          Ma = kh.Ma,
                          Ten = kh.Ten,
                          GiaTri = kh.GiaTri
                      };
            var khp = kh1.ToList();
            khp.ForEach(k => k.InitOldData());
            return khp;
        }

        public static HeThong_View getHeThongByMa(string ma)
        {
            var kh1 = from kh in Context.getInstance().db.HETHONGs
                      where kh.Ma == ma
                      select new HeThong_View
                      {
                          Ma = kh.Ma,
                          Ten = kh.Ten,
                          GiaTri = kh.GiaTri
                      };
            if(kh1 != null)
                return kh1.ToList()[0];
            
            return null;
        }

        public static bool saves(DataUpdate<HeThong_View> list)
        {
            using (var transaction = Context.getInstance().db.Database.BeginTransaction())
            {
                try
                {
                    list.Inserts.ForEach(x =>
                    {
                    });

                    list.Updates.ForEach(x =>
                    {
                        Context.getInstance().db.Entry(x.toHeThong()).State = System.Data.Entity.EntityState.Modified;
                    });

                    list.Deletes.ForEach(x =>
                    {
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
