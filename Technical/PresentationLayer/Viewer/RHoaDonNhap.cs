using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class RHoaDonNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public RHoaDonNhap()
        {
            InitializeComponent();
            
        }

        public RHoaDonNhap(System.Collections.Generic.List<HoaDonNhap_View> hd)
        {
            InitializeComponent();
            this.DataSource = hd;
            
        }
    }
}
