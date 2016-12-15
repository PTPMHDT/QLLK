using System;
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
using DevExpress.XtraReports.UI;

namespace PresentationLayer
{
    public partial class UCBanHang : UserControl
    {
        DataTable dt_linhKien = new DataTable();
        List<Kho_View> list_LK_inKho;
        List<CT_HoaDon_View> ls_cthd;
        HoaDon_View hoadon;
        KhachHang_View kh_vanglai;
        bool isNew;     //bien kiem tra xem dang o che do New hay la update
        string loaiKH;     //bien kiem tra xem kh la loai nao

        public UCBanHang() { }

        public UCBanHang(string maHoaDon)
        {
            InitializeComponent();
            this.Load += UCBanHang_Load;

            InnitVal(maHoaDon);
            this.btnXoa.Click += btnXoa_Click;
            this.repositoryItemSpinEdit1.EditValueChanged += repositoryItemSpinEdit1_EditValueChanged;
        }

        void UCBanHang_Load(object sender, EventArgs e)
        {
            this.repositoryItemSpinEdit1.MinValue = 1;
            this.repositoryItemSpinEdit1.MaxValue = 1000;
            this.repositoryItemSpinEdit1.Increment = 1;
        }

        private void InnitVal(string maHD)
        {
            kh_vanglai = KhachHang_DAL.get_KhachHang_VangLai();
            ls_cthd = new List<CT_HoaDon_View>();

            if (maHD.Equals(""))
            {
                isNew = true;
                hoadon = new HoaDon_View();
                hoadon.NhanVien = Context.getInstance().nv.TenNhanVien;
                hoadon.MaNhanVien = Context.getInstance().nv.MaNhanVien;
                hoadon.MaHoaDon = HoaDon_DAL.get_HoaDonMax();
                hoadon.NgayLap =DateTime.Now;
                hoadon.GhiChu = "";
            }
            else
            {
                isNew = false;
                hoadon = HoaDon_DAL.get_HoaDon_By_MaHD(maHD);
            }
            setDataLoad();
        }

        private void setDataLoad()
        {
            txtMaPhieu.Text = hoadon.MaHoaDon;
            txtNhanVien.Text = hoadon.NhanVien;
            dateNgayBan.Text = hoadon.NgayLap.ToString();
            txtGhiChu.Text = hoadon.GhiChu;
            setGroupBox_KhachHang();
            setGridCtrl_LinhKien();
            if (isNew)
                ls_cthd = new List<CT_HoaDon_View>();
            else
                ls_cthd = CT_HoaDon_DAL.get_CTHoaDon_By_MaHD(hoadon.MaHoaDon);
            gridControl1.DataSource = ls_cthd;
            txtTongTien.Text = count_TongTien().ToString();
        }

        private void reset_ls_cthd()
        {
            if (isNew)
            {
                ls_cthd.Clear();
            }
            else
            {
                ls_cthd = CT_HoaDon_DAL.get_CTHoaDon_By_MaHD(hoadon.MaHoaDon);
            }
        }

        private void setGridCtrl_LinhKien()
        {
            list_LK_inKho = Kho_DAL.getAll_LinhKien();
            gridCtrlLoc.DataSource = list_LK_inKho;
        }

        private void setGroupBox_KhachHang()
        {
            setCbxKhachHang("");
            if (isNew)
            {
                cbTenKhachHang.Text = kh_vanglai.TenKhachHang;
                txtLoaiKhach.Text = kh_vanglai.TenLoaiKhachHang;
                txtSoDienThoai.Text = "";
                txtDiaChi.Text = "";
                hoadon.MaKhachHang = kh_vanglai.MaKhachHang;
                hoadon.KhachHang = kh_vanglai.TenKhachHang;
                loaiKH = kh_vanglai.MaLoaiKhachHang;
            }
            else
            {
                KhachHang_View kh_v = KhachHang_DAL.get_KhachHang_By_MaKhachHang(hoadon.MaKhachHang);
                if (kh_v.MaKhachHang.Equals(kh_vanglai.MaKhachHang))
                    cbTenKhachHang.Text = kh_v.TenKhachHang;
                else
                    cbTenKhachHang.Text = kh_v.ToString();
                txtLoaiKhach.Text = kh_v.TenLoaiKhachHang;
                txtSoDienThoai.Text = kh_v.SoDienThoai;
                txtDiaChi.Text = kh_v.DiaChi;
                loaiKH = kh_v.MaLoaiKhachHang;
            }
        }

