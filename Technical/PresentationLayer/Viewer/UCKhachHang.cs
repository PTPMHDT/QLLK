using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.DAL;
using PresentationLayer.View;

namespace PresentationLayer
{
    public partial class UCKhachHang : UserControl
    {
        GridHelper<KhachHang_View> gridThaoTac;

        public UCKhachHang()
        {
            InitializeComponent();
            InitVal();
            btnXoa_Grid.Click += btnXoa_Grid_Click;
        }

        private void InitVal()
        {
            gridControl1.DataSource = KhachHang_DAL.getAll_KhachHang();
            gridThaoTac = new GridHelper<KhachHang_View>(gridControl1);

            gridThaoTac.Mapping("MaLoaiKhachHang", LoaiKhachHang_DAL.getAll_LoaiKhachHang());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            gridThaoTac.addRow();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataUpdate<KhachHang_View> listUpdate = gridThaoTac.update();

                if (KhachHang_DAL.saves(listUpdate))
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

        void btnXoa_Grid_Click(object sender, EventArgs e)
        {
            if (!gridThaoTac.isDeleted()) gridThaoTac.Delete();
            else
                gridThaoTac.Undo();
        }

    }
}
