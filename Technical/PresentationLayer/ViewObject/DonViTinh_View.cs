using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class DonViTinh_View
    {
        public string MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public string MoTa { get; set; }

        public DONVITINH toDONVITINH()
        {
            DONVITINH table = new DONVITINH();
            table.MaDonViTinh = MaDonViTinh;
            table.TenDonViTinh = TenDonViTinh;
            table.MoTa = MoTa;
            return table;
        }
    }
}
