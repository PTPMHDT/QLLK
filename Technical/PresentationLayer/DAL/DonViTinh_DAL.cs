using PresentationLayer.GlobalVariable;
using PresentationLayer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PresentationLayer.DAL
{
    public class DonViTinh_DAL
    {
        public static List<DonViTinh_View> getAll_DonViTinh()
        {
            var lk1 = from lk in Context.getInstance().db.DONVITINHs
                      select new DonViTinh_View()
                      {
                          MaDonViTinh = lk.MaDonViTinh,
                          TenDonViTinh = lk.TenDonViTinh,
                          MoTa = lk.MoTa
                      };
            var lks = lk1.ToList();
            //lks.ForEach(x => x.InitOldData());
            return lks;
        }
    }
}
