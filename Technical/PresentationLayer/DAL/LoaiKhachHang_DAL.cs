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
            var kh1 = from kh in Context.getInstance().db.LOAIKHACHHANGs
                      select new LoaiKhachHang_View
                      {
                          MaLoai = kh.MaLoaiKhachHang,
                          TenLoai = kh.TenLoaiKhachHang   ,
                          MoTa = kh.MoTa
                      };
            return kh1.ToList();
        }
    }
}
