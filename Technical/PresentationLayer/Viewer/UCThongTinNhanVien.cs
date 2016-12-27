using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.DAL;
using PresentationLayer.ViewObject;
using PresentationLayer.GlobalVariable;

namespace PresentationLayer
{
    public partial class UCThongTinNhanVien : UserControl
    {
        NhanVien_View nv = new NhanVien_View();

        public UCThongTinNhanVien()
        {
            InitializeComponent();
            this.Load += UCThongTinNhanVien_Load;
            this.changePass.Click += changePass_Click;
        }

        void changePass_Click(object sender, EventArgs e)
        {
            txtMK1.Visible = true;
            txtMK2.Visible = true;
            lbMK1.Visible = true;
            lbMK2.Visible = true;
        }

        void UCThongTinNhanVien_Load(object sender, EventArgs e)
        {
            InitVal();
        }

        private void InitVal()
        {
            txtMK1.Visible = false;
            txtMK2.Visible = false;
            lbMK1.Visible = false;
            lbMK2.Visible = false;
            LoadData(Context.getInstance().nv);
        }

        private void LoadData(NhanVien_View nvV)
        {
            txtMaNhanVien.Text = nvV.MaNhanVien;
            txtTenNhanVien.Text = nvV.TenNhanVien;
            txtTenDN.Text = nvV.TenDangNhap;
            txtSDT.Text = nvV.SoDienThoai;
            txtDiaChi.Text = nvV.DiaChi;
            
        }

        private NhanVien_View getData()
        {
            nv.MaNhanVien = txtMaNhanVien.Text.Trim();
            if(txtTenNhanVien.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập tên Nhân viên!");
                return null;
            }
            nv.TenNhanVien = txtTenNhanVien.Text.Trim();
            if (txtSDT.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập Số điện thoại!");
                return null;
            }
            nv.SoDienThoai = txtSDT.Text.Trim();
            if (!testThayDoi())
                return null;
            return nv;
        }

        private bool testThayDoi()
        {
            if (txtTenDN.Text.Trim().Equals(""))
            {
                MessageBox.Show("Chưa nhập tên Đăng nhập!");
                return false;
            }
            nv.TenDangNhap = txtTenDN.Text.Trim();
            if (txtMK1.Visible)
            {
                if (txtMK1.Text.Trim().Equals("") || txtMK2.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Chưa nhập mật khẩu!");
                    return false;
                }
                if(!txtMK1.Text.Trim().Equals(txtMK2.Text.Trim()))
                {
                    MessageBox.Show("Mật khẩu không khớp!");
                    return false;
                }
                nv.MatKhau = txtMK1.Text.Trim();
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataUpdate<NhanVien_View> listUpdate = new DataUpdate<NhanVien_View>();
                if (getData() != null)
                    listUpdate.Updates.Add(nv);
                else
                    return;
                
                if (NhanVien_DAL.saves(listUpdate))
                {
                    MessageBox.Show("Lưu thông tin thành công!");
                    InitVal();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin thất bại!");
                }
            }  
        }

    }
}
