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
            this.btn_Update.Click +=btn_Update_Click;
            this.btnXuatFile.Click +=btnXuatFile_Click;
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
                if (hd.Mode != TT.DELETE)
                {
                    var result = MessageBox.Show("Bạn có muốn xóa hóa đơn nhập hàng " + hd.MaHoaDon + "?", "Lưu thông tin", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        HoaDonNhap_View hdn = HoaDonNhap_DAL.get_HoaDonNhap_By_MaHD(hd.MaHoaDon);
                        if(hdn.TrangThai == 2)
                        {
                            MessageBox.Show("Không thể xóa hóa đơn nhập hàng " + hd.MaHoaDon + " vì linh kiện đã được bán");
                            return;
                        }
                        DataUpdate<CT_HOADON_NHAPHANG> dt = new DataUpdate<CT_HOADON_NHAPHANG>();
                        foreach (var item in hd.ChiTietHoaDon)
                        {
                            dt.Deletes.AddRange(item.toList_CT_HoaDonNhap());
                        }
                        hd.MaNhanVienSua = Context.getInstance().nv.MaNhanVien;
                        hd.NgaySua = DateTime.Now;
                        if (HoaDonNhap_DAL.del_HoaDon(hd, dt))
                        {
                            MessageBox.Show("Lưu thông tin thành công!");
                            gridThaoTac.Delete();
                            gridControl1.RefreshDataSource();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra dữ liệu!");
                        }
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
            thd.List_HoaDonNhap = new List<HoaDonNhap_View>();
            foreach (var item in lstHD)
            {
                if (item.TrangThai != 0)
                {
                    thd.TongTien += item.TongTien;
                    thd.List_HoaDonNhap.Add(item);
                }
            }
            l.Add(thd);
            if(l.Count > 0)
            {
                RTongKetHoaDonNhap r = new RTongKetHoaDonNhap(l);

                var tool = new ReportPrintTool(r);
                tool.ShowPreview();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!");
            }
        }

    }
}
