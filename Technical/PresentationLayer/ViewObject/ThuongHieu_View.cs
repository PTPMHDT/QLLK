using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class ThuongHieu_View
    {
        [IdSelection]
        public string MaThuongHieu { get; set; }
        [DisplaySelection("Thương Hiệu")]
        public string TenThuongHieu { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public THUONGHIEU toTHUONG_HIEU()
        {
            THUONGHIEU table = new THUONGHIEU();
            table.MaThuongHieu = MaThuongHieu;
            table.TenThuongHieu = TenThuongHieu;
            table.MoTa = MoTa;
            table.TrangThai = TrangThai;
            return table;
        }
    }
}