        private void setCbxKhachHang(string maKH_WantSelected)
        {
            int selected_Index = 0;
            cbTenKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTenKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTenKhachHang.DisplayMember = "TenKhachHangShow";
            cbTenKhachHang.ValueMember = "MaKhachHang";

            List<KhachHang_View> list_KH = KhachHang_DAL.getAll_KhachHang();

            //khong load khach hang vang lai 
            for (int i = 0; i < list_KH.Count; i++)
            {
                if (maKH_WantSelected.Equals(list_KH[i].MaKhachHang))
                {
                    selected_Index = i - 1;
                    break;
                }
            }
            cbTenKhachHang.DataSource = list_KH;
            cbTenKhachHang.SelectedIndex = selected_Index;
            hoadon.MaKhachHang = cbTenKhachHang.SelectedValue.ToString().Trim();
            hoadon.KhachHang = cbTenKhachHang.Text.Trim() ;
        }

        //thay doi so luong lk
        void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            decimal soluong = ((DevExpress.XtraEditors.SpinEdit)sender).Value;

            CT_HoaDon_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDon_View;

            decimal sl = ((List<Kho_View>)gridCtrlLoc.DataSource).Where(x => x.MaLinhKien == ct_hd.MaLinhKien).FirstOrDefault().SoLuong;

            foreach (CT_HoaDon_View item in ls_cthd)
            {
                if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                {
                    if (((Int32)soluong) > sl)
                    {
                        MessageBox.Show("Trong kho đã hết mặt hàng này, vui lòng nhập thêm sản phẩm!");
                        ((DevExpress.XtraEditors.SpinEdit)sender).Value = sl;
                        return;
                    }
                    item.SoLuong = (Int32)soluong;
                    item.ThanhTien = item.SoLuong * item.GiaBan;
                    gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                    txtTongTien.Text = count_TongTien().ToString();
                    add_LinhKienSeri(item.MaLinhKien);
                    break;
                }
            }
        }

