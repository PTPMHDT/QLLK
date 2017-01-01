using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PresentationLayer.DAL;
using PresentationLayer.ViewObject;
using PresentationLayer.GlobalVariable;
using DevExpress.XtraReports.UI;

namespace PresentationLayer.Viewer
{
    public partial class Update_BanHang : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt_linhKien = new DataTable();
        List<Kho_View> list_LK_inKho;
        List<CT_HoaDon_View> ls_cthd;
        HoaDon_View hoadon;
        KhachHang_View kh_vanglai;
        bool isNew;     //bien kiem tra xem dang o che do New hay la update
        string loaiKH;
        //GridHelper<CT_HoaDon_View> gridThaoTac;
        DataUpdate<CT_HOADON> dt;
        decimal tong_tien_old;
        decimal phanTramChietKhau;
        decimal phanTramChietKhau_DB;

        public Update_BanHang()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public Update_BanHang(string maHoaDon)
        {
            InitializeComponent();
            this.Load += Update_BanHang_Load;

            InnitVal(maHoaDon);
            this.btnXoa.Click += btnXoa_Click;
            this.repositoryItemSpinEdit1.EditValueChanged += repositoryItemSpinEdit1_EditValueChanged;
            this.cbTenKhachHang.SelectedIndexChanged +=cbTenKhachHang_SelectedIndexChanged;
            gridViewLoc.DoubleClick +=gridViewLoc_DoubleClick;
            this.bnt_arrowLeft.Click+=bnt_arrowLeft_Click;
            this.bnt_arrowRight.Click+=bnt_arrowRight_Click;
            this.btnHoanTat.Click +=btnHoanTat_Click;
            this.btnThemKhachHang.Click +=btnThemKhachHang_Click;
            this.text_money.EditValueChanged +=text_money_EditValueChanged;
            this.btn_XuatHD.Click +=btn_XuatHD_Click;
            this.cbTenKhachHang.TextChanged +=cbTenKhachHang_TextChanged;
            this.txtThue.EditValueChanged +=txtThue_EditValueChanged;
        }

