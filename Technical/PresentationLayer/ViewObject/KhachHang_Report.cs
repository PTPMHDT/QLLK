using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewObject
{
    public class KhachHang_Report
    {
        public string NhanVien { get; set; }
        public DateTime ThoiGian { get; set; }
        public Decimal TongTien { get; set; }
        public List<KhachHang_View> List_KhachHang { get; set; }
    }
}
