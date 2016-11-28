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
    public partial class UCDSPhieuNhap : UserControl
    {
        GridHelper<HoaDonNhap_View> gridThaoTac;

        public UCDSPhieuNhap()
        {
            InitializeComponent();
            InitVal();
        }

        private void InitVal()
        {
            setGridControl();
            gridThaoTac = new GridHelper<HoaDonNhap_View>(gridControl1);
        }

        private void setGridControl()
        {
            DateTime startD = dateBatDau.Value;
            DateTime endD = dateKetThuc.Value;
            gridControl1.DataSource = HoaDonNhap_DAL.getAll_HoaDonNhap_TheoThoiGian(startD, endD);
        }

        private void dateBatDau_ValueChanged(object sender, EventArgs e)
        {
            if (!checkDate())
            {
                MessageBox.Show("Ngày bắt đầu lớn hơn ngày kết thúc! Xin vui lòng nhập lại!");
            }
            else
            {
                setGridControl();
            }
        }

        private bool checkDate()
        {
            if (dateKetThuc.Value < dateBatDau.Value)
                return false;
            return true;
        }

        private void dateKetThuc_ValueChanged(object sender, EventArgs e)
        {
            if (!checkDate())
            {
                MessageBox.Show("Ngày kết thúc nhỏ hơn ngày bắt đầu! Xin vui lòng nhập lại!");
            }
            else
            {
                setGridControl();
            }
        }
    }
}
