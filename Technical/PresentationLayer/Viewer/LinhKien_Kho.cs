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
    public partial class LinhKien_Kho : DevExpress.XtraEditors.XtraForm
    {
        GridHelper<LinhKien_View> gridThaoTac;

        public LinhKien_Kho()
        {
            InitializeComponent();
            InitVal();
        }

        private void InitVal()
        {
            gridControl1.DataSource = new List<LinhKien_View>();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}