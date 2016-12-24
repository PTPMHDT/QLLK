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
    public partial class UCKhoLinhKien : UserControl
    {
        public UCKhoLinhKien()
        {
            InitializeComponent();
            InitVal();
        }

        private void InitVal()
        {
            gridControl1.DataSource = Kho_DAL.getAll_LinhKien();
        }

    }
}
