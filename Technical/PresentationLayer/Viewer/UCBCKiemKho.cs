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
    public partial class UCBCKiemKho : UserControl
    {

        public UCBCKiemKho()
        {
            InitializeComponent();
            this.Load += UCDSPhieuNhap_Load;

        }

        void UCDSPhieuNhap_Load(object sender, EventArgs e)
        {
            InitVal();
        }

        private void InitVal()
        {
            gridControl1.DataSource = BC_KiemKho_DAL.getAll_BaoCaoKiemKho(dateBatDau.Value, dateKetThuc.Value);
            gridControl1.RefreshDataSource();
        }

        private void setGridControl()
        {
            DateTime startD = dateBatDau.Value;
            DateTime endD = dateKetThuc.Value;
            
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
            
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            //List<TongHoaDonNhap_View> l = new List<TongHoaDonNhap_View>();

            //TongHoaDonNhap_View thd = new TongHoaDonNhap_View();
            //thd.NgayBatDau = dateBatDau.Value.ToString("dd/MM/yyyy");
            //thd.NgayKetThuc = dateKetThuc.Value.ToString("dd/MM/yyyy");
            //thd.NhanVien = Context.getInstance().nv.TenNhanVien;
            //thd.ThoiGian = DateTime.Now;
            //thd.List_HoaDonNhap = lstHD;
            //foreach (var item in lstHD)
            //{
            //    thd.TongTien += item.TongTien;
            //}
            //l.Add(thd);
            //RTongKetHoaDonNhap r = new RTongKetHoaDonNhap(l);

            //var tool = new ReportPrintTool(r);
            //tool.ShowPreview();
        }
    }
}
