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
    public partial class AddNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        public string maNCC_Return = "";

        public AddNhaCungCap()
        {
            InitializeComponent();
        }

        private void AddNhaCungCap_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            txt_maNCC.ReadOnly = true;
            txt_maNCC.Text = NhaCungCap_DAL.get_NCCMax();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            NhaCungCap_View ncc = new NhaCungCap_View();
            ncc.MaNhaCungCap = txt_maNCC.Text.Trim();
            ncc.TenNhaCungCap = txt_TenNCC.Text.Trim();
            ncc.DiaChi = txt_DiaChi.Text.Trim();
            ncc.MoTa = txt_Ghichu.Text.Trim();
            ncc.SoDienThoai = txt_SoDT.Text.Trim();
            ncc.TrangThai = 1;
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (NhaCungCap_DAL.add(ncc))
                {
                    MessageBox.Show("Lưu thông tin thành công!");
                    maNCC_Return = txt_maNCC.Text.Trim();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra dữ liệu!");
                }
            }
        }
    }
}