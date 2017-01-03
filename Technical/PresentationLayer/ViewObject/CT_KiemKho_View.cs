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
        public string MaNhanVien { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string MaDonViTinh { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }
        public int TonSoSach { get; set; }
        public int ChenhLech { get; set; }

        public CT_KiemKho_View():base()
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
            ncc.TonSoSach = TonSoSach;
            ncc.ChenhLech = ChenhLech;
            return ncc;
        }
        public List<CT_KIEMKHO> toList_CT_KiemKho()
        {
            List<CT_KIEMKHO> lst = new List<CT_KIEMKHO>();

            foreach (var item in MaKiemKho)
            {
                CT_KIEMKHO cthd = new CT_KIEMKHO();
                cthd.MaKiemKho = MaKiemKho;
                cthd.MaLinhKien = MaLinhKien;
                cthd.SoLuong = SoLuong;
                cthd.GhiChu = GhiChu;
                cthd.TonSoSach = TonSoSach;
                cthd.ChenhLech = ChenhLech;
                lst.Add(cthd);
            }

            return lst;
        }
    }
}
