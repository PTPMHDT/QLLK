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
        List<CT_KiemKho_View> list_KiemKho ;//= new List<KiemKho_View>();
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
            this.list_KiemKho = new List<CT_KiemKho_View>();
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
            for(int i = 0; i< this.list_KiemKho.Count; i++)
            {
                if (this.list_KiemKho[i].MaLinhKien == current.MaLinhKien)
                {
                    this.list_KiemKho[i].SoLuong ++;//= current.SoLuong;
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
                KiemKho_View kiemKho = new KiemKho_View();
                kiemKho.MaKiemKho = txtMaPhieu.Text;
                kiemKho.NgayKiem = dateNgayBan.Value;
                kiemKho.NhanVien = Context.getInstance().nv.MaNhanVien;
                kiemKho.TrangThai = 1;
                for (int i = 0; i < this.list_KiemKho.Count;i++ )
                {
                    this.list_KiemKho[i].MaKiemKho = txtMaPhieu.Text;
                }
                if (KiemKho_DAL.add(kiemKho, this.list_KiemKho))
                {
                    MessageBox.Show("Lưu thông tin thành công!");
                }
                //KiemKho_DAL.add(kiemKho);
                //foreach (CT_KiemKho_View item in this.list_KiemKho)
                //{
                //    item.MaKiemKho = txtMaPhieu.Text;
                //    if (KiemKho_DAL.add(item))
                //    {
                //        MessageBox.Show("Lưu thông tin thành công!");
                //    }
                //}
                
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
            this.list_KiemKho = KiemKho_DAL.get_AllLinhKien(maThuongHieu);
            gridControl1.DataSource = KiemKho_DAL.get_AllLinhKien(maThuongHieu);// this.list_KiemKho;
            gridControl1.RefreshDataSource();

        }
        
    }
}
