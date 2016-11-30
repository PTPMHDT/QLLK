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
    public partial class Add_LinhKien : DevExpress.XtraEditors.XtraForm
    {
        GridHelper<LinhKien_View> gridThaoTac;

        public Add_LinhKien()
        {
            InitializeComponent();
            InitVal();
            btnXoa_Grid.Click += btnXoa_Grid_Click;
        }

        private void InitVal()
        {
            gridControl1.DataSource = new List<LinhKien_View>();
            gridThaoTac = new GridHelper<LinhKien_View>(gridControl1);
            gridThaoTac.Mapping("MaThuongHieu", ThuongHieu_DAL.getAll_ThuongHieu());
            gridThaoTac.Mapping("MaNhaCungCap", NhaCungCap_DAL.getAll_NhaCungCap());
            gridThaoTac.Mapping("MaDonViTinh", DonViTinh_DAL.getAll_DonViTinh());
            gridThaoTac.addRow();
        }

        private void btnXoa_Grid_Click(object sender, EventArgs e)
        {
            if (!gridThaoTac.isDeleted()) gridThaoTac.Delete();
            else
                gridThaoTac.Undo();
        }

        private void Add_LinhKien_Load(object sender, EventArgs e)
        {
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}