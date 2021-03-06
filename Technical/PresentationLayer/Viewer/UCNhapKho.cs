﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PresentationLayer.TestFolder;
using PresentationLayer.ViewObject;
using PresentationLayer.DAL;
using PresentationLayer.GlobalVariable;
using PresentationLayer.Viewer;
using PresentationLayer.Classes;
using System.IO;
using System.Globalization;
using DevExpress.XtraReports.UI;

namespace PresentationLayer
{
    public partial class UCNhapKho : UserControl
    {
        DataTable dt_linhKien = new DataTable();
        List<CT_HoaDonNhap_View> ls_cthd;
        HoaDonNhap_View hoadonnhap;
        bool isNew;     //bien kiem tra xem dang o che do New hay la update

        public UCNhapKho() { }

        public UCNhapKho(string maHoaDon)
        {
            InitializeComponent();
            this.Load += UCNhapKho_Load;

            InnitVal(maHoaDon);
            this.btnXoa.Click += btnXoa_Click;
            this.repositoryItemSpinEdit1.EditValueChanged += repositoryItemSpinEdit1_EditValueChanged;
            cbxTenNCC.LostFocus += cbxTenNCC_LostFocus;
            add_seriNumber.Click += add_seriNumber_Click;
            //this.text_money.Leave += text_money_Leave;
        }

        //void text_money_Leave(object sender, EventArgs e)
        //{
        //    CT_HoaDonNhap_View lk = gridView1.GetFocusedRow() as CT_HoaDonNhap_View;
        //    var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
        //    if (result == DialogResult.Yes)
        //    { }
        //}


