using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class KiemKho_View
    {
        public string MaKiemKho { get; set; }
        public DateTime NgayKiem { get; set; }
        public string NhanVien { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string NhomHang { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string MaDonViTinh { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }

        public List<CT_KiemKho_View> ChiTietKiemKho { get; set; }

        public KiemKho_View()
        {
        }

        public KIEMKHO toKiemKho()
        {
            KIEMKHO ncc = Context.getInstance().db.KIEMKHOes.Where(key => key.MaKiemKho == MaKiemKho).FirstOrDefault();
            if (ncc == null)
            {
                ncc = new KIEMKHO();
                ncc.MaKiemKho = MaKiemKho;
            }
            ncc.MaKiemKho = MaKiemKho;
            ncc.NgayKiem = NgayKiem;
            ncc.MaNhanVien  = NhanVien;
            ncc.GhiChu = GhiChu;
            ncc.TrangThai = TrangThai;
            return ncc;
        }
    }
}
