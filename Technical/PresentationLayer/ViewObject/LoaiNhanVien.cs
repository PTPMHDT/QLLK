using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class LoaiNhanVien_View
    {
        [IdSelection]
        public string MaLoaiNhanVien { get; set; }
        [DisplaySelection("Loại Nhân Viên")]
        public string TenLoaiNhanVien { get; set; }

        public int isQuanLyNhanVien { get; set; }
        public int isQuanLyKhachHang { get; set; }
        public int isQuanLyLinhKien { get; set; }
        public int isQuanLyKho { get; set; }
        public int isQuanLyHeThong { get; set; }
        public int isQuanLyBanHang { get; set; }
        public string MoTa { get; set; }

    }
}
