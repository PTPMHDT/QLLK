using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewObject
{
    public class HeThong_View : CGrid
    {
        public string MaHeThong { get; set; }
        public string Ten { get; set; }
        public string GiaTri { get; set; }

        public HeThong_View() : base()
        {  } 

        public HETHONG toHeThong()
        {
            HETHONG ht = Context.getInstance().db.HETHONGs.Where(key => key.Ma == MaHeThong).FirstOrDefault();
            if (ht == null)
            {
                ht = new HETHONG();
            }
            ht.Ma = MaHeThong;
            ht.Ten = Ten;
            ht.GiaTri = GiaTri;

            return ht;
        }
    }
}
