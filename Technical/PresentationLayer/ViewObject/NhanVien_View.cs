using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewObject
{
    public class NhanVien_View : CGrid
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string SoDienThoai { get; set; }
        public string MaLoaiNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }

        public NhanVien_View(int c)
            : base()
        {
            MaNhanVien = NhanVien_DAL.get_NhanVienMax(c);
        }

        public NhanVien_View()
            : base()
        {
        }

        public NHANVIEN toNhanVien()
        {
            NHANVIEN nv = Context.getInstance().db.NHANVIENs.Where(key => key.MaNhanVien == MaNhanVien).FirstOrDefault();
            if (nv == null)
            {
                nv = new NHANVIEN();
                nv.MaNhanVien = MaNhanVien;
            }
            nv.TenNhanVien = TenNhanVien;
            nv.TenDangNhap = TenDangNhap;
            nv.MatKhau = MatKhau;
            nv.SoDienThoai = SoDienThoai;
            nv.MaLoai = MaLoaiNhanVien;
            nv.DiaChi = DiaChi;
            nv.GhiChu = GhiChu;
            nv.TrangThai = TrangThai;
            return nv;
        }
    }
}
