using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.DAL
{
    public class LoaiNhanVien_DAL
    {
        public static List<LoaiNhanVien_View> getAll_LoaiNhanVien()
        {
            var kh1 = from kh in Context.getInstance().db.LOAINHANVIENs
                      select new LoaiNhanVien_View
                      {
                          MaLoaiNhanVien = kh.MaLoaiNhanVien,
                          TenLoaiNhanVien = kh.TenLoaiNhanVien,
                          isQuanLyNhanVien = kh.IsQuanLyNhanVien,
                          isQuanLyKhachHang = kh.IsQuanLyKhachHang,
                          isQuanLyLinhKien = kh.IsQuanLyLinhKien,
                          isQuanLyKho = kh.IsQuanLyKho,
                          isQuanLyHeThong = kh.IsQuanLyHeThong,
                          isQuanLyBanHang = kh.IsQuanLyBanHang,
                          MoTa = kh.MoTa
                      };
            if(kh1 != null)
                return kh1.ToList();
            return null;
        }
    }
}