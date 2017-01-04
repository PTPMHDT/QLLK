using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using PresentationLayer.Viewer;
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
            btnSale.Enabled = false;
            btnKhachHang.Enabled = false;
            btnLoaiLinhKien.Enabled = false;

            btnLinhKien.Enabled = false;
            btn_HeThong.Enabled = false;
            btnNhanVien.Enabled = false;
            btn_LoaiNhanVien.Enabled = false;

            btnKho.Enabled = false;
            btnNhaCungCap.Enabled = false;
            btnNhapKho.Enabled = false;
            btnPhieuNhapKho.Enabled = false;
            btnKiemKho.Enabled = false;

            btBaoCaoNhaCungCap.Enabled = false;
            btnChiTietBanHang.Enabled = false;
            btnDoanhThuChiTiet.Enabled = false;
            btnDoanhThuNhanVien.Enabled = false;
            btnKetQuaKinhDoanh.Enabled = false;
            btnTongDoanhThu.Enabled = false;

            LoaiNhanVien_ViewBoolen lnv = LoaiNhanVien_DAL.get_LoaiNhanVien_ByMaLoaiNV(Context.getInstance().nv.MaLoaiNhanVien);
            if (lnv.IsQuanLyBanHang)
            {
                btnSale.Enabled = true;
                btnKhachHang.Enabled = true;
                btnLoaiLinhKien.Enabled = true;
            }
            if (lnv.IsQuanLyKhachHang)
            {
                btBaoCaoNhaCungCap.Enabled = true;
                btnChiTietBanHang.Enabled = true;
                btnDoanhThuChiTiet.Enabled = true;
                btnDoanhThuNhanVien.Enabled = true;
                btnKetQuaKinhDoanh.Enabled = true;
                btnTongDoanhThu.Enabled = true;
            }
            if (lnv.IsQuanLyKho)
            {
                btnKho.Enabled = true;
                btnNhaCungCap.Enabled = true;
                btnNhapKho.Enabled = true;
                btnPhieuNhapKho.Enabled = true;
                btnKiemKho.Enabled = true;
            }
            if (lnv.IsQuanLyLinhKien)
            {
                btnLinhKien.Enabled = true;
                btnLoaiLinhKien.Enabled = true;
                btnNhaCungCap.Enabled = true;
            }

            if (lnv.IsQuanLyNhanVien)
            {
                btnNhanVien.Enabled = true;
                btn_LoaiNhanVien.Enabled = true;
            }
            if (lnv.IsQuanLyHeThong)
            {
                btn_HeThong.Enabled = true;
            }

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

        private void btnChiTietBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCBCKiemKho();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }

        private void btnTongHopBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucLinhKien = new UCKhoLinhKien();
            ucLinhKien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucLinhKien);
        }

        private void btnDoanhThuNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucNhanVien = new UCBCNhanVien();
            ucNhanVien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucNhanVien);
        }

        private void btnDoanhThuChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucNhanVien = new UCBCKhachHang();
            ucNhanVien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucNhanVien);
        }

        private void btnTongDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucNhanVien = new UCBCTongDoangThu();
            ucNhanVien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucNhanVien);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucNhanVien = new UCLienHe();
            ucNhanVien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucNhanVien);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelMain.Controls.Clear();
            var ucNhanVien = new UCGiupDo();
            ucNhanVien.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ucNhanVien);
        }

    }
}
