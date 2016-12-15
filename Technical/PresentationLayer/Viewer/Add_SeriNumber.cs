using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PresentationLayer.Viewer
{
    public partial class Add_SeriNumber : DevExpress.XtraEditors.XtraForm
    {
        public List<string> list_Seri;

        public Add_SeriNumber()
        {
            InitializeComponent();
        }

        public Add_SeriNumber(string maLK, string tenLK,int rowCount)
        {
            InitializeComponent();
            initVal(maLK, tenLK,rowCount);
        }

        private void initVal(string maLK, string tenLK, int r)
        {
            txt_MaLK.ReadOnly = true;
            txt_TenLK.ReadOnly = true;
            txt_MaLK.Text = maLK;
            txt_TenLK.Text = tenLK;

            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));         
            dt.Columns.Add("SeriNumber", typeof(string));
            DataColumn col = new DataColumn("SeriNumber");
            for (int i = 1; i <= r; i++)
            {
                dt.Rows.Add(i,"");
            }
            gridControl1.DataSource = dt;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            list_Seri = new List<string>();
            foreach (DataRow item in ((DataTable)gridControl1.DataSource).Rows)
            {
                list_Seri.Add(item["SeriNumber"].ToString());  
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}