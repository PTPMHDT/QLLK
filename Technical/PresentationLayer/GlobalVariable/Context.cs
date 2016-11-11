using PresentationLayer.View;
using System;
using System.Collections.Generic;
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
        }

       
    }
}
