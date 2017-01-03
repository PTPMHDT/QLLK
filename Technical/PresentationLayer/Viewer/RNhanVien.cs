using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class RNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public RNhanVien()
        {
            InitializeComponent();
            
        }

        public RNhanVien(System.Collections.Generic.List<NhanVien_Report> hd)
        {
            InitializeComponent();
            this.DataSource = hd;
            
        }
    }
}
