using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class LinhKien_View : CGrid
    {
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public Decimal GiaBanSi { get; set; }
        public Decimal GiaBanLe { get; set; }
        public Decimal GiaNhap { get; set; }
        public int TinhTrang { get; set; }
        public string MoTa { get; set; }
        public int ThoiGianBaoHanh { get; set; }

        public override String ToString()
        {
            return TenLinhKien.Trim() + "   (" + TenLinhKien.Trim() + ")";
        }

        public LinhKien_View(int c)
            : base()
        {
            MaLinhKien = LinhKien_DAL.get_LinhKienMax(c);
        }

        public LinhKien_View()
            : base()
        { }

        public LINHKIEN toLinhKien()
        {
            LINHKIEN lk = Context.getInstance().db.LINHKIENs.Where(key => key.MaLinhKien == MaLinhKien).FirstOrDefault();
            if (lk == null)
            {
                lk = new LINHKIEN();
                lk.MaLinhKien = MaLinhKien;
            }
            lk.MaLinhKien = MaLinhKien;
            lk.TenLinhKien = TenLinhKien;
            lk.MaNhaCungCap = MaNhaCungCap;
            lk.MaThuongHieu = MaThuongHieu;
            lk.MaDonViTinh = MaDonViTinh;
            lk.GiaBanSi = GiaBanSi;
            lk.GiaBanLe = GiaBanLe;
            lk.TinhTrang = TinhTrang;
            lk.ThoiGianBaoHanh = ThoiGianBaoHanh;
            lk.GiaNhap = GiaNhap;
            lk.MoTa = MoTa;
            return lk;
        }
    }
}
