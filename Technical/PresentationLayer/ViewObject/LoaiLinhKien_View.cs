using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class LoaiLinhKien_View : CGrid
    {
        [IdSelection]
        public string MaThuongHieu { get; set; }

        [DisplaySelection("Thương Hiệu")]
        public string TenThuongHieu { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }

        public LoaiLinhKien_View(int c)
            : base()
        {
            
        }

        public LoaiLinhKien_View()
            : base()
        {
        }

        public override String ToString()
        {
            return TenThuongHieu.Trim() + "   (" + MaThuongHieu.Trim() + ")";
        }

        public THUONGHIEU toThuongHieu()
        {
            THUONGHIEU th = Context.getInstance().db.THUONGHIEUx.Where(key => key.MaThuongHieu == MaThuongHieu).FirstOrDefault();
            if (th == null)
            {
                th = new THUONGHIEU();
                th.MaThuongHieu = MaThuongHieu;
            }
            th.MaThuongHieu = MaThuongHieu;
            th.TenThuongHieu = TenThuongHieu;
            th.TrangThai = TrangThai;
            th.MoTa = MoTa;
            return th;
        }
    }
}
