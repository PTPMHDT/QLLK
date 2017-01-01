using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class RTongKetHoaDonNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public RTongKetHoaDonNhap()
        {
            InitializeComponent();
            
        }

        public RTongKetHoaDonNhap(System.Collections.Generic.List<TongHoaDonNhap_View> hd)
        {
            InitializeComponent();
            this.DataSource = hd;
            
        }
    }
}
