using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class LoaiKhachHang_View
    {
        [IdSelection]
        public string MaLoai { get; set; }
        [DisplaySelection("Loại Khách Hàng")]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }

    }
}
