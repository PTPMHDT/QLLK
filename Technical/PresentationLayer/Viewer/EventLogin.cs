using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer.Classes
{
    public class EventLogin
    {
        formLogin me;
        public EventLogin(formLogin me)
        {
            this.me = me;
        }

        internal void onLoginSuccess(formLogin me)
        {
            Context.getInstance().formLogin = me;
           
        }

        internal void onLoginFailure()
        {
            MessageBox.Show("Đăng nhập không thành công!");
        }

        internal bool onCheckLogin()
        {
            Context.getInstance().nv = NguoiDung_DAL.get_NguoiDung_By_IdPass(me.UserName, me.Password);
            if (Context.getInstance().nv == null) return false;
            return true;
        }


        internal void onLoadDefaultLogin()
        {
            me.UserName = "hungnv";
            me.Password = "hungnv";
        }
    }
}
