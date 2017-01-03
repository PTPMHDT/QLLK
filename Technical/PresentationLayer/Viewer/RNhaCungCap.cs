using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class RNhaCungCap : DevExpress.XtraReports.UI.XtraReport
    {
        public RNhaCungCap()
        {
            InitializeComponent();
            
        }

        public RNhaCungCap(System.Collections.Generic.List<NhaCungCap_Report> hd)
        {
            InitializeComponent();
            this.DataSource = hd;
            
        }
    }
}
