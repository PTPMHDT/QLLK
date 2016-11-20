using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class LinhKien_View : CGrid
    {
        public string MaLinhKien { get; set; }
        public string ThuongHieu { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }
        public string MaDonViTinh { get; set; }
        public string NhaCungCap { get; set; }
        public string TenLinhKien { get; set; }
        public Decimal GiaBanSi { get; set; }
        public Decimal GiaBanLe { get; set; }
        public Decimal GiaNhap { get; set; }
        public string DonViTinh { get; set; }
        public int TinhTrang { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public LINHKIEN toLinhKien()
        {
            LINHKIEN lk = new LINHKIEN();
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
            return lk;
        }
    }
}
