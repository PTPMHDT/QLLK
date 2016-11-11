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

namespace PresentationLayer
{
    public partial class formLogin : DevExpress.XtraEditors.XtraForm 
    {
        EventLogin ev;
        public string UserName { get { return textID.Text; } set { textID.Text = value; } }
        public string Password { get { return textPass.Text; } set { textPass.Text = value; } }

        public formLogin()
        {
            InitializeComponent();
            ev = new EventLogin(this);
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            ev.onLoadDefaultLogin();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            bool isOk =  ev.onCheckLogin();

            if (!isOk)
            {
                ev.onLoginFailure();
            }
            else
            {
                ev.onLoginSuccess(this);
                FormMain fMain = new FormMain();
                fMain.Show();
                this.Hide();
            }
        }

  
    }
}