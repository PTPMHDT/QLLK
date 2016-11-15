using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class Kho_View
    {
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public int SoLuong { get; set; }
        public string ThuongHieu { get; set; }
        public string NhaCungCap { get; set; }
        public Decimal GiaBanSi { get; set; }
        public Decimal GiaBanLe { get; set; }
        public string DonViTinh { get; set; }
        public int TinhTrangLK { get; set; }
        public string MoTaLK { get; set; }
        public string ThoiGianBaoHanh { get; set; }
    }
}
