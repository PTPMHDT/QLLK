using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class CT_KiemKho_View
    {
        public string MaKiemKho { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string MaDonViTinh { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }

        public CT_KiemKho_View()
        {
        }

        public CT_KIEMKHO toCT_KiemKho()
        {
            CT_KIEMKHO ncc = Context.getInstance().db.CT_KIEMKHO.Where(key => key.MaKiemKho == MaKiemKho).Where(key => key.MaLinhKien == MaLinhKien).FirstOrDefault();
            if (ncc == null)
            {
                ncc = new CT_KIEMKHO();
                ncc.MaKiemKho = MaKiemKho;
                ncc.MaLinhKien = MaLinhKien;
            }
            ncc.MaKiemKho = MaKiemKho;
            ncc.MaLinhKien = MaLinhKien;
            ncc.SoLuong = SoLuong;
            ncc.GhiChu = GhiChu;
            return ncc;
        }
    }
}
