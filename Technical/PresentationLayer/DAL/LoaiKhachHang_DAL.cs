using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.DAL
{
    public class LoaiKhachHang_DAL
    {
        public static List<LoaiKhachHang_View> getAll_LoaiKhachHang()
        {
            var kh1 = from kh in Context.getInstance().db.LOAIs
                      select new LoaiKhachHang_View
                      {
                          MaLoai = kh.MaLoai,
                          TenLoai = kh.TenLoai   ,
                          MoTa = kh.MoTa
                      };
            return kh1.ToList();
        }
    }
}
