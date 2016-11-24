using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class RHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public RHoaDon()
        {
            InitializeComponent();
            
        }

        public RHoaDon(System.Collections.Generic.List<HoaDon_View> hd)
        {
            InitializeComponent();
            this.DataSource = hd;
        }
    }
}
