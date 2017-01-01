﻿using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using PresentationLayer.ViewObject;
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
            this.Load += FormMain_Load;
        }

        void FormMain_Load(object sender, EventArgs e)
        {
            LoaiNhanVien_ViewBoolen lnv = LoaiNhanVien_DAL.get_LoaiNhanVien_ByMaLoaiNV(Context.getInstance().nv.MaLoaiNhanVien);
            if (!lnv.IsQuanLyBanHang)
            {
                btnChiTietBanHang.Enabled = false;
                btnSale.Enabled = false;
            }
            if (!lnv.IsQuanLyKhachHang)
                btnKhachHang.Enabled = false;
            if (!lnv.IsQuanLyKho)
            {
                btnNhapKho.Enabled = false;
            }
            if (!lnv.IsQuanLyLinhKien)
                btnLinhKien.Enabled = false;

            if (!lnv.IsQuanLyNhanVien)
                btnNhanVien.Enabled = false;

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

        private void btnPhieuNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucDSNhapHang = new UCDSPhieuNhap();
            ucDSNhapHang.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucDSNhapHang);
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucNhanVien = new UCNhanVien();
            ucNhanVien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucNhanVien);
        }

        private void btnXuatKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCKhoLinhKien();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }

        private void btnKiemKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCKiemKho();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }

        private void btnLoaiLinhKien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCLoaiLinhKien();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCThongTinNhanVien();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }

        private void btn_LoaiNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCLoaiNhanVien();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }
        //dang xuat
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            Context.getInstance().formLogin.Show();
        }

        private void btn_HeThong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCHeThong();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình hay không?", "Hệ thống", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
