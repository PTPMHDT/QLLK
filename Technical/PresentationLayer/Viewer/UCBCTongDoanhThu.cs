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
using PresentationLayer.GlobalVariable;
using DevExpress.XtraReports.UI;
using System.Globalization;

namespace PresentationLayer
{
    public partial class UCBCTongDoangThu : UserControl
    {
        GridHelper<HoaDon_View> gridThaoTac;
        List<HoaDon_View> lstHD = new List<HoaDon_View>();
        public UCBCTongDoangThu()
        {
            InitializeComponent();
            this.Load += UCBCTongDoangThu_Load;
            InitVal();
        }

        void UCBCTongDoangThu_Load(object sender, EventArgs e)
        {
            this.text_money.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.text_money.DisplayFormat.Format = new CultureInfo("vi-VN");
            this.text_money.DisplayFormat.FormatString = "c";

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
            lstHD = HoaDon_DAL.getAll_HoaDon_TheoThoiGian(startD, endD);
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
            HoaDon_View hd = gridView1.GetFocusedRow() as HoaDon_View;
            if (hd != null)
            {
                if(hd.Mode != TT.DELETE)
                {
                    var result = MessageBox.Show("Bạn có muốn xóa hóa đơn bán hàng " + hd.MaHoaDon + "?", "Lưu thông tin", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DataUpdate<CT_HOADON> dt = new DataUpdate<CT_HOADON>();
                        foreach (var item in hd.ChiTietHoaDon)
                        {
                            dt.Deletes.AddRange(item.toList_CT_HoaDon());
                        }
                        hd.MaNhanVienSua = Context.getInstance().nv.MaNhanVien;
                        hd.NgaySua = DateTime.Now;
                        if (HoaDon_DAL.del_HoaDon(hd, dt))
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

        private void btn_SerchSeri_Click(object sender, EventArgs e)
        {
            List<HoaDon_View> hdv = HoaDon_DAL.searchSeri(txt_Seri.Text.Trim());
            if (hdv.Count > 0)
            {
                gridControl1.DataSource = hdv;
                gridControl1.RefreshDataSource();
            }
            else
            {
                MessageBox.Show("Không tìm thấy!");
            }
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            List<TongHoaDon_View> l = new List<TongHoaDon_View>();

            TongHoaDon_View thd = new TongHoaDon_View();
            thd.NgayBatDau = dateBatDau.Value.ToString("dd/MM/yyyy");
            thd.NgayKetThuc = dateKetThuc.Value.ToString("dd/MM/yyyy");
            thd.NhanVien = Context.getInstance().nv.TenNhanVien;
            thd.ThoiGian = DateTime.Now;
            thd.List_HoaDon = new List<HoaDon_View>();

            foreach (var item in lstHD)
            {
                if(item.TrangThai == 1)
                {
                    thd.TongTien += item.TongTien;
                    thd.TongLoiNhuan += item.TongLoiNhuan;
                    thd.List_HoaDon.Add(item);
                }
            }
            l.Add(thd);

            if (l.Count > 0)
            {
                RTongKetHoaDon r = new RTongKetHoaDon(l);

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
