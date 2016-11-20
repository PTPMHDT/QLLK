using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.FormClosed += FormMain_FormClosed;
        }

        void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Context.getInstance().formLogin.Close();
        }

        private void btnLinhKien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCLinhKien();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }

        private void btnSale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucBanHang = new UCBanHang("");
            ucBanHang.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucBanHang);
        }

        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucKhachHang = new UCKhachHang();
            ucKhachHang.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucKhachHang);
        }

        private void btnNhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucNCC = new UCNhaCungCap();
            ucNCC.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucNCC);
        }

        private void btnNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucNhapHang = new UCNhapKho("");
            ucNhapHang.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucNhapHang);
        }

        private void btnPhieuBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucChiTietBanHang = new UCChiTietBanHang();
            ucChiTietBanHang.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucChiTietBanHang);
        }
    }
}
