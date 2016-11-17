using PresentationLayer.GlobalVariable;
using PresentationLayer.View;
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
            var lks = lk1.ToList();
            return lks;
        }
    }
}
