using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PresentationLayer.DAL;
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class AddKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public string maKH_Return = "";

        public AddKhachHang()
        {
            InitializeComponent();
        }

        private void AddKhachHang_Load(object sender, EventArgs e)
        {
            txt_maKH.ReadOnly = true;
            txt_maKH.Text = KhachHang_DAL.get_KhachHangMax();
            cbx_LoaiKH.DataSource = LoaiKhachHang_DAL.getAll_LoaiKhachHang();
            cbx_LoaiKH.DisplayMember = "TenLoai";
            cbx_LoaiKH.ValueMember = "MaLoai";
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            KhachHang_View kh = new KhachHang_View();
            kh.MaKhachHang = txt_maKH.Text.Trim();
            kh.TenKhachHang = txt_TenKH.Text.Trim();
            kh.MaLoaiKhachHang = cbx_LoaiKH.SelectedValue.ToString().Trim();
            kh.DiaChi = txt_DiaChi.Text.Trim();
            kh.GhiChu = txt_Ghichu.Text.Trim();
            kh.SoDienThoai = txt_SoDT.Text.Trim();

             var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
             if (result == DialogResult.Yes)
             {
                 if (KhachHang_DAL.add(kh))
                 {
                     MessageBox.Show("Lưu thông tin thành công!");
                     maKH_Return = txt_maKH.Text.Trim();
                     this.DialogResult = DialogResult.OK;
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra dữ liệu!");
                 }
             }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}