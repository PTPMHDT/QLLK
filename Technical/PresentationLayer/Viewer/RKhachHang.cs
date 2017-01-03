using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class RKhachHang : DevExpress.XtraReports.UI.XtraReport
    {
        public RKhachHang()
        {
            InitializeComponent();
            
        }

        public RKhachHang(System.Collections.Generic.List<KhachHang_Report> hd)
        {
            InitializeComponent();
            this.DataSource = hd;
            
        }
    }
}
