using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PresentationLayer.GlobalVariable
{
    public class Context
    {
        static Context context =null;
        public OOD_QLLKEntities db { get; set; }
        public NguoiDung_View nv { get; set; }
        public formLogin formLogin { get; set; }
        public FormMain formMain { get; set; }
        public decimal phanTram_LoiNhuan_BanBuon { get; set; }
        public decimal phanTram_LoiNhuan_BanLe { get; set; }

        public static Context getInstance()
        {
            
            if (Context.context==null)
            {
                context = new Context();
            }
            return context;
        }
        public Context()
        {
            db = new OOD_QLLKEntities();
            phanTram_LoiNhuan_BanBuon = (decimal)0.05;
            phanTram_LoiNhuan_BanLe = (decimal)0.1;
        }

        public static void Refresh()
        {
            foreach (var i in Context.getInstance().db.ChangeTracker.Entries())
                i.State = EntityState.Unchanged;
        }
       
    }
}
