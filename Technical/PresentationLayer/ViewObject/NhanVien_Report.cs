using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewObject
{
    public class NhanVien_Report
    {
        public string NhanVien { get; set; }
        public DateTime ThoiGian { get; set; }
        public Decimal TongTien { get; set; }
        public List<NhanVien_View> List_NhanVien { get; set; }
    }
}
