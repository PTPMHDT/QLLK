using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class LoaiNhanVien_View : CGrid
    {
        [IdSelection]
        public string MaLoaiNhanVien { get; set; }
        [DisplaySelection("Loại Nhân Viên")]
        public string TenLoaiNhanVien { get; set; }

        public int IsQuanLyNhanVien { get; set; }
        public int IsQuanLyKhachHang { get; set; }
        public int IsQuanLyLinhKien { get; set; }
        public int IsQuanLyKho { get; set; }
        public int IsQuanLyHeThong { get; set; }
        public int IsQuanLyBanHang { get; set; }
        public string MoTa { get; set; }

        public LoaiNhanVien_View(int c)
            : base()
        {
            //MaKhachHang = KhachHang_DAL.get_KhachHangMax(c);
        }

        public LoaiNhanVien_View()
            : base()
        {
        }

        public LoaiNhanVien_ViewBoolen Change()
        {
            LoaiNhanVien_ViewBoolen l = new LoaiNhanVien_ViewBoolen();
            l.MaLoaiNhanVien = MaLoaiNhanVien;
            l.TenLoaiNhanVien = TenLoaiNhanVien;
            l.MoTa = MoTa;
            l.IsQuanLyBanHang = Convert.ToBoolean(IsQuanLyBanHang);
            l.IsQuanLyHeThong = Convert.ToBoolean(IsQuanLyHeThong);
            l.IsQuanLyKhachHang = Convert.ToBoolean(IsQuanLyKhachHang);
            l.IsQuanLyKho = Convert.ToBoolean(IsQuanLyKho);
            l.IsQuanLyLinhKien = Convert.ToBoolean(IsQuanLyLinhKien);
            l.IsQuanLyNhanVien = Convert.ToBoolean(IsQuanLyNhanVien);
            return l;
        }

        public LOAINHANVIEN toLOAINHANVIEN()
        {
            LOAINHANVIEN th = Context.getInstance().db.LOAINHANVIENs.Where(key => key.MaLoaiNhanVien == MaLoaiNhanVien).FirstOrDefault();
            if (th == null)
            {
                th = new LOAINHANVIEN();
            }
            th.MaLoaiNhanVien = MaLoaiNhanVien;
            th.TenLoaiNhanVien = TenLoaiNhanVien;
            th.IsQuanLyBanHang = Convert.ToInt32(IsQuanLyBanHang);
            th.IsQuanLyHeThong = Convert.ToInt32(IsQuanLyHeThong);
            th.IsQuanLyKhachHang = Convert.ToInt32(IsQuanLyKhachHang);
            th.IsQuanLyKho = Convert.ToInt32(IsQuanLyKho);
            th.IsQuanLyLinhKien = Convert.ToInt32(IsQuanLyLinhKien);
            th.IsQuanLyNhanVien = Convert.ToInt32(IsQuanLyNhanVien);
            th.MoTa = MoTa;
            return th;
        }
    }

    public class LoaiNhanVien_ViewBoolen : CGrid
    {
        [IdSelection]
        public string MaLoaiNhanVien { get; set; }
        [DisplaySelection("Loại Nhân Viên")]
        public string TenLoaiNhanVien { get; set; }

        public bool IsQuanLyNhanVien { get; set; }
        public bool IsQuanLyKhachHang { get; set; }
        public bool IsQuanLyLinhKien { get; set; }
        public bool IsQuanLyKho { get; set; }
        public bool IsQuanLyHeThong { get; set; }
        public bool IsQuanLyBanHang { get; set; }
        public string MoTa { get; set; }

        public LoaiNhanVien_ViewBoolen(int c)
            : base()
        {
            MaLoaiNhanVien = LoaiNhanVien_DAL.get_LoaiNhanVienMax(c);
        }

        public LoaiNhanVien_ViewBoolen()
            : base()
        {
        }

        public LOAINHANVIEN toLOAINHANVIEN()
        {
            LOAINHANVIEN th = Context.getInstance().db.LOAINHANVIENs.Where(key => key.MaLoaiNhanVien == MaLoaiNhanVien).FirstOrDefault();
            if (th == null)
            {
                th = new LOAINHANVIEN();
            }
            th.MaLoaiNhanVien = MaLoaiNhanVien;
            th.TenLoaiNhanVien = TenLoaiNhanVien;
            th.IsQuanLyBanHang = Convert.ToInt32(IsQuanLyBanHang);
            th.IsQuanLyHeThong = Convert.ToInt32(IsQuanLyHeThong);
            th.IsQuanLyKhachHang = Convert.ToInt32(IsQuanLyKhachHang);
            th.IsQuanLyKho = Convert.ToInt32(IsQuanLyKho);
            th.IsQuanLyLinhKien = Convert.ToInt32(IsQuanLyLinhKien);
            th.IsQuanLyNhanVien = Convert.ToInt32(IsQuanLyNhanVien);
            th.MoTa = MoTa;
            return th;
        }
    }
}
