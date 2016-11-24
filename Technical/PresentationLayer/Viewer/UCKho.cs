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
using PresentationLayer.GlobalVariable;
using DevExpress.XtraEditors.Controls;

namespace PresentationLayer
{
    public partial class UCKho : UserControl
    {
        DataTable dt_linhKien = new DataTable();
        private List<LinhKien_View> ls_linhKien;
        private List<ThuongHieu_View> listThuongHieu;
        private List<DonViTinh_View> listDonViTinh;
        private List<NhaCungCap_View> listNhaCungCap;
        public UCKho()
        {
            //InitializeComponent();
            this.Load += UCLinhKien_Load;
        }

        void UCLinhKien_Load(object sender, EventArgs e)
        {
            SetDataLoad();
        }
        private void txtTenLinhKien_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMaLinhKien_EditValueChanged(object sender, EventArgs e)
        {

        }
        //Load data LINHKIEN tu database do bao gridview
        void SetDataLoad()
        {
            Clear();
            ls_linhKien = new List<LinhKien_View>();
            //ls_linhKien = LinhKien_DAL.getAll_LinhKien();

            //gridCtrlLinhKien.DataSource = ls_linhKien;

            Load_ComboBox_ThuongHieu();
            Load_ComboBox_DonViTinh();
            Load_ComboBox_NhaCungCap();
            //gridCtrlLinhKien.RefreshDataSource();
        }
        #region ComboBox
        void Load_ComboBox_ThuongHieu()
        {
            listThuongHieu = new List<ThuongHieu_View>();

            listThuongHieu = ThuongHieu_DAL.getAll_ThuongHieu();

            ComboBoxItemCollection items = cbThuongHieu.Properties.Items;
            items.BeginUpdate();
            
            try
            {
                for (int i = 0; i < listThuongHieu.Count; i++)
                {
                    items.Add(listThuongHieu[i].TenThuongHieu.ToString());
                }
            }
            finally
            {
                items.EndUpdate();
            }
            cbThuongHieu.Properties.AutoComplete = true;
        }
        void Load_ComboBox_DonViTinh()
        {
            listDonViTinh = new List<DonViTinh_View>();

            listDonViTinh = DonViTinh_DAL.getAll_DonViTinh();

            ComboBoxItemCollection items = cbDonViTinh.Properties.Items;
            items.BeginUpdate();

            try
            {
                for (int i = 0; i < listDonViTinh.Count; i++)
                {
                    items.Add(listDonViTinh[i].TenDonViTinh.ToString());
                }
            }
            finally
            {
                items.EndUpdate();
            }
            cbDonViTinh.Properties.AutoComplete = true;
        }

        void Load_ComboBox_NhaCungCap()
        {
            //listNhaCungCap = new List<NhaCungCap_View>();
            //listNhaCungCap = NhaCungCap_DAL.getAll_NhaCungCap();
            //ComboBoxItemCollection items = cbNhaCungCap.Properties.Items;
            //items.BeginUpdate();

            //try
            //{
            //    for (int i = 0; i < listNhaCungCap.Count; i++)
            //    {
            //        items.Add(listNhaCungCap[i].TenNhaCungCap.ToString());
            //    }
            //}
            //finally
            //{
            //    items.EndUpdate();
            //}
            //cbNhaCungCap.Properties.AutoComplete = true;
        }
        #endregion
        private void gridView_LinhKien_Click(object sender, EventArgs e)
        {
            //LinhKien_View itemSelect = gridViewLinhKien.GetFocusedRow() as LinhKien_View;

            //txtMaLinhKien.Text = itemSelect.MaLinhKien;
            //txtTenLinhKien.Text = itemSelect.TenLinhKien;
            //cbThuongHieu.Text = itemSelect.ThuongHieu;
            //cbDonViTinh.Text = itemSelect.DonViTinh;
            //txtGiaMua.Text = itemSelect.GiaBanLe.ToString();
            //txtGiaBanLe.Text = itemSelect.GiaBanLe.ToString();
            //txtGiaBanSi.Text = itemSelect.GiaBanSi.ToString();
            //cbNhaCungCap.Text = itemSelect.NhaCungCap;
            //txtThoiGianBH.Text = itemSelect.ThoiGianBaoHanh.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LinhKien_View item = new LinhKien_View();

            //item.MaLinhKien = txtMaLinhKien.Text;
            //item.TenLinhKien = txtTenLinhKien.Text;
            //item.MaThuongHieu = listThuongHieu[cbThuongHieu.SelectedIndex].MaThuongHieu;
            //item.MaDonViTinh = listDonViTinh[cbDonViTinh.SelectedIndex].MaDonViTinh;
            //item.GiaBanLe = Decimal.Parse(txtGiaBanLe.Text);
            //item.GiaBanSi = Decimal.Parse(txtGiaBanSi.Text);
            //item.MaNhaCungCap = listNhaCungCap[cbNhaCungCap.SelectedIndex].MaNhaCungCap;
            //item.TinhTrang = 1;
            //item.ThoiGianBaoHanh = int.Parse(txtThoiGianBH.Text);

            //if(LinhKien_DAL.Add_LinhKien(item))
            //{
            //    MessageBox.Show("Đã thêm thanh công");
            //    SetDataLoad();
            //}
            //else
            //{
            //    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại");
            //}
        }
        void Clear()
        {
            //txtMaLinhKien.Text = LinhKien_DAL.get_LinhKienMax();
            //txtTenLinhKien.Text = "";
            //cbThuongHieu.Text = "";
            //cbDonViTinh.Text = "";
            //txtGiaMua.Text = "";
            //txtGiaBanLe.Text = "";
            //txtGiaBanSi.Text = "";
            //cbNhaCungCap.Text = "";
            //txtThoiGianBH.Text = "";

        }

        private void cbThuongHieu_Select_Change(object sender, EventArgs e)
        {
            
        }
    }
}