        private void cbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenKhachHang.SelectedIndex >= 0)
            {
                string maKH = cbTenKhachHang.SelectedValue.ToString().Trim();
                KhachHang_View kh = KhachHang_DAL.get_KhachHang_By_MaKhachHang(maKH);

                txtLoaiKhach.Text = kh.TenLoaiKhachHang;
                txtSoDienThoai.Text = kh.SoDienThoai;
                txtDiaChi.Text = kh.DiaChi;
                hoadon.MaKhachHang = maKH;
                hoadon.KhachHang = kh.TenKhachHang;
                loaiKH = kh.MaLoaiKhachHang;
            }
            else
            {
                cbTenKhachHang.SelectedIndex = 0;
                txtLoaiKhach.Text = kh_vanglai.TenLoaiKhachHang;
                txtSoDienThoai.Text = "";
                txtDiaChi.Text = "";
                hoadon.MaKhachHang = kh_vanglai.MaKhachHang;
                hoadon.KhachHang = kh_vanglai.TenKhachHang;
                loaiKH = kh_vanglai.MaLoaiKhachHang;
            }
            change_GiaBan();
        }

        private void change_GiaBan()
        {
            //Kho_View kho;
            foreach (var cthd in ls_cthd)
            {
                //kho = list_LK_inKho.Where(key => key.MaLinhKien == cthd.MaLinhKien).FirstOrDefault();
                LinhKien_View lk_view = LinhKien_DAL.get_LinhKien_ByMaLK(cthd.MaLinhKien);
                switch (loaiKH)
                {
                    case "L001":
                        cthd.GiaBan = lk_view.GiaBanLe;
                        break;
                    case "L002":
                        cthd.GiaBan = lk_view.GiaBanSi;
                        break;
                    case "L003":
                        break;
                }
                cthd.ThanhTien = cthd.GiaBan * cthd.SoLuong;
            }
            txtTongTien.Text = count_TongTien().ToString();
            gridControl1.RefreshDataSource();
        }

        private void gridViewLoc_DoubleClick(object sender, EventArgs e)
        {
            addRowGrid_CT_HoaDon();
        }

        private void addRowGrid_CT_HoaDon()
        {
            Kho_View kho = gridViewLoc.GetFocusedRow() as Kho_View;
            bool flat = false;

            if (ls_cthd.Count > 0)
            {
                int sl = 0;

                foreach (CT_HoaDon_View item in ls_cthd)
                {
                    if (item.MaLinhKien.Equals(kho.MaLinhKien))
                    {
                        sl = item.SoLuong + 1;
                        if (sl > kho.SoLuong)
                        {
                            MessageBox.Show("Trong kho đã hết mặt hàng này, vui lòng nhập thêm sản phẩm!");
                            return;
                        }
                        item.SoLuong = sl;
                        item.ThanhTien = item.SoLuong * item.GiaBan;
                        add_LinhKienSeri(item.MaLinhKien);
                        flat = true;
                        break;
                    }
                }
            }

            if (!flat)
            {
                LinhKien_View lk_view = LinhKien_DAL.get_LinhKien_ByMaLK(kho.MaLinhKien);
                CT_HoaDon_View ct_hd = new CT_HoaDon_View();
                ct_hd.MaHoaDon = txtMaPhieu.Text.Trim();
                ct_hd.MaLinhKien = lk_view.MaLinhKien;
                ct_hd.TenLinhKien = lk_view.TenLinhKien;
                ct_hd.DonViTinh = lk_view.MaDonViTinh;
                ct_hd.ThoiGianBaoHanh = lk_view.ThoiGianBaoHanh;
                switch (loaiKH)
                {
                    case "L001":
                        ct_hd.GiaBan = lk_view.GiaBanLe;
                        break;
                    case "L002":
                        ct_hd.GiaBan = lk_view.GiaBanSi;
                        break;
                    case "L003":
                        break;
                }
                ct_hd.SoLuong = 1;
                ct_hd.ThanhTien = ct_hd.GiaBan * ct_hd.SoLuong;
                ls_cthd.Add(ct_hd);
                add_LinhKienSeri(ct_hd.MaLinhKien);

                gridControl1.DataSource = ls_cthd;
            }

            gridControl1.RefreshDataSource();
            txtTongTien.Text = count_TongTien().ToString();
        }

        private void add_LinhKienSeri(string maLK)
        {
            List<Kho_View> lK_v = Kho_DAL.get_AllLinhKien_By_MaLinhKien(maLK);
            CT_HoaDon_View cthd = ls_cthd.Where(key => key.MaLinhKien == maLK).FirstOrDefault();
            cthd.SoSeri = new List<string>();
            for (int i = 0; i < cthd.SoLuong; i++)
            {
                cthd.SoSeri.Add(lK_v[i].Seri);
            }
        }

        private void RemoveRowGrid_CT_HoaDon()
        {
            CT_HoaDon_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDon_View;
            foreach (CT_HoaDon_View item in ls_cthd)
            {
                if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                {
                    ls_cthd.Remove(item);
                    gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                    break;
                }
            }
            txtTongTien.Text = count_TongTien().ToString();
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

        private decimal count_TongTien()
        {
            decimal tongtien = 0;
            if (ls_cthd.Count > 0)
            {
                foreach (CT_HoaDon_View item in ls_cthd)
                {
                    tongtien += (Int32)(item.GiaBan * item.SoLuong);
                }
            }
            return tongtien;
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (ls_cthd.Count == 0)
                    MessageBox.Show("Chưa có sản phẩm nào được chọn, xin vui lòng kiểm tra lại!");
                else
                {
                    hoadon.GhiChu = txtGhiChu.Text.Trim();
                    hoadon.NgayLap = dateNgayBan.Value;
                    hoadon.TongTien = Decimal.Parse(txtTongTien.Text);
                    hoadon.MaPhieu = "fsd";
                    //bien trang thai hoa don
                    hoadon.TrangThai = 1;
                    if (HoaDon_DAL.add_HoaDon(hoadon, ls_cthd))
                    {
                        MessageBox.Show("Lưu thông tin thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra dữ liệu!");
                    }
                }
            }
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            using (var form = new AddKhachHang())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    setCbxKhachHang(form.maKH_Return);
                }
            }
        }

        private void text_money_EditValueChanged(object sender, EventArgs e)
        {
            decimal giaBan;
            string strGB = ((DevExpress.XtraEditors.TextEdit)sender).Text.Trim();
            if (strGB.Equals(""))
            {
                giaBan = 0;
            }
            else
            {
                giaBan = Decimal.Parse(strGB);
            }
            CT_HoaDon_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDon_View;

            foreach (CT_HoaDon_View item in ls_cthd)
            {
                if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                {
                    item.GiaBan = giaBan;
                    item.ThanhTien = item.SoLuong * item.GiaBan;
                    gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                    txtTongTien.Text = count_TongTien().ToString();
                    break;
                }
            }
        }

        private void btn_XuatHD_Click(object sender, EventArgs e)
        {
            List<HoaDon_View> lst = new List<HoaDon_View>();
            hoadon.ChiTietHoaDon = ls_cthd;
            hoadon.GhiChu = txtGhiChu.Text.Trim();
            hoadon.NgayLap = DateTime.Parse(dateNgayBan.Value.ToShortDateString()) ;
            
            hoadon.TongTien = Decimal.Parse(txtTongTien.Text);
            hoadon.KhachHang = cbTenKhachHang.Text.Trim();
            //bien trang thai hoa don
            hoadon.TrangThai = 1;
            lst.Add(hoadon);
            //r = HoaDon_DAL.getAll_HoaDon();
            RHoaDon r = new RHoaDon(lst);

            var tool = new ReportPrintTool(r);
            tool.ShowPreview();
        }

        private void cbTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            if(cbTenKhachHang.Text.Trim().Equals(""))
            {
                cbTenKhachHang.SelectedIndex = 0;
                txtLoaiKhach.Text = kh_vanglai.TenLoaiKhachHang;
                txtSoDienThoai.Text = "";
                txtDiaChi.Text = "";
                hoadon.MaKhachHang = kh_vanglai.MaKhachHang;
                loaiKH = kh_vanglai.MaLoaiKhachHang;
                change_GiaBan();
            }
        }

    }
}
