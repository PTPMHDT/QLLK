using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PresentationLayer.Classes;
using PresentationLayer.GlobalVariable;
using PresentationLayer.DAL;
using PresentationLayer.ViewObject;

namespace PresentationLayer
{
    public partial class formLogin : DevExpress.XtraEditors.XtraForm 
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            textID.Text = "hungnv";
            textPass.Text = "hungnv";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Context.getInstance().nv = NhanVien_DAL.get_NhanVien_By_TenDN_And_Pass(textID.Text.Trim(), textPass.Text.Trim());
            if (Context.getInstance().nv == null)
            {
                MessageBox.Show("Đăng nhập không thành công!");
            }
            else
            {
                Context.getInstance().formLogin = this;
                FormMain fMain = new FormMain();

                Context.getInstance().formMain = fMain;
                fMain.Show();
                this.Hide();
            }
        }

  
    }
}