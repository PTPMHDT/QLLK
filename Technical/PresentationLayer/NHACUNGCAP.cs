//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHACUNGCAP
    {
        public NHACUNGCAP()
        {
            this.HOADON_NHAPHANG = new HashSet<HOADON_NHAPHANG>();
            this.LINHKIENs = new HashSet<LINHKIEN>();
        }
    
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> TrangThai { get; set; }
    
        public virtual ICollection<HOADON_NHAPHANG> HOADON_NHAPHANG { get; set; }
        public virtual ICollection<LINHKIEN> LINHKIENs { get; set; }
    }
}
