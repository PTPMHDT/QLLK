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

namespace PresentationLayer
{
    public partial class UCKiemKho : UserControl
    {
        DataTable dt_linhKien = new DataTable();
        List<ThuongHieu_View> list_NCC ;//= new List<ThuongHieu_View>();
        KiemKho_View kiemkho ;//= new List<KiemKho_View>();
        List<CT_KiemKho_View> ct_kiemkhos;
        DataUpdate<CT_KIEMKHO> dt;
        public UCKiemKho() {
            InitializeComponent();
            this.Load += UCKiemKho_Load;
            InnitVal();
            //InnitVal(maHoaDon);
        }
        void UCKiemKho_Load(object sender, EventArgs e)
        {
            this.repositoryItemSpinEdit1.MinValue = 0;
            this.repositoryItemSpinEdit1.MaxValue = 1000;
            this.repositoryItemSpinEdit1.Increment = 1;
            this.repositoryItemSpinEdit1.EditValueChanged += repositoryItemSpinEdit1_EditValueChanged;
        }

        private void InnitVal()
        {
            this.list_NCC = new List<ThuongHieu_View>();
            this.kiemkho = new KiemKho_View();
            this.ct_kiemkhos = new List<CT_KiemKho_View>();
            this.dt = new DataUpdate<CT_KIEMKHO>();
            txtNhanVien.Text = Context.getInstance().nv.TenNhanVien;
            txtMaPhieu.Text = KiemKho_DAL.getMaxKiemKho(1);

            setCbxThuongHieu(""); 
            UpdateGridView();
        }

        private void setDataLoad()
        {
        }


        private void setGroupBox_NCC()
        {
            
           
        }
        private void setCbxThuongHieu(string maThuongHieu)
        {
            int selected_Index = 0;
            cbxNhomHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxNhomHang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxNhomHang.DisplayMember = "TenThuongHieu";
            cbxNhomHang.ValueMember = "MaThuongHieu";

            list_NCC = ThuongHieu_DAL.getAll_ThuongHieu();//.getAll_NhaCungCap();

            for (int i = 0; i < this.list_NCC.Count; i++)
            {
                if (maThuongHieu.Equals(list_NCC[i].MaThuongHieu))
                {
                    selected_Index = i - 1;
                    break;
                }
            }
            cbxNhomHang.DataSource = list_NCC;
            cbxNhomHang.SelectedIndex = selected_Index;

        }

        //thay doi so luong lk
        void repositoryItemSpinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            CT_KiemKho_View current = (CT_KiemKho_View)gridView1.GetFocusedRow();
            for(int i = 0; i< this.ct_kiemkhos.Count; i++)
            {
                if (this.ct_kiemkhos[i].MaLinhKien == current.MaLinhKien)
                {
                    this.ct_kiemkhos[i].TonSoSach = current.SoLuong;
                    this.ct_kiemkhos[i].ChenhLech = this.ct_kiemkhos[i].SoLuong - current.SoLuong;
                    return;
                }
            }
        }

        private void cbTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private void btnHoanTat_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu sự thay đổi xuống cơ sở dữ liệu hay không?", "Lưu thông tin", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                KiemKho_View kiemkhoNew = new KiemKho_View();
                kiemkhoNew.MaKiemKho = txtMaPhieu.Text;
                kiemkhoNew.NgayKiem = dateNgayBan.Value;
                kiemkhoNew.NhanVien = Context.getInstance().nv.MaNhanVien;
                kiemkhoNew.TrangThai = 1;
                
                foreach (var item in ct_kiemkhos)
                {
                    item.MaKiemKho = kiemkhoNew.MaKiemKho;
                    if(item.TonSoSach == 0)
                    {
                        item.TonSoSach = item.SoLuong;
                    }
                    item.ChenhLech = item.SoLuong - item.TonSoSach;
                    dt.Inserts.Add(item.toCT_KiemKho());
                }

                if (KiemKho_DAL.add_KiemKho(kiemkhoNew, dt))
                {
                    MessageBox.Show("Lưu thông tin thành công!");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra dữ liệu!");
                }
               
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void cbxNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGridView();            
        }
        private void UpdateGridView()
        {
            string maThuongHieu = this.list_NCC[cbxNhomHang.SelectedIndex].MaThuongHieu;
            this.ct_kiemkhos = KiemKho_DAL.get_AllLinhKien(maThuongHieu);
            gridControl1.DataSource = this.ct_kiemkhos;// KiemKho_DAL.get_AllLinhKien(maThuongHieu);// this.list_KiemKho;
            gridControl1.RefreshDataSource();

        }
        
    }
}
