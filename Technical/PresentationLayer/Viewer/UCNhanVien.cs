using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PresentationLayer.ViewObject;
using PresentationLayer.DAL;

namespace PresentationLayer
{
    public partial class UCNhanVien : UserControl
    {
        GridHelper<NhanVien_View> gridThaoTac;

        public UCNhanVien()
        {
            InitializeComponent();
            InitVal();
            btnXoa.Click += btnXoa_Click;
        }

        private void InitVal()
        {
            gridControl1.DataSource = NhanVien_DAL.getAll_NhanVien();
            gridThaoTac = new GridHelper<NhanVien_View>(gridControl1);
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            if (!gridThaoTac.isDeleted()) gridThaoTac.Delete();
            else
                gridThaoTac.Undo();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataUpdate<NhanVien_View> listUpdate = gridThaoTac.update();

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            //gridThaoTac.addRow();
        }
    }
}
