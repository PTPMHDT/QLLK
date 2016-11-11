using PresentationLayer.GlobalVariable;
using PresentationLayer.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PresentationLayer.DAL 
{
    public class NguoiDung_DAL 
    {

        public static List<NguoiDung_View> getAll_NguoiDung()
        {   
            var nguoidung = from nd in Context.getInstance().db.NGUOIDUNGs
                            select new NguoiDung_View()
                            {
                                MaNhanVien = nd.MaNhanVien,
                                TenDangNhap = nd.TenDangNhap,
                                TenNhanVien = nd.NHANVIEN.TenNhanVien,
                                MatKhau = nd.MatKhau
                            };
            return nguoidung.ToList();
        }

        public static NguoiDung_View get_NguoiDung_By_IdPass( string tenDN, string mk)
        {
            var nguoidung = from nd in Context.getInstance().db.NGUOIDUNGs
                            where nd.TenDangNhap == tenDN
                            where nd.MatKhau == mk
                            select new NguoiDung_View () {
                                MaNhanVien = nd.MaNhanVien,
                                TenDangNhap = nd.TenDangNhap,
                                TenNhanVien = nd.NHANVIEN.TenNhanVien,
                                MatKhau = nd.MatKhau
                            };
            List<NguoiDung_View> l = nguoidung.ToList();
            if (l.Count > 0)
                return l[0];
            return null;
        }
    }

 
}
