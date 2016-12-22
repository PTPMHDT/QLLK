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
using PresentationLayer.Viewer;

namespace PresentationLayer
{
    public partial class UCChiTietBanHang : UserControl
    {
        GridHelper<HoaDon_View> gridThaoTac;

        public UCChiTietBanHang()
        {
            InitializeComponent();
            InitVal();
        }

        private void InitVal()
        {
            setGridControl();
            gridThaoTac = new GridHelper<HoaDon_View>(gridControl1);
        }

        private void setGridControl()
        {
            DateTime startD = dateBatDau.Value;
            DateTime endD = dateKetThuc.Value;
            gridControl1.DataSource = HoaDon_DAL.getAll_HoaDon_TheoThoiGian(startD, endD);
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

        private void btn_Update_Click(object sender, EventArgs e)
        {
            HoaDon_View hd = gridView1.GetFocusedRow() as HoaDon_View;
            if (hd != null)
            {
                using (var form = new Update_BanHang(hd.MaHoaDon))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        //setCbxKhachHang(form.maKH_Return);
                    }
                }
            }
        }
    }
}
