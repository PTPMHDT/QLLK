using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class ThuongHieu_View : CGrid
    {
        [IdSelection]
        public string MaThuongHieu { get; set; }
        [DisplaySelection("Thương Hiệu")]
        public string TenThuongHieu { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }

        public ThuongHieu_View(int c)
            : base()
        {
            //MaKhachHang = KhachHang_DAL.get_KhachHangMax(c);
        }

        public ThuongHieu_View()
            : base()
        {
        }

        public THUONGHIEU toTHUONG_HIEU()
        {
            THUONGHIEU th = Context.getInstance().db.THUONGHIEUx.Where(key => key.MaThuongHieu == MaThuongHieu).FirstOrDefault();
            if (th == null)
            {
                th = new THUONGHIEU();
                th.MaThuongHieu = MaThuongHieu;
            }
            th.MaThuongHieu = MaThuongHieu;
            th.TenThuongHieu = TenThuongHieu;
            th.MoTa = MoTa;
            th.TrangThai = TrangThai;
            return th;
        }
    }
}
