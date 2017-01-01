using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewObject
{
    public class TongHoaDonNhap_View
    {
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string NhanVien { get; set; }
        public DateTime ThoiGian { get; set; }
        public Decimal TongTien { get; set; }
        public List<HoaDonNhap_View> List_HoaDonNhap { get; set; }
    }
}
