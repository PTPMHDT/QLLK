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
using PresentationLayer.ViewObject;

namespace PresentationLayer.Viewer
{
    public partial class Add_SeriNumber : DevExpress.XtraEditors.XtraForm
    {
        public List<string> list_Seri;

        public Add_SeriNumber()
        {
            InitializeComponent();
        }

        public Add_SeriNumber(CT_HoaDonNhap_View cthd)
        {
            InitializeComponent();
            initVal(cthd);
        }

        private void initVal(CT_HoaDonNhap_View cthd)
        {
            txt_MaLK.ReadOnly = true;
            txt_TenLK.ReadOnly = true;
            txt_MaLK.Text = cthd.MaLinhKien;
            txt_TenLK.Text = cthd.TenLinhKien;

            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));         
            dt.Columns.Add("SeriNumber", typeof(string));
            DataColumn col = new DataColumn("SeriNumber");
            for (int i = 0; i < cthd.SoLuong; i++)
            {
               if(cthd.SoSeri != null)
               {
                   if(i >= cthd.SoSeri.Count)
                       dt.Rows.Add(i, "");
                   else
                    dt.Rows.Add(i, cthd.SoSeri[i].ToString());                   
               }
               else
                   dt.Rows.Add(i,"");
            }
            gridControl1.DataSource = dt;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string str = "";
            list_Seri = new List<string>();
            foreach (DataRow item in ((DataTable)gridControl1.DataSource).Rows)
            {
                str = item["SeriNumber"].ToString().Trim();

                if(str.Equals(""))
                {
                    MessageBox.Show("Số Seri không được rỗng!");
                    return;
                }

                list_Seri.Add(str);  
            }

            if (list_Seri.Distinct().Count() != list_Seri.Count)
            {
                MessageBox.Show("Số Seri không được trùng nhau!");
                return;
            }

            //check them duoi csdl


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}