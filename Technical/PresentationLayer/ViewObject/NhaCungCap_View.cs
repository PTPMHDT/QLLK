﻿using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationLayer.ViewObject
{
    public class NhaCungCap_View : CGrid
    {

        [IdSelection]
        public string MaNhaCungCap { get; set; }

        [DisplaySelection("Loại Khách Hàng")]
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string MoTa { get; set; }
        public int TrangThai { get; set; }
        public decimal Tong { get; set; }

        public NhaCungCap_View()
            : base()
        {
            MaNhaCungCap = NhaCungCap_DAL.get_NCCMax();
        }

        public override String ToString()
        {
            return TenNhaCungCap.Trim() + "   (" + MaNhaCungCap.Trim() + ")";
        }

        public NHACUNGCAP toNhaCungCap()
        {
            NHACUNGCAP ncc = Context.getInstance().db.NHACUNGCAPs.Where(key => key.MaNhaCungCap == MaNhaCungCap).FirstOrDefault();
            if (ncc == null)
            {
                ncc = new NHACUNGCAP();
                ncc.MaNhaCungCap = MaNhaCungCap;
            }
            ncc.MaNhaCungCap = MaNhaCungCap;
            ncc.TenNhaCungCap = TenNhaCungCap;
            ncc.DiaChi = DiaChi;
            ncc.SoDienThoai = SoDienThoai;
            ncc.MoTa = MoTa;
            ncc.Tong = Tong;
            ncc.TrangThai = TrangThai;
            return ncc;
        }
        
    }
}