        void add_seriNumber_Click(object sender, EventArgs e)
        {
            CT_HoaDonNhap_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDonNhap_View;
            using (var form = new Add_SeriNumber(ct_hd))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ct_hd.SoSeri = form.list_Seri;
                    gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                }
            }
        }

        void cbxTenNCC_LostFocus(object sender, EventArgs e)
        {
            if (cbxTenNCC.Text.Trim().Equals(""))
            {
                cbxTenNCC.SelectedIndex = 0;
            }
            else
            {
                if (cbxTenNCC.SelectedIndex < 0)
                {
                    gridCtrlLoc.DataSource = null;
                    gridCtrlLoc.RefreshDataSource();
                }
            }
        }

        void UCNhapKho_Load(object sender, EventArgs e)
        {
            this.repositoryItemSpinEdit1.MinValue = 1;
            this.repositoryItemSpinEdit1.MaxValue = 1000;
            this.repositoryItemSpinEdit1.Increment = 1;

            this.text_money.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.text_money.DisplayFormat.Format = new CultureInfo("vi-VN");
            this.text_money.DisplayFormat.FormatString = "c";

            this.txt_ThanhT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txt_ThanhT.DisplayFormat.Format = new CultureInfo("vi-VN");
            this.txt_ThanhT.DisplayFormat.FormatString = "c";

            this.txtTongTien.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.txtTongTien.ReadOnly = true;
        }

        private void InnitVal(string maHD)
        {
            ls_cthd = new List<CT_HoaDonNhap_View>();

            if (maHD.Equals(""))
            {
                isNew = true;
                hoadonnhap = new HoaDonNhap_View();
                hoadonnhap.NhanVien = Context.getInstance().nv.TenNhanVien;
                hoadonnhap.MaNhanVien = Context.getInstance().nv.MaNhanVien;
                hoadonnhap.MaHoaDon = HoaDonNhap_DAL.get_HoaDonNhapMax();
                hoadonnhap.NgayLap = DateTime.Now;
                hoadonnhap.GhiChu = "";
            }
            else
            {
                isNew = false;
                hoadonnhap = HoaDonNhap_DAL.get_HoaDonNhap_By_MaHD(maHD);
            }
            setDataLoad();
        }

        private void setDataLoad()
        {
            txtMaPhieu.Text = hoadonnhap.MaHoaDon;
            txtNhanVien.Text = hoadonnhap.NhanVien;
            dateNgayBan.Value = hoadonnhap.NgayLap;
            txtGhiChu.Text = hoadonnhap.GhiChu;
            setGroupBox_NCC();
            if (isNew)
                ls_cthd = new List<CT_HoaDonNhap_View>();
            else
                ls_cthd = CT_HoaDonNhap_DAL.get_CTHoaDonNhap_By_MaHD_TT01(hoadonnhap.MaHoaDon);
            gridControl1.DataSource = ls_cthd;
            count_TongTien();
        }

        private void reset_ls_cthd()
        {
            if (isNew)
            {
                ls_cthd.Clear();
            }
            else
            {
                ls_cthd = CT_HoaDonNhap_DAL.get_CTHoaDonNhap_By_MaHD_TT01(hoadonnhap.MaHoaDon);
            }
        }

        private void setGridCtrl_LinhKien()
        {
            string maCNN = cbxTenNCC.SelectedValue.ToString().Trim();
            gridCtrlLoc.DataSource = LinhKien_DAL.getAll_LinhKien_ByNCC(maCNN);
            gridCtrlLoc.RefreshDataSource();
        }

        private void setGroupBox_NCC()
        {
            setCbxNCC("");
            if (!isNew)
            {
                NhaCungCap_View ncc_v = NhaCungCap_DAL.get_NCC_By_MaNCC(hoadonnhap.MaNhaCungCap);
                cbxTenNCC.Text = ncc_v.TenNhaCungCap;
                txtSoDienThoai.Text = ncc_v.SoDienThoai;
                txtDiaChi.Text = ncc_v.DiaChi;
                hoadonnhap.MaNhaCungCap = ncc_v.MaNhaCungCap;
            }
        }

        private void setCbxNCC(string maNCC_WantSelected)
        {
            int selected_Index = 0;
            cbxTenNCC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxTenNCC.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxTenNCC.DisplayMember = "TenNhaCungCap";
            cbxTenNCC.ValueMember = "MaNhaCungCap";
            List<NhaCungCap_View> list_NCC = NhaCungCap_DAL.getAll_NhaCungCap();

            for (int i = 0; i < list_NCC.Count; i++)
            {
                if (maNCC_WantSelected.Equals(list_NCC[i].MaNhaCungCap))
                {
                    selected_Index = i - 1;
                    break;
                }
            }
            cbxTenNCC.DataSource = list_NCC;
            cbxTenNCC.SelectedIndex = selected_Index;
            hoadonnhap.MaNhaCungCap = cbxTenNCC.SelectedValue.ToString().Trim();
        }

        //thay doi so luong lk
        void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            decimal soluong = ((DevExpress.XtraEditors.SpinEdit)sender).Value;

            CT_HoaDonNhap_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDonNhap_View;

            foreach (CT_HoaDonNhap_View item in ls_cthd)
            {
                if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                {
                    item.SoLuong = (Int32)soluong;
                    item.ThanhTien = item.SoLuong * item.GiaNhap;
                    gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                    count_TongTien();
                    break;
                }
            }
        }

        private void cbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maCNN = cbxTenNCC.SelectedValue.ToString().Trim();
            NhaCungCap_View ncc = NhaCungCap_DAL.get_NCC_By_MaNCC(maCNN);

            txtSoDienThoai.Text = ncc.SoDienThoai;
            txtDiaChi.Text = ncc.DiaChi;
            setGridCtrl_LinhKien();
            ls_cthd.Clear();
            gridControl1.DataSource = ls_cthd;
            gridControl1.RefreshDataSource();
            hoadonnhap.MaNhaCungCap = maCNN;
        }

        private void gridViewLoc_DoubleClick(object sender, EventArgs e)
        {
            addRowGrid_CT_HoaDon();
        }

        private void addRowGrid_CT_HoaDon()
        {
            LinhKien_View lk = gridViewLoc.GetFocusedRow() as LinhKien_View;
            bool flat = false;

            if (ls_cthd.Count > 0)
            {
                int sl = 0;
                foreach (CT_HoaDonNhap_View item in ls_cthd)
                {
                    if (item.MaLinhKien.Equals(lk.MaLinhKien))
                    {
                        sl = item.SoLuong + 1;
                        item.SoLuong = sl;
                        item.ThanhTien = item.SoLuong * item.GiaNhap;
                        flat = true;
                        break;
                    }
                }
            }

            if (!flat)
            {
                CT_HoaDonNhap_View ct_hd = new CT_HoaDonNhap_View();
                ct_hd.MaHoaDon = txtMaPhieu.Text.Trim();
                ct_hd.MaLinhKien = lk.MaLinhKien;
                ct_hd.TenLinhKien = lk.TenLinhKien;
                ct_hd.DonViTinh = lk.TenDonViTinh;
                ct_hd.SoLuong = 1;
                ct_hd.GiaNhap = lk.GiaNhap;
                ct_hd.ThanhTien = ct_hd.GiaNhap * ct_hd.SoLuong;
                ct_hd.TinhTrang = 1;
                ls_cthd.Add(ct_hd);

                gridControl1.DataSource = ls_cthd;
            }

            gridControl1.RefreshDataSource();
            count_TongTien();
        }

        private void RemoveRowGrid_CT_HoaDon()
        {
            CT_HoaDonNhap_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDonNhap_View;
            foreach (CT_HoaDonNhap_View item in ls_cthd)
            {
                if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                {
                    ls_cthd.Remove(item);
                    gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                    break;
                }
            }
            count_TongTien();
        }

        private void bnt_arrowRight_Click(object sender, EventArgs e)
        {
            addRowGrid_CT_HoaDon();
        }

        private void bnt_arrowLeft_Click(object sender, EventArgs e)
        {
            RemoveRowGrid_CT_HoaDon();
        }

        void btnXoa_Click(object sender, EventArgs e)
        {
            RemoveRowGrid_CT_HoaDon();
        }

        private void count_TongTien()
        {
            decimal tongtien = 0;
            if (ls_cthd.Count > 0)
            {
                foreach (CT_HoaDonNhap_View item in ls_cthd)
                {
                    tongtien += (Decimal)(item.GiaNhap * item.SoLuong);
                }
            }
            hoadonnhap.TongTien = tongtien;
            txtTongTien.Text = hoadonnhap.TongTien.ToString("c", new CultureInfo("vi-VN"));
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string str = checkSeri();
                if (str.Equals(""))
                {
                    if (ls_cthd.Count == 0)
                        MessageBox.Show("Chưa có sản phẩm nào được chọn, xin vui lòng kiểm tra lại!");
                    else
                    {
                        hoadonnhap.MaHoaDon = txtMaPhieu.Text.Trim();
                        hoadonnhap.GhiChu = txtGhiChu.Text.Trim();
                        hoadonnhap.NgayLap = dateNgayBan.Value;
                        //bien trang thai hoa don
                        hoadonnhap.TrangThai = 1;
                        hoadonnhap.MaNhanVienSua = hoadonnhap.MaNhanVien;
                        hoadonnhap.NgaySua = hoadonnhap.NgayLap;
                        List<Kho_View> list_LK_In_Kho = Kho_DAL.getAll_LinhKien();
                        Kho_View kho_v;
                        LinhKien_View lk_v;
                        foreach (var cthd in ls_cthd)
                        {
                            //tinh lai gia nhap
                            kho_v = list_LK_In_Kho.Where(temp => temp.MaLinhKien == cthd.MaLinhKien).FirstOrDefault();
                            lk_v = LinhKien_DAL.get_LinhKien_ByMaLK(cthd.MaLinhKien);

                            if (lk_v != null)
                            {
                                if (!(lk_v.GiaNhap == cthd.GiaNhap))
                                {
                                    if (kho_v != null)
                                    {
                                        cthd.GiaNhap = ((lk_v.GiaNhap * kho_v.SoLuong) + (cthd.GiaNhap * cthd.SoLuong)) / (kho_v.SoLuong + cthd.SoLuong);
                                    }
                                }
                            }
                        }

                        if (HoaDonNhap_DAL.add_HoaDonNhap(hoadonnhap, ls_cthd))
                        {
                            MessageBox.Show("Lưu thông tin thành công!");
                            f_Clear();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra dữ liệu!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ số Seri của linh kiện " + str);
                }
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            using (var form = new AddNhaCungCap())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    setCbxNCC(form.maNCC_Return);
                }
            }
        }

        private void text_money_EditValueChanged(object sender, EventArgs e)
        {
            string strGN = ((DevExpress.XtraEditors.TextEdit)sender).Text;
            decimal giaNhap;
            if (strGN.Equals(""))
            {
                giaNhap = 0;
            }
            else
            {
                giaNhap = Decimal.Parse(strGN);
            }
            CT_HoaDonNhap_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDonNhap_View;

            foreach (CT_HoaDonNhap_View item in ls_cthd)
            {
                if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                {
                    item.GiaNhap = giaNhap;
                    item.ThanhTien = item.SoLuong * item.GiaNhap;
                    gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                    count_TongTien();
                    break;
                }
            }
        }

        private void f_Clear()
        {
            hoadonnhap = new HoaDonNhap_View();
            ls_cthd = new List<CT_HoaDonNhap_View>();

            txtMaPhieu.Text = HoaDonNhap_DAL.get_HoaDonNhapMax();
            dateNgayBan.Value = DateTime.Now;
            cbxTenNCC.SelectedIndex = 0;
            txtTongTien.Text = "0";
            gridControl1.DataSource = ls_cthd;
            gridControl1.RefreshDataSource();
        }

        private void btnThemMoiSP_Click(object sender, EventArgs e)
        {
            using (var form = new Add_LinhKien(cbxTenNCC.SelectedValue.ToString().Trim()))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    setGridCtrl_LinhKien();
                }
            }
        }

        private void btnKiemTraKho_Click(object sender, EventArgs e)
        {
            using (var form = new LinhKien_Kho())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //setGridCtrl_LinhKien();

                }
            }
        }

        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        ls_cthd = Excel_Helper.readFile(txtMaPhieu.Text.Trim(), filePath);
                        count_TongTien();
                        gridControl1.DataSource = ls_cthd;
                        gridControl1.RefreshDataSource();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Chọn file .xls hoặc .xlsx.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        private void btn_XuatHD_Click(object sender, EventArgs e)
        {
            string result = checkSeri(); 
            if (result.Equals(""))
            {
                List<HoaDonNhap_View> lst = new List<HoaDonNhap_View>();
                hoadonnhap.ChiTietHoaDon = ls_cthd;
                hoadonnhap.GhiChu = txtGhiChu.Text.Trim();
                hoadonnhap.NgayLap = dateNgayBan.Value;

                hoadonnhap.NhaCungCap = cbxTenNCC.Text.Trim();
                //bien trang thai hoa don
                hoadonnhap.TrangThai = 1;
                lst.Add(hoadonnhap);
                //r = HoaDon_DAL.getAll_HoaDon();
                RHoaDonNhap r = new RHoaDonNhap(lst);

                var tool = new ReportPrintTool(r);
                tool.ShowPreview();
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ số Seri của linh kiện " + result);
            }
        }

        private string checkSeri()
        {
            foreach (var item in ls_cthd)
            {
                if (item.SoSeri == null || item.SoLuong != item.SoSeri.Count)
                    return item.TenLinhKien + " (" + item.MaLinhKien + ")" ;
            }
            return "";
        }
    }
}
