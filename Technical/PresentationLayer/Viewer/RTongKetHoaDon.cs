using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class RTongKetHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public RTongKetHoaDon()
        {
            InitializeComponent();
            
        }

        public RTongKetHoaDon(System.Collections.Generic.List<TongHoaDon_View> hd)
        {
            InitializeComponent();
            this.DataSource = hd;
            
        }
    }
}