        private void Update_BanHang_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.repositoryItemSpinEdit1.MinValue = 1;
            this.repositoryItemSpinEdit1.MaxValue = 1000;
            this.repositoryItemSpinEdit1.Increment = 1;
        }

        private void InnitVal(string maHD)
        {
            //gridThaoTac = new GridHelper<CT_HoaDon_View>(gridControl1);
            HoaDon_View hd_view = HoaDon_DAL.get_HoaDon_By_MaHD(maHD);
            tong_tien_old = hd_view.TongTien;
            dt = new DataUpdate<CT_HOADON>();

            kh_vanglai = KhachHang_DAL.get_KhachHang_VangLai();
            ls_cthd = new List<CT_HoaDon_View>();

            if (maHD.Equals(""))
            {
                isNew = true;
                hoadon = new HoaDon_View();
                hoadon.NhanVien = Context.getInstance().nv.TenNhanVien;
                hoadon.MaNhanVien = Context.getInstance().nv.MaNhanVien;
                hoadon.MaHoaDon = HoaDon_DAL.get_HoaDonMax();
                hoadon.NgayLap = DateTime.Now;
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
            phanTramChietKhau_DB = decimal.Parse(HeThong_DAL.getHeThongByMa("HT001").GiaTri);
            phanTramChietKhau = 0;
            txtMaPhieu.Text = hoadon.MaHoaDon;
            txtNhanVien.Text = hoadon.NhanVien;
            dateNgayBan.Text = hoadon.NgayLap.ToString();
            txtGhiChu.Text = hoadon.GhiChu;
            txt_NguoiThayDoi.Text = hoadon.TenNhanVienSua;
            date_Update.Text = hoadon.NgaySua.ToString();
            setGroupBox_KhachHang();
            setGridCtrl_LinhKien();
            if (isNew)
                ls_cthd = new List<CT_HoaDon_View>();
            else
                ls_cthd = CT_HoaDon_DAL.get_CTHoaDon_By_MaHD_TT01(hoadon.MaHoaDon);
            gridControl1.DataSource = ls_cthd;
            count_TongTien();
        }

        private void setGridCtrl_LinhKien()
        {
            list_LK_inKho = Kho_DAL.getAll_LinhKien();
            gridCtrlLoc.DataSource = list_LK_inKho;
        }

        private void setGroupBox_KhachHang()
        {
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
                hoadon.MaKhachHang = kh_v.MaKhachHang;
                txtLoaiKhach.Text = kh_v.TenLoaiKhachHang;
                txtSoDienThoai.Text = kh_v.SoDienThoai;
                txtDiaChi.Text = kh_v.DiaChi;
                loaiKH = kh_v.MaLoaiKhachHang;
            }
            setCbxKhachHang(hoadon.MaKhachHang);
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
                    selected_Index = i ;
                    break;
                }
            }
            cbTenKhachHang.DataSource = list_KH;
            cbTenKhachHang.SelectedIndex = selected_Index;
            hoadon.MaKhachHang = cbTenKhachHang.SelectedValue.ToString().Trim();
            hoadon.KhachHang = cbTenKhachHang.Text.Trim();
        }

        //thay doi so luong lk
        void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            decimal soluong = (decimal)((DevExpress.XtraEditors.SpinEdit)sender).Value;
            CT_HoaDon_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDon_View;
            decimal chenhLech = soluong - ct_hd.SoLuong;

            Kho_View kho = list_LK_inKho.Where(key => key.MaLinhKien == ct_hd.MaLinhKien).FirstOrDefault();
            decimal chechLechVsKho = chenhLech - kho.SoLuong;

            if(kho!= null)
            {
                foreach (CT_HoaDon_View item in ls_cthd)
                {
                    if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                    {
                        if (chechLechVsKho > 0 && chenhLech > 0)
                        {
                            MessageBox.Show("Trong kho đã hết mặt hàng này, vui lòng nhập thêm sản phẩm!");
                            ((DevExpress.XtraEditors.SpinEdit)sender).Value = ct_hd.SoLuong;
                            //kho.SoLuong = 0;
                            return;
                        }
                        else
                        {
                            if(chenhLech != 0)
                            {
                                item.SoLuong = (Int32)soluong;
                                item.ThanhTien = (item.SoLuong * item.GiaBan) + (item.SoLuong * item.GiaBan) * (Decimal)(item.Thue / 100);
                                if (chenhLech > 0)
                                {
                                    item.SoSeri.AddRange(kho.SoSeri.GetRange(0, (int)chenhLech));
                                    kho.SoSeri.RemoveRange(0, (int)chenhLech);
                                }
                                else
                                {
                                    chenhLech = -chenhLech;
                                    kho.SoSeri.InsertRange(0, item.SoSeri.GetRange(item.SoSeri.Count - (int)chenhLech, (int)chenhLech));
                                    item.SoSeri.RemoveRange(item.SoSeri.Count - (int)chenhLech, (int)chenhLech);
                                }
                                kho.SoLuong = kho.SoSeri.Count();
                                count_TongTien();
                            }
                        }

                        gridCtrlLoc.RefreshDataSource();
                        gridControl1.RefreshDataSource();
                        break;
                    }
                }
            }
            else
            {
                if (chenhLech != 0)
                {
                    MessageBox.Show("Trong kho đã hết mặt hàng này, vui lòng nhập thêm sản phẩm!");
                    ((DevExpress.XtraEditors.SpinEdit)sender).Value = ct_hd.SoLuong;
                    return;
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
                        phanTramChietKhau = 0;
                        break;
                    case "L002":
                        cthd.GiaBan = lk_view.GiaBanSi;
                        phanTramChietKhau = 0;
                        break;
                    case "L003":
                        cthd.GiaBan = lk_view.GiaBanLe;
                        phanTramChietKhau = phanTramChietKhau_DB;
                        break;
                }
                cthd.ThanhTien = (cthd.GiaBan * cthd.SoLuong) + (cthd.GiaBan * cthd.SoLuong) * (Decimal)(cthd.Thue / 100);
            }
            count_TongTien();
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
                if (kho.SoLuong <= 0)
                {
                    MessageBox.Show("Trong kho đã hết mặt hàng này, vui lòng nhập thêm sản phẩm!");
                    return;
                }
                else
                {
                    foreach (CT_HoaDon_View item in ls_cthd)
                    {
                        if (item.MaLinhKien.Equals(kho.MaLinhKien))
                        {
                            kho.SoLuong -= 1;
                            item.SoLuong += 1;
                            item.ThanhTien = (item.SoLuong * item.GiaBan) + (item.SoLuong * item.GiaBan) * (Decimal)(item.Thue / 100);
                            item.SoSeri.Add(kho.SoSeri[0]);
                            kho.SoSeri.RemoveAt(0);
                            flat = true;
                            break;
                        }
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
                        phanTramChietKhau = 0;
                        break;
                    case "L002":
                        ct_hd.GiaBan = lk_view.GiaBanSi;
                        phanTramChietKhau = 0;
                        break;
                    case "L003":
                        ct_hd.GiaBan = lk_view.GiaBanLe;
                        phanTramChietKhau = phanTramChietKhau_DB;
                        break;
                }
                ct_hd.SoLuong = 1;
                kho.SoLuong -= 1;
                ct_hd.ThanhTien = (ct_hd.SoLuong * ct_hd.GiaBan) + (ct_hd.SoLuong * ct_hd.GiaBan) * (Decimal)(ct_hd.Thue / 100);
                ct_hd.SoSeri = new List<string>();
                ct_hd.SoSeri.Add(kho.SoSeri[0]);
                kho.SoSeri.RemoveAt(0);
                ls_cthd.Add(ct_hd);
            }
            gridCtrlLoc.RefreshDataSource();
            gridControl1.RefreshDataSource();
            count_TongTien();
        }

        private void RemoveRowGrid_CT_HoaDon()
        {
            CT_HoaDon_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDon_View;
            if(ct_hd != null)
            {
                Kho_View kho = list_LK_inKho.Where(key => key.MaLinhKien == ct_hd.MaLinhKien).FirstOrDefault();
                if(kho == null)
                {
                    kho = new Kho_View();
                    kho.MaLinhKien = ct_hd.MaLinhKien;
                    kho.TenLinhKien = ct_hd.TenLinhKien;
                    kho.SoSeri = new List<string>();
                    kho.SoLuong = 0;
                    list_LK_inKho.Add(kho);
                }

                var get_item = ls_cthd.Where(key => key.MaLinhKien == ct_hd.MaLinhKien).FirstOrDefault();
                if (get_item != null)
                {
                    //foreach (var item in get_item.SoSeri)
                    //{
                    //    kho.SoSeri.Add(item);
                    //}
                    kho.SoSeri.InsertRange(0, get_item.SoSeri);

                    kho.SoLuong = kho.SoSeri.Count;
                    ls_cthd.Remove(get_item);
                    gridControl1.RefreshDataSource();
                    gridCtrlLoc.RefreshDataSource();
                }

                //foreach (CT_HoaDon_View item in ls_cthd)
                //{
                //    if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                //    {
                //        ls_cthd.Remove(item);

                //        gridControl1.DataSource = ls_cthd;
                //        gridControl1.RefreshDataSource();
                //        break;
                //    }
                //}
                count_TongTien();
            }
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
            // decimal thue = 0;
            if (ls_cthd.Count > 0)
            {
                foreach (CT_HoaDon_View item in ls_cthd)
                {
                    tongtien += item.ThanhTien;
                }
            }
            decimal ck = (tongtien * phanTramChietKhau / 100);
            lbChietKhau.Text = ck.ToString("0") + "(VNĐ)";
            lbTongTien.Text = (tongtien - ck).ToString("0") + "(VNĐ)";
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
                    hoadon.TongTien = Decimal.Parse(lbTongTien.Text);
                    //bien trang thai hoa don
                    hoadon.TrangThai = 1;
                    //set nguoi sua va ngay sua cua hoa don
                    hoadon.MaNhanVienSua = Context.getInstance().nv.MaNhanVien;
                    hoadon.NgaySua = DateTime.Now;

                    foreach (var item in ls_cthd)
                    {
                        item.LoiNhuan = (item.SoLuong * item.GiaBan) - (item.SoLuong * LinhKien_DAL.get_LinhKien_ByMaLK(item.MaLinhKien).GiaNhap);
                        item.LoiNhuan = item.LoiNhuan - (item.LoiNhuan * phanTramChietKhau / 100);
                        hoadon.TongLoiNhuan += item.LoiNhuan;
                    }

                    List<CT_HoaDon_View> mLstCTHD = CT_HoaDon_DAL.get_CTHoaDon_By_MaHD_TT01(hoadon.MaHoaDon);

                    if (mLstCTHD.Count > ls_cthd.Count)
                    {
                        foreach (var item in mLstCTHD)
                        {
                            CT_HoaDon_View ct = ls_cthd.Where(key => key.MaLinhKien == item.MaLinhKien).FirstOrDefault();
                            if (ct != null)//neu chi tiet hoa don chua bi xoa
                            {
                                getChange(ct.toList_CT_HoaDon(), CT_HoaDon_DAL.get_CTHoaDon_By_MaHD_MaLK(item.MaHoaDon, item.MaLinhKien).toList_CT_HoaDon());
                            }
                            else
                            {
                                dt.Deletes.AddRange(item.toList_CT_HoaDon());
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in ls_cthd)
                        {
                            CT_HoaDon_View ct = mLstCTHD.Where(key => key.MaLinhKien == item.MaLinhKien).FirstOrDefault();
                            if (ct != null)//neu chi tiet hoa don chua bi xoa
                            {
                                getChange(item.toList_CT_HoaDon(), ct.toList_CT_HoaDon());
                            }
                            else
                            {
                                dt.Inserts.AddRange(item.toList_CT_HoaDon());
                            }
                        }
                    }
                    if (HoaDon_DAL.update_HoaDon(hoadon, dt,tong_tien_old))
                    {
                        MessageBox.Show("Lưu thông tin thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra dữ liệu!");
                    }
                }
            }
        }

        private DataUpdate<CT_HOADON> getChange(List<CT_HOADON> LNew, List<CT_HOADON> LOld)
        {
            
            foreach (var item_new in LNew)
            {
                if (LOld.Where(key => key.MaLinhKien == item_new.MaLinhKien).Where(key => key.MaHoaDon == item_new.MaHoaDon).Where(key => key.Seri == item_new.Seri).FirstOrDefault() != null)
                    dt.Updates.Add(item_new);
                else
                    dt.Inserts.Add(item_new);
            }

            foreach (var item_old in LOld)
            {
                if (LNew.Where(key => key.MaLinhKien == item_old.MaLinhKien).Where(key => key.MaHoaDon == item_old.MaHoaDon).Where(key => key.Seri == item_old.Seri).FirstOrDefault() == null)
                    dt.Deletes.Add(item_old);
            }

            return dt;
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
                    item.ThanhTien = (item.SoLuong * item.GiaBan) + (item.SoLuong * item.GiaBan) * (Decimal)(item.Thue / 100);
                    //gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                    count_TongTien();
                    break;
                }
            }
        }

        private void btn_XuatHD_Click(object sender, EventArgs e)
        {
            List<HoaDon_View> lst = new List<HoaDon_View>();
            hoadon.ChiTietHoaDon = ls_cthd;
            hoadon.GhiChu = txtGhiChu.Text.Trim();
            hoadon.NgayLap = DateTime.Parse(dateNgayBan.Value.ToShortDateString());

            hoadon.TongTien = Decimal.Parse(lbTongTien.Text);
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
            if (cbTenKhachHang.Text.Trim().Equals(""))
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

        private void txtThue_EditValueChanged(object sender, EventArgs e)
        {
            float thue;
            string strGB = ((DevExpress.XtraEditors.TextEdit)sender).Text.Trim();
            if (strGB.Equals(""))
            {
                thue = 0;
            }
            else
            {
                strGB = strGB.Substring(0, strGB.Length - 2);
                thue = float.Parse(strGB);
            }
            CT_HoaDon_View ct_hd = gridView1.GetFocusedRow() as CT_HoaDon_View;

            foreach (CT_HoaDon_View item in ls_cthd)
            {
                if (item.MaLinhKien.Equals(ct_hd.MaLinhKien))
                {
                    item.Thue = thue;
                    item.ThanhTien = (item.SoLuong * item.GiaBan) + (item.SoLuong * item.GiaBan) * (Decimal)(item.Thue / 100);
                    //gridControl1.DataSource = ls_cthd;
                    gridControl1.RefreshDataSource();
                    count_TongTien();
                    break;
                }
            }
        }

    }
}