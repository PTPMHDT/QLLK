using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewObject
{
    public class TongHoaDon_View
    {
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }
        public string NhanVien { get; set; }
        public DateTime ThoiGian { get; set; }
        public Decimal TongTien { get; set; }
        public Decimal TongLoiNhuan { get; set; }
        public List<HoaDon_View> List_HoaDon { get; set; }
    }
}
