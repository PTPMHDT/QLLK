using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class UCPhieuBanHang : UserControl
    {
        public UCPhieuBanHang()
        {
            InitializeComponent();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            FormChiTietPhieuBanHang fChiTietPhieuBanHang = new FormChiTietPhieuBanHang();
            fChiTietPhieuBanHang.Show();
        }
    }
}
