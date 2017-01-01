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
using System.Globalization;
using PresentationLayer.GlobalVariable;
using DevExpress.XtraReports.UI;

namespace PresentationLayer
{
    public partial class UCDSPhieuNhap : UserControl
    {
        GridHelper<HoaDonNhap_View> gridThaoTac;
        List<HoaDonNhap_View> lstHD = new List<HoaDonNhap_View>();

        public UCDSPhieuNhap()
        {
            InitializeComponent();
            this.Load += UCDSPhieuNhap_Load;
            InitVal();
        }

        void UCDSPhieuNhap_Load(object sender, EventArgs e)
        {
            this.text_money.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.text_money.DisplayFormat.Format = new CultureInfo("vi-VN");
            this.text_money.DisplayFormat.FormatString = "c";
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
            lstHD = HoaDonNhap_DAL.getAll_HoaDonNhap_TheoThoiGian(startD, endD);
            gridControl1.DataSource = lstHD;
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
            HoaDonNhap_View hd = gridView1.GetFocusedRow() as HoaDonNhap_View;
            if (hd != null)
            {
                using (var form = new Update_PhieuNhap(hd.MaHoaDon))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        setGridControl();
                    }
                }
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            List<TongHoaDonNhap_View> l = new List<TongHoaDonNhap_View>();

            TongHoaDonNhap_View thd = new TongHoaDonNhap_View();
            thd.NgayBatDau = dateBatDau.Value.ToString("dd/MM/yyyy");
            thd.NgayKetThuc = dateKetThuc.Value.ToString("dd/MM/yyyy");
            thd.NhanVien = Context.getInstance().nv.TenNhanVien;
            thd.ThoiGian = DateTime.Now;
            thd.List_HoaDonNhap = lstHD;
            foreach (var item in lstHD)
            {
                thd.TongTien += item.TongTien;
            }
            l.Add(thd);
            RTongKetHoaDonNhap r = new RTongKetHoaDonNhap(l);

            var tool = new ReportPrintTool(r);
            tool.ShowPreview();
        }
    }
}
