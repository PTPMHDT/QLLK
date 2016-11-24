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

namespace PresentationLayer
{
    public partial class UCLinhKien : UserControl
    {
        GridHelper<LinhKien_View> gridThaoTac;

        public UCLinhKien()
        {
            InitializeComponent();
            InitVal();
            btnXoa_Grid.Click += btnXoa_Grid_Click;
        }

        private void InitVal()
        {
            gridControl1.DataSource = LinhKien_DAL.getAll_LinhKien();

            gridThaoTac = new GridHelper<LinhKien_View>(gridControl1);
            gridThaoTac.Mapping("MaThuongHieu", ThuongHieu_DAL.getAll_ThuongHieu());
            gridThaoTac.Mapping("MaNhaCungCap", NhaCungCap_DAL.getAll_NhaCungCap());
            gridThaoTac.Mapping("MaDonViTinh", DonViTinh_DAL.getAll_DonViTinh());
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
                DataUpdate<LinhKien_View> listUpdate = gridThaoTac.update();

                //if (LinhKien_DAL.saves(listUpdate))
                //{
                //    MessageBox.Show("Lưu thông tin thành công!");
                //    InitVal();
                //}
                //else
                //{
                //    MessageBox.Show("Lưu thông tin thất bại!");
                //}
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
