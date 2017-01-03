using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class BC_KiemKho_View
    {
        public string MaKiemKho { get; set; }
        public DateTime NgayKiem { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string MaDonViTinh { get; set; }
        public string DonViTinh { get; set; }
        public int TonKho { get; set; }
        public int TonSoSach { get; set; }
        public int ChenhLech { get; set; }
    }
}
